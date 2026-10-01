<?php
/**
 * process_register.php
 * -----------------------------------------------------------------------
 * Recebe o POST de register.php, valida os campos, gera o hash de senha,
 * captura o IP do cliente e executa, nesta ordem:
 *
 *   1) [pangya].[ProcMakeUserBeta]  -> cria a conta e retorna o UID
 *   2) [pangya].[ProcAutoItem]      -> distribui os itens iniciais para o UID
 *
 * ProcAutoItem só é chamada se ProcMakeUserBeta realmente CRIOU uma conta
 * nova (e não apenas retornou o UID de uma conta já existente), evitando
 * distribuir itens duplicados para quem já possui cadastro.
 * -----------------------------------------------------------------------
 */
require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';

redirectIfLoggedIn();

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    header('Location: register.php');
    exit;
}

// ---------------------------------------------------------------------
// 1. Captura e sanitiza os campos do formulário
// ---------------------------------------------------------------------
$NomeCompleto  = clean($_POST['NomeCompleto'] ?? '');
$BirthdayRaw   = clean($_POST['Birthday'] ?? '');
$Sexo          = filter_var($_POST['Sexo'] ?? '', FILTER_VALIDATE_INT);
$Pergunta      = clean($_POST['Pergunta'] ?? '');
$Resposta      = clean($_POST['Resposta'] ?? '');
$email_in      = clean($_POST['email_in'] ?? '');
$id_in         = clean($_POST['id_in'] ?? '');
$pass_in_plain = (string)($_POST['pass_in'] ?? '');
$Referrer_Code = clean($_POST['Referrer_Code'] ?? '');

// Campos obrigatórios segundo o desafio
$errors = [];

if ($NomeCompleto === '')                      $errors[] = 'Nome completo é obrigatório.';
if ($Sexo === false || $Sexo === null)         $errors[] = 'Sexo é obrigatório.';
if ($Pergunta === '')                          $errors[] = 'Pergunta de segurança é obrigatória.';
if (!filter_var($email_in, FILTER_VALIDATE_EMAIL)) $errors[] = 'E-mail inválido.';
// pangya.account.ID é varchar(25) — respeita o limite da coluna
if ($id_in === '' || !preg_match('/^[A-Za-z0-9_]{3,25}$/', $id_in)) {
    $errors[] = 'ID/Usuário inválido (use apenas letras, números e underline, 3-25 caracteres).';
}
if (strlen($pass_in_plain) < 4) $errors[] = 'Senha deve ter ao menos 4 caracteres.';

if (!empty($errors)) {
    setFlash('error', implode(' ', $errors));
    header('Location: register.php');
    exit;
}

// Data de nascimento é opcional
$Birthday = $BirthdayRaw !== '' ? $BirthdayRaw : null;

// Resposta de segurança é opcional
$Resposta = $Resposta !== '' ? $Resposta : null;

// Código de indicação é opcional
$Referrer_Code = $Referrer_Code !== '' ? $Referrer_Code : null;

// Senha: MD5 em maiúsculas, conforme regra de negócio
$pass_in = hashPassword($pass_in_plain);

// IP do cliente
$ip_in = getClientIp();

try {
    $pdo = getConnection();

   // -------------------------------------------------------------
    // 2. Verifica previamente se o ID ou E-mail já existem
    // -------------------------------------------------------------
    $checkStmt = $pdo->prepare('
        SELECT 
            (SELECT COUNT(*) FROM pangya.account WHERE ID = ?) AS id_exists,
            (SELECT COUNT(*) FROM pangya.contas_beta WHERE Email = ?) AS email_exists
    ');
    $checkStmt->execute([$id_in, $email_in]);
    $result = $checkStmt->fetch(PDO::FETCH_ASSOC);

    if ((int)$result['id_exists'] > 0) {
        setFlash('error', 'Este ID de usuário já está em uso. Escolha outro ou faça login.');
        header('Location: register.php');
        exit;
    }

    if ((int)$result['email_exists'] > 0) {
        setFlash('error', 'Este E-mail já está cadastrado. Escolha outro ou faça login.');
        header('Location: register.php');
        exit;
    }
	
    // -------------------------------------------------------------
    // 3. Passo 1: executa ProcMakeUserBeta e captura o UID retornado
    // -------------------------------------------------------------
    $stmt = $pdo->prepare(
        '{CALL pangya.ProcMakeUserBeta (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)}'
    );

    $stmt->bindValue(1, $NomeCompleto, PDO::PARAM_STR);
    $stmt->bindValue(2, $Birthday, $Birthday === null ? PDO::PARAM_NULL : PDO::PARAM_STR);
    $stmt->bindValue(3, $Sexo, PDO::PARAM_INT);
    $stmt->bindValue(4, $Pergunta, PDO::PARAM_STR);
    $stmt->bindValue(5, $Resposta, $Resposta === null ? PDO::PARAM_NULL : PDO::PARAM_STR);
    $stmt->bindValue(6, $email_in, PDO::PARAM_STR);
    $stmt->bindValue(7, $id_in, PDO::PARAM_STR);
    $stmt->bindValue(8, $pass_in, PDO::PARAM_STR);
    $stmt->bindValue(9, $ip_in, PDO::PARAM_STR);
    $stmt->bindValue(10, $Referrer_Code, $Referrer_Code === null ? PDO::PARAM_NULL : PDO::PARAM_STR);

    $stmt->execute();

    $newUid = (int)$stmt->fetchColumn();

    if ($newUid <= 0) {
        setFlash('error', 'Não foi possível criar sua conta. Tente novamente em instantes.');
        header('Location: register.php');
        exit;
    }
	
// -------------------------------------------------------------
    // Inserção na tabela contas_beta
    // -------------------------------------------------------------
    $sql = "INSERT INTO [pangya].[contas_beta] (
	    [UID],
        [NomeCompleto],
        [Birthday],
        [Email],
        [Sexo],
        [Pergunta],
        [Resposta],
        [LoginID],
        [Senha],
        [ip_register],
        [referrer_code],
        [Inviter_UID],
        [Invited],
        [status_referal]
    ) VALUES (
        ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, NULL, NULL, 0, '0'
    )";

    $stmt = $pdo->prepare($sql);
	$stmt->bindValue(1, $newUid, PDO::PARAM_INT);
    $stmt->bindValue(2, $NomeCompleto, PDO::PARAM_STR);
    $stmt->bindValue(3, $Birthday, $Birthday === null ? PDO::PARAM_NULL : PDO::PARAM_STR);
    $stmt->bindValue(4, $email_in, PDO::PARAM_STR);
    $stmt->bindValue(5, $Sexo, PDO::PARAM_INT);
    $stmt->bindValue(6, $Pergunta, PDO::PARAM_STR);
    $stmt->bindValue(7, $Resposta, $Resposta === null ? PDO::PARAM_NULL : PDO::PARAM_STR);
    $stmt->bindValue(8, $id_in, PDO::PARAM_STR);
    $stmt->bindValue(9, $pass_in, PDO::PARAM_STR);
    $stmt->bindValue(10, $ip_in, PDO::PARAM_STR);

    $stmt->execute();
    // -------------------------------------------------------------
    // 4. Passo 2: com o UID retornado, executa ProcAutoItem
    // -------------------------------------------------------------
    $itemStmt = $pdo->prepare('{CALL pangya.ProcAutoItem (?)}');
    $itemStmt->bindValue(1, $newUid, PDO::PARAM_INT);
    $itemStmt->execute();

    // -------------------------------------------------------------
    // 5. Sucesso: loga o usuário automaticamente e vai para o painel
    // -------------------------------------------------------------
    $_SESSION['uid']      = $newUid;
    $_SESSION['login_id'] = $id_in;

    setFlash('success', 'Conta criada com sucesso! Bem-vindo(a) ao PangYa Community.');
    header('Location: dashboard.php');
    exit;

} catch (PDOException $e) {
    // Exibe a mensagem, o arquivo e a linha exata do erro
    echo '<strong>Erro:</strong> ' . $e->getMessage() . '<br>';
    echo '<strong>Arquivo:</strong> ' . $e->getFile() . '<br>';
    echo '<strong>Linha:</strong> ' . $e->getLine() . '<br><br>';

    // Exibe o histórico de execução até o erro
    echo '<pre>';
    print_r($e->getTraceAsString());
    echo '</pre>';

    // Interrompe a execução para você visualizar no navegador
    exit;
}
