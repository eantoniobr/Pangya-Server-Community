<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../includes/IffCatalog.php';
require_once __DIR__ . '/../includes/WarehouseService.php';
require_once __DIR__ . '/../includes/AuditLogger.php';

requireLogin();

$backTo = $_SERVER['HTTP_REFERER'] ?? '/Shop/ShopItem.php';
if (!str_starts_with(parse_url($backTo, PHP_URL_PATH) ?? '', '/Shop/')) {
    $backTo = '/Shop/ShopItem.php';
}

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    App::redirect($backTo);
}

if (!csrfValid($_POST['csrf_token'] ?? null)) {
    setFlash('error', 'Token de segurança inválido, tente novamente.');
    App::redirect($backTo);
}

$action = (string) ($_POST['action'] ?? '');
$typeId = (int) ($_POST['typeid'] ?? 0);

if ($action !== 'buy_shop_item' || $typeId <= 0) {
    setFlash('error', 'Requisição inválida.');
    App::redirect($backTo);
}

$uid = (int) $_SESSION['uid'];

try {
    $pdo = getConnection();
    $pdo->beginTransaction();

    // Trava a linha do jogador pra evitar duas compras simultâneas
    // consumirem o mesmo crédito (ex.: duplo clique / duas abas abertas).
    $stmt = $pdo->prepare(
        'SELECT [limit_cnt], [current_cnt], [remain_cnt]
           FROM pangya.pangya_papel_shop_info WITH (UPDLOCK, ROWLOCK)
          WHERE [UID] = ?'
    );
    $stmt->execute([$uid]);
    $papelInfo = $stmt->fetch();

    if (!$papelInfo) {
        $pdo->rollBack();
        setFlash('error', 'Não encontramos seus créditos da Loja de Papel. Faça login novamente e tente de novo.');
        App::redirect($backTo);
    }

    if ((int) $papelInfo['remain_cnt'] <= 0) {
        $pdo->rollBack();
        setFlash('error', 'Você já usou todos os seus créditos de hoje na Loja de Papel. Volte amanhã!');
        App::redirect($backTo);
    }

    $warehouse = new WarehouseService($pdo, new IffCatalog());
    $itemName = $warehouse->add($uid, $typeId);

    $update = $pdo->prepare(
        'UPDATE pangya.pangya_papel_shop_info
            SET [current_cnt] = [current_cnt] + 1, [remain_cnt] = [remain_cnt] - 1, [last_update] = SYSUTCDATETIME()
          WHERE [UID] = ?'
    );
    $update->execute([$uid]);

    $pdo->commit();

    (new AuditLogger($pdo))->record('shop_item_purchase', $typeId, [
        'uid' => $uid,
        'item_name' => $itemName,
    ]);

    $remaining = (int) $papelInfo['remain_cnt'] - 1;
    setFlash('success', 'Item "' . $itemName . '" enviado para o seu armazém! Créditos restantes hoje: ' . $remaining . '.');
} catch (InvalidArgumentException $e) {
    if ($pdo->inTransaction()) {
        $pdo->rollBack();
    }
    setFlash('error', $e->getMessage());
} catch (PDOException $e) {
    if ($pdo->inTransaction()) {
        $pdo->rollBack();
    }
    error_log('Erro ao comprar item na loja: ' . $e->getMessage());
    setFlash('error', 'Não foi possível concluir a compra agora. Tente novamente em instantes.');
}

App::redirect($backTo);
