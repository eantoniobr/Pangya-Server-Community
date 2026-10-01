<?php
/**
 * dashboard.php
 * -----------------------------------------------------------------------
 * Painel do usuário autenticado. Busca dados em:
 *   - pangya.account                 -> perfil / dados de login
 *   - pangya.user_info               -> estatísticas de jogo (nível, Pang, Cookie, ranking)
 *   - pangya.pangya_character_information -> personagens possuídos
 *   - pangya.pangya_item_warehouse       -> itens no armazém (contagem)
 *   - pangya.pangya_caddie_information   -> caddies possuídos
 *   - pangya.pangya_mascot_info          -> mascotes possuídos
 * -----------------------------------------------------------------------
 */
require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../iff/generate_cache.php';
require_once __DIR__ . '/../Server/ServerMetrics.php';

requireLogin();

$uid = (int)$_SESSION['uid'];

$account        = null;
$stats          = null;
$characters     = [];
$caddies        = [];
$mascots        = [];
$warehouseItems = [];
$itemCount      = 0;
$loadError      = '';

try {
    $pdo = getConnection();
// -------------------------------------------------------------
// 1. Perfil da conta
// -------------------------------------------------------------
$stmt = $pdo->prepare('SELECT 
    A.ID, 
    A.[UID], 
    A.Sex, 
    A.doTutorial, 
    CONVERT(VARCHAR(MAX), CAST(A.[NICK] AS VARBINARY(MAX)), 2) AS [NICK_HEX],
    A.School, 
    A.capability, 
    A.Logon, 
    A.ServerID, 
    A.MannerFlag, 
	A.LogonCount,
	A.LastLogonTime,
	A.RegDate,
    (CASE WHEN A.LastLeaveTime IS NULL THEN 0 ELSE datediff(minute, A.LastLeaveTime, getdate()) END) AS TIMEVAL, 
    ISNULL(C.GUILD_NAME, N\'\') AS GUILD_NAME,
    ISNULL(C.GUILD_UID, 0) AS GUILD_UID,
    ISNULL(C.GUILD_PANG, 0) AS GUILD_PANG, 
    ISNULL(C.GUILD_POINT, 0) AS GUILD_POINT,
    ISNULL(C.GUILD_MARK_IMG_IDX, 0) AS GUILD_MARK_IMG_IDX, 
    A.[Event], 
    A.Event2, 
    D.limit_cnt, 
    A.IDState, 
    (CASE WHEN A.domainid IS NULL THEN 0 ELSE A.domainid END) AS DOMAINID, 
    A.ChannelFlag, 
    D.current_cnt, 
    D.remain_cnt, 
    D.last_update,
    B.[level],
    IIF(C.GUILD_MARK_IMG IS NULL OR C.MEMBER_STATE_FLAG > 3, N\'\', C.GUILD_MARK_IMG) AS GUILD_MARK_IMG,
    ISNULL(UPPER(C.GUILD_MARK_IMG), N\'\') AS EMBLERVER,
    ISNULL(UPPER(A.MacAddress), N\'\') AS MAC,
    ISNULL(A.UserIp, N\'\') AS UserIp
FROM 
    pangya.account AS A 
    INNER JOIN pangya.pangya_papel_shop_info AS D ON A.[UID] = D.[UID]
    INNER JOIN pangya.user_info AS B ON D.[UID] = B.[UID]
    INNER JOIN (
        SELECT 
            E.GUILD_MARK_IMG_IDX,
            E.GUILD_MARK_IMG, 
            E.GUILD_UID, 
            E.GUILD_NAME, 
            E.MEMBER_STATE_FLAG, 
            E.GUILD_PANG, 
            E.GUILD_POINT, 
            D.[UID]
        FROM 
            pangya.account D 
            LEFT OUTER JOIN (
                SELECT 
                    x.GUILD_MARK_IMG_IDX,
                    x.GUILD_MARK_IMG, 
                    x.GUILD_UID, 
                    x.GUILD_NAME, 
                    y.MEMBER_STATE_FLAG, 
                    y.GUILD_PANG, 
                    y.GUILD_POINT
                FROM 
                    pangya.pangya_guild AS x, 
                    pangya.pangya_guild_member AS y
                WHERE 
                    y.MEMBER_UID = ?
                    AND y.MEMBER_STATE_FLAG < 9
                    AND (x.GUILD_STATE NOT IN(4, 5) OR x.GUILD_CLOSURE_DATE IS NULL OR getdate() < x.GUILD_CLOSURE_DATE)
            ) AS E ON D.Guild_UID = E.GUILD_UID
    ) AS C ON C.[UID] = ?
WHERE 
    A.[UID] = ?');

// Envia a variável 3 vezes para suprir as 3 ocorrências do ?
$stmt->execute([$uid, $uid, $uid]);
$account = $stmt->fetch(PDO::FETCH_ASSOC);

if (!empty($account['NICK_HEX'])) {
    $nickBytes = hex2bin($account['NICK_HEX']);

    if ($nickBytes !== false) {
        $account['NICK'] = trim(mb_convert_encoding($nickBytes, 'UTF-8', 'UTF-16LE'));
    } else {
        $account['NICK'] = '';
    }
} else {
    $account['NICK'] = '';
}
    // -------------------------------------------------------------
    // 2. Estatísticas de jogo (pode não existir ainda para contas novas)
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        'pangya.GetInfo_User ?'
    );
    $stmt->execute([$uid]);
    $stats = $stmt->fetch();

    // -------------------------------------------------------------
    // 3. Personagens possuídos
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        'SELECT * from pangya.pangya_character_information WHERE UID = ?'
    );
    $stmt->execute([$uid]);
    $characters = $stmt->fetchAll();

    // -------------------------------------------------------------
    // 4. Caddies possuídos
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        'pangya.ProcGetCaddieInfo ?'
    );
    $stmt->execute([$uid]);
    $caddies = $stmt->fetchAll();

    // -------------------------------------------------------------
    // 5. Mascotes possuídos
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        'pangya.ProcGetMascotInfo ?'
    );
    $stmt->execute([$uid]);
    $mascots = $stmt->fetchAll();

    // -------------------------------------------------------------
    // 6. Itens do armazém, agrupados por TypeId
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        'SELECT [item_id], [typeid], [valid]
         FROM pangya.pangya_item_warehouse
         WHERE [UID] = ? AND [valid] = 1
         ORDER BY [item_id] DESC'
    );
    $stmt->execute([$uid]);
    $warehouseItems = $stmt->fetchAll();
    $itemCount = count($warehouseItems);

    $serverMetrics = (new ServerMetrics($pdo))->snapshot();

} catch (PDOException $e) {
    error_log('Erro ao carregar painel: ' . $e->getMessage());
	echo $e->getMessage();
    $loadError = t('dash_load_error');
}

// -------------------------------------------------------------
// 7. Cache em memória para lookups no IFF (evita reler o mesmo
//    typeid várias vezes — reaproveitado pelas 4 seções abaixo).
// -------------------------------------------------------------
$iffCache = [];

/**
 * Busca os dados de um typeid no IFF, com cache por request.
 * Retorna sempre um array (vazio se não encontrado), nunca null,
 * pra evitar 'Trying to access array offset on null'.
 */
function iffLookup(int $typeid, array &$cache): array
{
    if (!isset($cache[$typeid])) {
        $cache[$typeid] = find_cache($typeid) ?? [];
    }
    return $cache[$typeid];
}

function getItemTypeName(int $typeid): string
{
    // Extrai o ID do grupo do IFF (os 6 bits superiores do TypeID)
    $groupId = ($typeid & 0xFC000000) >> 26;

    // Mapeamento baseado no seu Enum
    return match ($groupId) {
        1       => 'Character',
        2       => 'Part',
        3       => 'Club',
        4       => 'ClubSet',
        5       => 'Ball',
        6       => 'Item',
        7       => 'Caddie',
        8       => 'CadItem',
        9       => 'SetItem',
        10      => 'Course',
        11      => 'Match',
        12      => 'Title',
        13      => 'Enchant',
        14      => 'Skin',
        15      => 'HairStyle',
        16      => 'Mascot',
        17      => 'ChildItem',
        18      => 'Furniture',
        19      => 'OfflineShop',
        20      => 'Achievement',
        27      => 'CounterItem',
        28      => 'AuxPart',
        29      => 'QuestStuff',
        30      => 'QuestItem',
        31      => 'Card',
        default => 'Unknown',
    };
}
$formattedWarehouseItems = [];

foreach ($warehouseItems as $item) {
    $typeid = (int)$item['typeid'];
    $itemData = iffLookup($typeid, $iffCache);

    // Verifica se a chave 'icon' existe E não está vazia (string vazia, null, etc)
    $iconName = (!empty($itemData['icon'])) ? $itemData['icon'] : 'default';

    // Verifica se o nome existe E não está vazio
    $itemName = (!empty($itemData['item_name'])) ? $itemData['item_name'] : ((!empty($itemData['name'])) ? $itemData['name'] : ('Item #' . $typeid));

    $formattedWarehouseItems[] = [
        'item_id' => (int) $item['item_id'],
        'typeid' => $typeid,
        'icon'   => $iconName,
		'item_type' => getItemTypeName($typeid),
        'name'   => $itemName,
    ];
}

$serverMetrics = $serverMetrics ?? ['registered' => 0, 'online' => 0, 'login_online' => false, 'game_online' => false, 'pang_rate' => 0, 'exp_rate' => 0, 'peak_online' => 0];

/**
 * Converte o código de sexo (smallint) em texto legível.
 */
function sexoLabel($sexo): string
{
    return match ((int)$sexo) {
        0 => t('male'),
        1 => t('female'),
        default => '-',
    };
}

function sexoIcon($sexo): string
{
	 return match ((int)$sexo) {
        0 => '<img src="/assets/img/bar/bar_male.png" alt="PangYa Community" height="24">',
        1 => '<img src="/assets/img/bar/bar_female.png" alt="PangYa Community" height="24">',
        default => '-',
    };	
}

function LevelIcon($level): string
{ 
    // Garante que o nível seja um número inteiro positivo
    $level = max(0, (int)$level);

    // Formata o número para ter sempre 3 dígitos (ex: 000, 009, 010, 070)
    $formattedLevel = sprintf('%03d', $level);

    // Caminho da imagem
    $iconPath = "/assets/img/level/level_{$formattedLevel}.PNG";

    return '<img src="' . $iconPath . '" alt="' . htmlspecialchars(t('level')) . ' ' . $level . '" height="24">';
}

function formatDate($value): string
{
    if (empty($value)) {
        return '-';
    }
    try {
        return (new DateTime($value))->format(currentLanguage() === 'en' ? 'Y-m-d H:i' : 'd/m/Y H:i');
    } catch (Exception $e) {
        return (string)$value;
    }
}

/**
 * Formata números conforme o idioma (pt-BR: 1.234 / demais: 1,234).
 */
function dashNumber($value): string
{
    return currentLanguage() === 'pt-BR'
        ? number_format((float)$value, 0, ',', '.')
        : number_format((float)$value, 0, '.', ',');
}

$pageTitle = t('dashboard');
require __DIR__ . '/../includes/header.php';
?>
<div class="d-flex justify-content-between align-items-center mb-4 flex-wrap gap-2">
    <h2 class="mb-0"><?= htmlspecialchars(t('dash_my_panel')) ?></h2>
    <div class="d-flex gap-2">
        <a href="/Shop/ShopCash.php" class="btn btn-warning btn-sm fw-bold"><i class="bi bi-cash-coin me-1"></i><?= htmlspecialchars(t('dash_donations')) ?></a>
        <?php if (isGameMaster()): ?>
            <a href="/Admin/index.php" class="btn btn-outline-danger btn-sm"><i class="bi bi-shield-lock me-1"></i><?= htmlspecialchars(t('dash_admin_panel')) ?></a>
        <?php endif; ?>
        <a href="logout.php" class="btn btn-outline-light btn-sm"><?= htmlspecialchars(t('logout')) ?></a>
    </div>
</div>

<div class="row g-3 mb-4">
    <div class="col-sm-6 col-lg-3"><div class="card p-3 h-100"><div class="small text-secondary"><?= htmlspecialchars(t('registered_users')) ?></div><div class="fs-3 fw-bold"><?= dashNumber((int) $serverMetrics['registered']) ?></div></div></div>
    <div class="col-sm-6 col-lg-3"><div class="card p-3 h-100"><div class="small text-secondary"><?= htmlspecialchars(t('players_online')) ?></div><div class="fs-3 fw-bold text-success"><?= dashNumber((int) $serverMetrics['online']) ?></div></div></div>
    <div class="col-sm-6 col-lg-3"><div class="card p-3 h-100"><div class="small text-secondary"><?= htmlspecialchars(t('service_status')) ?></div><div><?= htmlspecialchars(t('login_server')) ?>: <span class="badge bg-<?= $serverMetrics['login_online'] ? 'success' : 'danger' ?>"><?= htmlspecialchars($serverMetrics['login_online'] ? t('online') : t('offline')) ?></span></div><div><?= htmlspecialchars(t('game_server')) ?>: <span class="badge bg-<?= $serverMetrics['game_online'] ? 'success' : 'danger' ?>"><?= htmlspecialchars($serverMetrics['game_online'] ? t('online') : t('offline')) ?></span></div></div></div>
    <div class="col-sm-6 col-lg-3"><div class="card p-3 h-100"><div class="small text-secondary"><?= htmlspecialchars(t('active_rates')) ?></div><div>Pang: <?= htmlspecialchars((string) $serverMetrics['pang_rate']) ?>%</div><div>EXP: <?= htmlspecialchars((string) $serverMetrics['exp_rate']) ?>%</div></div></div>
</div>

<?php if ($account): ?>
<!-- ==========================================================
     Modal de edição do perfil (Nick / Sexo)
     Envia para update_profile.php, que faz o UPDATE no banco.
     ========================================================== -->
<div class="modal fade" id="editProfileModal" tabindex="-1" aria-labelledby="editProfileModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <form class="modal-content bg-dark text-light" action="update_profile.php" method="post" accept-charset="UTF-8">
            <div class="modal-header">
                <h5 class="modal-title" id="editProfileModalLabel"><i class="bi bi-pencil-square me-2"></i><?= htmlspecialchars(t('dash_edit_profile')) ?></h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="<?= htmlspecialchars(t('dash_close')) ?>"></button>
            </div>
            <div class="modal-body">
                <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">

                <div class="mb-3">
                    <label for="editNick" class="form-label">Nick</label>
                    <input
                        type="text"
                        class="form-control"
                        id="editNick"
                        name="nick"
                        maxlength="20"
                        required
                        value="<?= htmlspecialchars((string)$account['NICK']) ?>"
                    >
                    <div class="form-text"><?= htmlspecialchars(t('dash_nick_help')) ?></div>
                </div>

                <div class="mb-1">
                    <label for="editSexo" class="form-label"><?= htmlspecialchars(t('gender')) ?></label>
                    <select class="form-select" id="editSexo" name="sexo" required>
                        <option value="1" <?= (int)$account['Sex'] === 0 ? 'selected' : '' ?>><?= htmlspecialchars(t('male')) ?></option>
                        <option value="2" <?= (int)$account['Sex'] === 1 ? 'selected' : '' ?>><?= htmlspecialchars(t('female')) ?></option>
                    </select>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal"><?= htmlspecialchars(t('dash_cancel')) ?></button>
                <button type="submit" class="btn btn-primary"><?= htmlspecialchars(t('dash_save')) ?></button>
            </div>
        </form>
    </div>
</div>

<!-- ==========================================================
     Modal de edição de Personagem (Mastery / cabelo / roupa)
     Um único modal, reaproveitado para qualquer linha da lista —
     o JS no fim da página preenche os campos ao clicar em "Editar".
     ========================================================== -->
<div class="modal fade" id="editCharacterModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <form class="modal-content bg-dark text-light" action="update_collection.php" method="post" accept-charset="UTF-8">
            <div class="modal-header">
                <h5 class="modal-title"><i class="bi bi-pencil-square me-2"></i><?= htmlspecialchars(t('dash_edit_character')) ?> <span id="charTypeIdLabel"></span></h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="<?= htmlspecialchars(t('dash_close')) ?>"></button>
            </div>
            <div class="modal-body">
                <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
                <input type="hidden" name="type" value="character">
                <input type="hidden" name="typeid" id="charTypeId">

                <div class="mb-3">
                    <label for="charMastery" class="form-label">Mastery</label>
                    <input type="number" min="0" class="form-control" id="charMastery" name="mastery" required>
                </div>
                <div class="row g-3">
                    <div class="col-6">
                        <label for="charHair" class="form-label"><?= htmlspecialchars(t('dash_hair')) ?></label>
                        <input type="number" min="0" class="form-control" id="charHair" name="default_hair" required>
                    </div>
                    <div class="col-6">
                        <label for="charShirts" class="form-label"><?= htmlspecialchars(t('dash_shirts')) ?></label>
                        <input type="number" min="0" class="form-control" id="charShirts" name="default_shirts" required>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal"><?= htmlspecialchars(t('dash_cancel')) ?></button>
                <button type="submit" class="btn btn-primary"><?= htmlspecialchars(t('dash_save')) ?></button>
            </div>
        </form>
    </div>
</div>

<!-- ==========================================================
     Modal de edição de Caddie (nível / exp / aluguel)
     ========================================================== -->
<div class="modal fade" id="editCaddieModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <form class="modal-content bg-dark text-light" action="update_collection.php" method="post" accept-charset="UTF-8">
            <div class="modal-header">
                <h5 class="modal-title"><i class="bi bi-pencil-square me-2"></i><?= htmlspecialchars(t('dash_edit_caddie')) ?> <span id="caddieTypeIdLabel"></span></h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="<?= htmlspecialchars(t('dash_close')) ?>"></button>
            </div>
            <div class="modal-body">
                <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
                <input type="hidden" name="type" value="caddie">
                <input type="hidden" name="typeid" id="caddieTypeId">

                <div class="row g-3 mb-3">
                    <div class="col-6">
                        <label for="caddieLevel" class="form-label"><?= htmlspecialchars(t('level')) ?></label>
                        <input type="number" min="0" class="form-control" id="caddieLevel" name="clevel" required>
                    </div>
                    <div class="col-6">
                        <label for="caddieExp" class="form-label"><?= htmlspecialchars(t('dash_exp')) ?></label>
                        <input type="number" min="0" class="form-control" id="caddieExp" name="exp" required>
                    </div>
                </div>
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="caddieRent" name="rentflag" value="1">
                    <label class="form-check-label" for="caddieRent"><?= htmlspecialchars(t('dash_rented')) ?></label>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal"><?= htmlspecialchars(t('dash_cancel')) ?></button>
                <button type="submit" class="btn btn-primary"><?= htmlspecialchars(t('dash_save')) ?></button>
            </div>
        </form>
    </div>
</div>

<!-- ==========================================================
     Modal de edição de Mascote (nível / exp)
     ========================================================== -->
<div class="modal fade" id="editMascotModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog">
        <form class="modal-content bg-dark text-light" action="update_collection.php" method="post" accept-charset="UTF-8">
            <div class="modal-header">
                <h5 class="modal-title"><i class="bi bi-pencil-square me-2"></i><?= htmlspecialchars(t('dash_edit_mascot')) ?> <span id="mascotTypeIdLabel"></span></h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="<?= htmlspecialchars(t('dash_close')) ?>"></button>
            </div>
            <div class="modal-body">
                <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
                <input type="hidden" name="type" value="mascot">
                <input type="hidden" name="typeid" id="mascotTypeId">

                <div class="row g-3">
                    <div class="col-6">
                        <label for="mascotLevel" class="form-label"><?= htmlspecialchars(t('level')) ?></label>
                        <input type="number" min="0" class="form-control" id="mascotLevel" name="mlevel" required>
                    </div>
                    <div class="col-6">
                        <label for="mascotExp" class="form-label"><?= htmlspecialchars(t('dash_exp')) ?></label>
                        <input type="number" min="0" class="form-control" id="mascotExp" name="exp" required>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-light" data-bs-dismiss="modal"><?= htmlspecialchars(t('dash_cancel')) ?></button>
                <button type="submit" class="btn btn-primary"><?= htmlspecialchars(t('dash_save')) ?></button>
            </div>
        </form>
    </div>
</div>
<?php endif; ?>

<?php if ($loadError): ?>
    <div class="alert alert-danger"><?= htmlspecialchars($loadError) ?></div>
<?php elseif (!$account): ?>
    <div class="alert alert-warning"><?= htmlspecialchars(t('dash_no_account')) ?></div>
<?php else: ?>

    <div class="row g-4">
        <!-- Perfil -->
        <div class="col-lg-5">
            <div class="card p-4 h-100">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h5 class="mb-0"><i class="bi bi-person-circle me-2"></i><?= htmlspecialchars(t('profile')) ?></h5>
                    <button type="button" class="btn btn-sm btn-outline-light" data-bs-toggle="modal" data-bs-target="#editProfileModal">
                        <i class="bi bi-pencil-square me-1"></i><?= htmlspecialchars(t('dash_edit')) ?>
                    </button>
                </div>
                <table class="table table-dark table-borderless mb-0">
                    <tbody>
                        <tr><th scope="row">UID</th><td><?= htmlspecialchars((string)$account['UID']) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_user_id')) ?></th><td><?= htmlspecialchars((string)$account['ID']) ?></td></tr>
                        <tr><th scope="row">Nick</th><td><?= htmlspecialchars((string)$account['NICK']) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('gender')) ?></th><td><?= htmlspecialchars(sexoLabel($account['Sex'])) ?> <?= sexoIcon($account['Sex']) ?></td></tr>
						<tr><th scope="row"><?= htmlspecialchars(t('level')) ?></th><td><?= LevelIcon($stats['level']) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_registered_at')) ?></th><td><?= htmlspecialchars(formatDate($account['RegDate'])) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_last_login')) ?></th><td><?= htmlspecialchars(formatDate($account['LastLogonTime'])) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_total_logins')) ?></th><td><?= htmlspecialchars((string)$account['LogonCount']) ?></td></tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_guild')) ?></th>
                            <td><?= ((int)$account['GUILD_UID'] > 0) ? htmlspecialchars((string)$account['GUILD_UID']) : htmlspecialchars(t('dash_none')) ?></td>
                        </tr>
                        <tr><th scope="row"><?= htmlspecialchars(t('dash_invited')) ?></th>
                            <td><?= ((int)($account['Invited'] ?? 0) === 1) ? htmlspecialchars(t('dash_yes')) : htmlspecialchars(t('dash_no')) ?></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <!-- Estatísticas de jogo -->
        <div class="col-lg-7">
            <div class="card p-4 h-100">
                <h5 class="mb-3"><i class="bi bi-bar-chart-fill me-2"></i><?= htmlspecialchars(t('game_stats')) ?></h5>
                <?php if (!$stats): ?>
                    <p class="mb-0 text-secondary"><?= htmlspecialchars(t('dash_no_stats')) ?></p>
                <?php else: ?>
                    <div class="row g-3">
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= htmlspecialchars((string)$stats['level']) ?></div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('level')) ?></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= dashNumber((float)$stats['Pang']) ?><img src="/assets/img/bar/bar_pang.png" alt="PangYa Community" height="24"></div>
                                <a href="/Shop/ShopCash.php" class="small text-warning"><?= htmlspecialchars(t('dash_recharge')) ?></a>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= dashNumber((float)$stats['Cookie']) ?><img src="/assets/img/bar/bar_cookies.png" alt="PangYa Community" height="24"></div>
                                <a href="/Shop/ShopCash.php" class="small text-warning"><?= htmlspecialchars(t('dash_recharge')) ?></a>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= dashNumber((float)$stats['Xp']) ?></div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('experience')) ?></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= htmlspecialchars((string)$stats['LadderPoint']) ?></div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('dash_ladder_points')) ?></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold">
                                    <?= htmlspecialchars((string)$stats['LadderWin']) ?><?= htmlspecialchars(t('dash_win_abbr')) ?>
                                    / <?= htmlspecialchars((string)$stats['LadderLose']) ?><?= htmlspecialchars(t('dash_loss_abbr')) ?>
                                </div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('dash_wins_losses')) ?></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= htmlspecialchars((string)$stats['Holes']) ?></div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('dash_holes')) ?></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= htmlspecialchars((string)$stats['HIO']) ?><img src="/assets/img/bar/gp_icon_hio.png" alt="PangYa Community" height="42"></div>
                            </div>
                        </div>
                        <div class="col-6 col-md-4">
                            <div class="p-3 rounded bg-black bg-opacity-25 text-center">
                                <div class="fs-4 fw-bold"><?= htmlspecialchars((string)$stats['Media_score']) ?></div>
                                <div class="small text-secondary"><?= htmlspecialchars(t('dash_avg_score')) ?></div>
                            </div>
                        </div>
                    </div>
                <?php endif; ?>
            </div>
        </div>

        <!-- Personagens -->
<div class="col-lg-4">
    <div class="card p-4 h-100">
        <h5 class="mb-3"><i class="bi bi-person-badge-fill me-2"></i><?= htmlspecialchars(t('characters')) ?> (<?= count($characters) ?>)</h5>
        
        <?php if (empty($characters)): ?>
            <p class="mb-0 text-secondary"><?= htmlspecialchars(t('dash_no_characters')) ?></p>
        <?php else: ?>
            <ul class="list-group list-group-flush">
                <?php foreach ($characters as $char): 
                    // Usa o cache compartilhado (mesmo do armazém) em vez de
                    // chamar find_all() de novo sem cache.
                    $itemData = iffLookup((int)$char['typeid'], $iffCache);
                    $itemName = htmlspecialchars($itemData['item_name'] ?? t('dash_item_not_found'));
					$itemIcon = htmlspecialchars($itemData['icon'] ?? 'default');
                ?>
                    <li class="list-group-item bg-transparent text-light collection-row d-flex align-items-center justify-content-between">
                        <div class="d-flex align-items-center gap-2">
                            <span class="item-icon" style="width:64px;height:64px;">                               
                                <img
                                    src="/assets/img/items/<?= $itemIcon ?>.png"
                                    alt="<?= $itemName ?>"
                                    loading="lazy"
                                    onerror="this.onerror=null;this.style.display='none';"
                                >
                            </span>
                            <div>
                                <div class="text-secondary small">Mastery: <?= htmlspecialchars((string)$char['Mastery']) ?></div>
                            </div>
                        </div>

                        <div class="collection-actions">
                            <button
                                type="button"
                                class="btn btn-sm btn-outline-light edit-character-btn"
                                data-bs-toggle="modal"
                                data-bs-target="#editCharacterModal"
                                data-typeid="<?= (int)$char['typeid'] ?>"
                                data-mastery="<?= (int)$char['Mastery'] ?>"
                                data-hair="<?= (int)$char['default_hair'] ?>"
                                data-shirts="<?= (int)$char['default_shirts'] ?>"
                            ><i class="bi bi-pencil-square"></i></button>
                        </div>
                    </li>
                <?php endforeach; ?>
            </ul>
        <?php endif; ?>
    </div>
</div>

        <!-- Caddies -->
     <!-- Caddies -->
<div class="col-lg-4">
    <div class="card p-4 h-100">
        <h5 class="mb-3"><i class="bi bi-person-arms-up me-2"></i><?= htmlspecialchars(t('caddies')) ?> (<?= count($caddies) ?>)</h5>

        <?php if (empty($caddies)): ?>
            <p class="mb-0 text-secondary"><?= htmlspecialchars(t('dash_no_caddies')) ?></p>
        <?php else: ?>
            <ul class="list-group list-group-flush">
                <?php foreach ($caddies as $caddie): 
                    $itemData = iffLookup((int)$caddie['typeid'], $iffCache);
                    $itemName = htmlspecialchars($itemData['item_name'] ?? t('dash_item_not_found'));
					$itemIcon = htmlspecialchars($itemData['icon'] ?? 'default');
                ?>
                    <li class="list-group-item bg-transparent text-light collection-row d-flex align-items-center justify-content-between">
                        <div class="d-flex align-items-center gap-2">
                            <span class="item-icon" style="width:64px;height:64px;">
                                <img
                                    src="/assets/img/items/<?= $itemIcon ?>.png"
                                    alt="<?= $itemName ?>"
                                    loading="lazy"
                                    onerror="this.onerror=null;this.style.display='none';"
                                >
                            </span>
                            <div class="collection-info">
                                  <div><?= htmlspecialchars(t('dash_name')) ?>: <?= $itemName ?></div>
                                <div class="text-secondary small"><?= htmlspecialchars(t('dash_lv_abbr')) ?> <?= htmlspecialchars((string)$caddie['cLevel']) ?></div>
                            </div>
                        </div>

                        <div class="collection-actions">
                            <button
                                type="button"
                                class="btn btn-sm btn-outline-light edit-caddie-btn"
                                data-bs-toggle="modal"
                                data-bs-target="#editCaddieModal"
                                data-typeid="<?= (int)$caddie['typeid'] ?>"
                                data-clevel="<?= (int)$caddie['cLevel'] ?>"
                                data-exp="<?= (int)$caddie['Exp'] ?>"
                                data-rentflag="<?= (int)$caddie['RentFlag'] ?>"
                            ><i class="bi bi-pencil-square"></i></button>
                        </div>
                    </li>
                <?php endforeach; ?>
            </ul>
        <?php endif; ?>
    </div>
</div>

<!-- Mascotes -->
<div class="col-lg-4">
    <div class="card p-4 h-100">
        <h5 class="mb-3"><i class="bi bi-emoji-heart-eyes-fill me-2"></i><?= htmlspecialchars(t('mascots')) ?> (<?= count($mascots) ?>)</h5>

        <?php if (empty($mascots)): ?>
            <p class="mb-0 text-secondary"><?= htmlspecialchars(t('dash_no_mascots')) ?></p>
        <?php else: ?>
            <ul class="list-group list-group-flush">
                <?php foreach ($mascots as $mascot): 
                    $itemData = iffLookup((int)$mascot['typeid'], $iffCache);
					 $itemName = htmlspecialchars($itemData['item_name'] ?? t('dash_item_not_found'));
					$itemIcon = htmlspecialchars($itemData['icon'] ?? 'default');
                ?>
                    <li class="list-group-item bg-transparent text-light collection-row d-flex align-items-center justify-content-between">
                        <div class="d-flex align-items-center gap-2">
                            <span class="item-icon" style="width:64px;height:64px;">
                                <img
                                   src="/assets/img/items/<?= $itemIcon ?>.png"
                                    alt="<?= $itemName ?>"
                                    loading="lazy"
                                    onerror="this.onerror=null;this.style.display='none';"
                                >
                            </span>
                            <div class="collection-info">
                                <div><?= htmlspecialchars(t('dash_name')) ?>: <?= $itemName ?></div>
                                <div class="text-secondary small"><?= htmlspecialchars(t('dash_lv_abbr')) ?> <?= htmlspecialchars((string)$mascot['mLevel']) ?></div>
                            </div>
                        </div>

                        <div class="collection-actions">
                            <button
                                type="button"
                                class="btn btn-sm btn-outline-light edit-mascot-btn"
                                data-bs-toggle="modal"
                                data-bs-target="#editMascotModal"
                                data-typeid="<?= (int)$mascot['typeid'] ?>"
                                data-mlevel="<?= (int)$mascot['mLevel'] ?>"
                                data-mexp="<?= (int)$mascot['mExp'] ?>"
                            ><i class="bi bi-pencil-square"></i></button>
                        </div>
                    </li>
                <?php endforeach; ?>
            </ul>
        <?php endif; ?>
    </div>
</div>

<!-- Armazém -->
<div class="col-lg-12 mt-4">
    <div class="card p-4">
        <div class="d-flex flex-wrap justify-content-between align-items-center mb-3 gap-2">
            <h5 class="mb-0"><i class="bi bi-archive-fill me-2"></i><?= htmlspecialchars(sprintf(t('dash_warehouse_summary'), (int)$itemCount, count($warehouseItems))) ?></h5>
            
            <!-- Campo de Busca em Tempo Real -->
            <input type="text" id="warehouseSearch" class="form-control form-control-sm style-search" style="max-width: 200px;" placeholder="<?= htmlspecialchars(t('dash_warehouse_search')) ?>">
        </div>

        <?php if (!empty($formattedWarehouseItems)): 
            // Definção dos ícones, rótulos e chaves de filtro
            $typesConfig = [
                'all'       => ['label' => t('dash_cat_all'),      'icon' => ''],
                'card'      => ['label' => t('dash_cat_card'),      'icon' => '/assets/img/bar/BtnCard.png'],
                'setitem'   => ['label' => t('dash_cat_setitem'),       'icon' => '/assets/img/bar/BtnSet.png'],
                'part'      => ['label' => t('dash_cat_part'),      'icon' => '/assets/img/bar/BtnPart.png'],
                'item'      => ['label' => t('dash_cat_item'),      'icon' => '/assets/img/bar/BtnItem.png'],
                'skin'      => ['label' => t('dash_cat_skin'),      'icon' => '/assets/img/bar/BtnSkin.png'],
                'clubset'   => ['label' => t('dash_cat_clubset'),   'icon' => '/assets/img/bar/BtnClub.png'],
                'character' => ['label' => t('dash_cat_character'), 'icon' => '/assets/img/bar/nuri_renew.png'],
                'caddie'    => ['label' => t('dash_cat_caddie'),    'icon' => '/assets/img/bar/BtnCaddie.png'],
                'auxpart'   => ['label' => t('dash_cat_auxpart'),      'icon' => '/assets/img/bar/BtnAuxPart.png'],
                'ball'      => ['label' => t('dash_cat_ball'),      'icon' => '/assets/img/bar/BtnBall.png'],
                'mascot'    => ['label' => t('dash_cat_mascot'),   'icon' => '/assets/img/bar/BtnMascot.png'],
            ];

            // Extrai as categorias únicas dos itens do usuário (convertidas em minúsculo)
            $userTypes = array_unique(array_map('strtolower', array_column($formattedWarehouseItems, 'item_type')));
        ?>
            <!-- Botões de Filtro por Categoria com Ícones -->
            <div class="d-flex gap-1 overflow-auto pb-2 mb-3" id="warehouseCategoryFilters" style="white-space: nowrap;position: relative;left: 340px;">
                <!-- Botão 'Todos' -->
                <button type="button" class="btn btn-sm btn-primary category-btn active d-inline-flex align-items-center gap-1" data-type="all">
                    <span><?= htmlspecialchars($typesConfig['all']['label']) ?></span>
                </button>

                <!-- Botões para cada tipo existente no armazém do usuário -->
                <?php foreach ($typesConfig as $key => $config): ?>
                    <?php if ($key !== 'all' && in_array($key, $userTypes, true)): ?>
                        <button type="button" class="btn btn-sm btn-outline-secondary text-light category-btn d-inline-flex align-items-center gap-1" data-type="<?= htmlspecialchars($key) ?>">
                            <?php if (!empty($config['icon'])): ?>
                                <img src="<?= htmlspecialchars($config['icon']) ?>" alt="<?= htmlspecialchars($config['label']) ?>" height="42" onerror="this.style.display='none';">
                            <?php endif; ?>
                            <span><?= htmlspecialchars($config['label']) ?></span>
                        </button>
                    <?php endif; ?>
                <?php endforeach; ?>
            </div>
        <?php endif; ?>

        <?php if (canEditItemsOnWeb()): ?>
        <form action="update_warehouse.php" method="post" accept-charset="UTF-8" class="row g-2 align-items-end mb-3">
            <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
            <input type="hidden" name="action" value="add">
            <div class="col-sm-7 col-md-6 position-relative">
                <label for="iffItemSearch" class="form-label small mb-1"><?= htmlspecialchars(t('add_item')) ?></label>
                <input type="search" id="iffItemSearch" class="form-control form-control-sm" autocomplete="off" placeholder="<?= htmlspecialchars(t('search_item')) ?>" required>
                <input type="hidden" name="typeid" id="newItemTypeId" required>
                <div id="iffSearchResults" class="list-group position-absolute w-100 shadow d-none" style="z-index: 10;"></div>
                <img id="iffItemPreview" class="mt-2 d-none" width="48" height="48" alt="">
            </div>
            <div class="col-auto">
                <button type="submit" id="addIffItemButton" class="btn btn-sm btn-primary" disabled><i class="bi bi-plus-lg me-1"></i><?= htmlspecialchars(t('add')) ?></button>
            </div>
        </form>
        <?php endif; ?>

        <?php if (empty($warehouseItems)): ?>
            <p class="mb-0 text-secondary"><?= htmlspecialchars(t('dash_no_warehouse_items')) ?></p>
        <?php else: ?>
            <!-- Container onde os itens serão inseridos via JS -->
            <div id="warehouseContainer" class="row g-2 mb-4"></div>

            <!-- Controles da Paginação JS -->
            <nav id="warehousePaginationNav" aria-label="<?= htmlspecialchars(t('dash_warehouse_nav')) ?>">
                <ul class="pagination pagination-sm justify-content-center mb-0" id="warehousePagination"></ul>
            </nav>
        <?php endif; ?>
    </div>
</div>
<?php endif; ?>
<script>
document.addEventListener('DOMContentLoaded', () => {
    const labels = <?= json_encode([
        'add' => t('add'),
        'remove' => t('remove'),
        'itemId' => t('item_id'),
        'noItemsFound' => t('no_items_found'),
    ], JSON_HEX_TAG | JSON_HEX_APOS | JSON_HEX_QUOT | JSON_HEX_AMP) ?>;
    const canManageItems = <?= json_encode(canEditItemsOnWeb()) ?>;
    const iffSearch = document.getElementById('iffItemSearch');
    const iffResults = document.getElementById('iffSearchResults');
    const iffTypeId = document.getElementById('newItemTypeId');
    const addIffItemButton = document.getElementById('addIffItemButton');
    const iffItemPreview = document.getElementById('iffItemPreview');
    let iffSearchTimer;

    if (iffSearch && iffResults && iffTypeId && addIffItemButton) {
        iffSearch.addEventListener('input', () => {
            window.clearTimeout(iffSearchTimer);
            iffTypeId.value = '';
            addIffItemButton.disabled = true;
            iffResults.replaceChildren();
            iffResults.classList.add('d-none');

            const query = iffSearch.value.trim();
            if (query.length < 2) return;

            iffSearchTimer = window.setTimeout(async () => {
                try {
                    const response = await fetch(`/iff/search.php?q=${encodeURIComponent(query)}`);
                    const items = await response.json();
                    if (!response.ok || !Array.isArray(items)) return;

                    items.forEach(item => {
                        const option = document.createElement('button');
                        option.type = 'button';
                        option.className = 'list-group-item list-group-item-action bg-dark text-light border-secondary';
                        option.textContent = `${item.name} (#${item.typeid})`;
                        option.addEventListener('click', () => {
                            iffSearch.value = `${item.name} (#${item.typeid})`;
                            iffTypeId.value = item.typeid;
                            addIffItemButton.disabled = false;
                            iffResults.classList.add('d-none');
                            fetch(`/iff/item_icon.php?typeid=${encodeURIComponent(item.typeid)}`)
                                .then(response => response.ok ? response.json() : null)
                                .then(data => {
                                    if (!data || !iffItemPreview) return;
                                    iffItemPreview.src = data.url;
                                    iffItemPreview.alt = item.name;
                                    iffItemPreview.classList.remove('d-none');
                                })
                                .catch(() => iffItemPreview?.classList.add('d-none'));
                        });
                        iffResults.appendChild(option);
                    });

                    iffResults.classList.toggle('d-none', items.length === 0);
                } catch (_) {
                    iffResults.classList.add('d-none');
                }
            }, 250);
        });
    }

    // 1. Dados injetados com cache já processado pelo PHP
    const allWarehouseItems = <?= json_encode($formattedWarehouseItems, JSON_HEX_TAG | JSON_HEX_APOS | JSON_HEX_QUOT | JSON_HEX_AMP) ?>;
    const csrfToken = <?= json_encode(csrfToken() ?? '') ?>;
    
    const itemsPerPage = 12;
    let currentPage = 1;
    let currentCategory = 'all';
    let filteredItems = [...allWarehouseItems];

    const container = document.getElementById('warehouseContainer');
    const paginationEl = document.getElementById('warehousePagination');
    const searchInput = document.getElementById('warehouseSearch');
    const categoryFiltersContainer = document.getElementById('warehouseCategoryFilters');

    function escapeHtml(str) {
        return String(str)
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#039;');
    }

    // Aplica o filtro comparando a chave em caixa baixa (ex: item.item_type "Part" vira "part")
    function applyFilters() {
        const query = searchInput ? searchInput.value.toLowerCase().trim() : '';

        filteredItems = allWarehouseItems.filter(item => {
            const itemTypeKey = item.item_type ? item.item_type.toLowerCase() : '';
            const matchesCategory = (currentCategory === 'all') || (itemTypeKey === currentCategory);
            
            const matchesQuery = !query || 
                item.typeid.toString().includes(query) || 
                item.name.toLowerCase().includes(query) ||
                itemTypeKey.includes(query);

            return matchesCategory && matchesQuery;
        });

        currentPage = 1;
        renderItems();
    }

    // Renderização dos cards
    function renderItems() {
        if (!container) return;
        container.innerHTML = '';

        if (filteredItems.length === 0) {
            container.innerHTML = `<div class="col-12"><p class="text-secondary mb-0">${escapeHtml(labels.noItemsFound)}</p></div>`;
            if (paginationEl) paginationEl.innerHTML = '';
            return;
        }

        const startIndex = (currentPage - 1) * itemsPerPage;
        const pageItems = filteredItems.slice(startIndex, startIndex + itemsPerPage);
        const fragment = document.createDocumentFragment();

        pageItems.forEach(item => {
            const card = document.createElement('div');
            card.className = 'col-sm-6 col-md-4 col-lg-4';
            card.innerHTML = `
                <div class="collection-row p-2 rounded bg-black bg-opacity-25 border border-secondary d-flex align-items-center justify-content-between">
                    <div class="d-flex align-items-center gap-2 overflow-hidden">
                        <span class="item-icon" style="width:64px;height:64px;">
                            <img src="/assets/img/items/${item.icon}.png" alt="${escapeHtml(item.name)}" loading="lazy" onerror="this.onerror=null;this.style.display='none';">
                        </span>
                        <div class="collection-info text-truncate">
                            <div class="fw-bold text-truncate" title="${escapeHtml(item.name)}">${escapeHtml(item.name)}</div>
                            <div class="text-secondary small">${escapeHtml(labels.itemId || 'ID do item')}: ${item.item_id} | TypeId: ${item.typeid}</div>
                        </div>
                    </div>

                    <div class="collection-actions d-flex gap-1 ms-2">
                        ${canManageItems ? `
                        <form action="update_warehouse.php" method="post">
                            <input type="hidden" name="csrf_token" value="${csrfToken}">
                            <input type="hidden" name="action" value="remove">
                            <input type="hidden" name="item_id" value="${item.item_id}">
                            <button type="submit" class="btn btn-sm btn-outline-danger" title="${escapeHtml(labels.remove)}"><i class="bi bi-dash-lg"></i></button>
                        </form>` : ''}
                    </div>
                </div>
            `;
            fragment.appendChild(card);
        });

        container.appendChild(fragment);
        renderPagination();
    }

    function getPaginationRange(current, total, delta = 2) {
        const range = [];
        for (let i = 1; i <= total; i++) {
            if (i === 1 || i === total || (i >= current - delta && i <= current + delta)) {
                range.push(i);
            }
        }

        const withDots = [];
        let last = null;
        for (const page of range) {
            if (last !== null) {
                if (page - last === 2) {
                    withDots.push(last + 1);
                } else if (page - last > 2) {
                    withDots.push('...');
                }
            }
            withDots.push(page);
            last = page;
        }
        return withDots;
    }

    function renderPagination() {
        if (!paginationEl) return;
        const totalPages = Math.ceil(filteredItems.length / itemsPerPage);
        paginationEl.innerHTML = '';

        if (totalPages <= 1) return;

        const prevLi = document.createElement('li');
        prevLi.className = `page-item ${currentPage === 1 ? 'disabled' : ''}`;
        prevLi.innerHTML = `<a class="page-link bg-dark text-white border-secondary" href="#">&laquo;</a>`;
        prevLi.addEventListener('click', (e) => {
            e.preventDefault();
            if (currentPage > 1) {
                currentPage--;
                renderItems();
            }
        });
        paginationEl.appendChild(prevLi);

        getPaginationRange(currentPage, totalPages).forEach((page) => {
            const li = document.createElement('li');

            if (page === '...') {
                li.className = 'page-item disabled';
                li.innerHTML = `<span class="page-link bg-dark text-white border-secondary">&hellip;</span>`;
                paginationEl.appendChild(li);
                return;
            }

            li.className = `page-item ${page === currentPage ? 'active' : ''}`;
            li.innerHTML = `<a class="page-link ${page === currentPage ? 'bg-primary' : 'bg-dark'} text-white border-secondary" href="#">${page}</a>`;
            li.addEventListener('click', (e) => {
                e.preventDefault();
                currentPage = page;
                renderItems();
            });
            paginationEl.appendChild(li);
        });

        const nextLi = document.createElement('li');
        nextLi.className = `page-item ${currentPage === totalPages ? 'disabled' : ''}`;
        nextLi.innerHTML = `<a class="page-link bg-dark text-white border-secondary" href="#">&raquo;</a>`;
        nextLi.addEventListener('click', (e) => {
            e.preventDefault();
            if (currentPage < totalPages) {
                currentPage++;
                renderItems();
            }
        });
        paginationEl.appendChild(nextLi);
    }

    if (searchInput) {
        searchInput.addEventListener('input', applyFilters);
    }

    if (categoryFiltersContainer) {
        categoryFiltersContainer.addEventListener('click', (e) => {
            const btn = e.target.closest('.category-btn');
            if (!btn) return;

            categoryFiltersContainer.querySelectorAll('.category-btn').forEach(b => {
                b.classList.remove('btn-primary', 'active');
                b.classList.add('btn-outline-secondary', 'text-light');
            });

            btn.classList.remove('btn-outline-secondary', 'text-light');
            btn.classList.add('btn-primary', 'active');

            currentCategory = btn.dataset.type;
            applyFilters();
        });
    }

    renderItems();
});
</script>
<?php require __DIR__ . '/../includes/footer.php'; ?>
