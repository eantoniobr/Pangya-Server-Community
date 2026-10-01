<?php
/**
 * test_connection.php
 */
require_once __DIR__ . '/Config/config.php';

$steps = []; // cada item: ['label' => string, 'ok' => bool, 'detail' => string]

function addStep(array &$steps, string $label, bool $ok, string $detail = ''): void
{
    $steps[] = ['label' => $label, 'ok' => $ok, 'detail' => $detail];
}

// -------------------------------------------------------------------
// 1. Extensão PDO_ODBC carregada?
// -------------------------------------------------------------------
$pdoOdbcLoaded = extension_loaded('pdo_odbc');
addStep(
    $steps,
    t('step_pdo_odbc_label') ?? 'Extensão PHP pdo_odbc habilitada',
    $pdoOdbcLoaded,
    $pdoOdbcLoaded
        ? (t('ok_php_version') ?? 'OK — versão PHP ') . PHP_VERSION
        : (t('pdo_odbc_not_found') ?? 'Não encontrada. Habilite "extension=pdo_odbc" no php.ini e reinicie o servidor web.')
);

// -------------------------------------------------------------------
// 2. Drivers PDO disponíveis (deve conter "odbc")
// -------------------------------------------------------------------
$drivers = PDO::getAvailableDrivers();
$hasOdbcDriver = in_array('odbc', $drivers, true);
addStep(
    $steps,
    t('step_driver_odbc_label') ?? 'Driver "odbc" disponível no PDO',
    $hasOdbcDriver,
    (t('installed_pdo_drivers') ?? 'Drivers PDO instalados: ') . (empty($drivers) ? (t('none') ?? '(nenhum)') : implode(', ', $drivers))
);

// -------------------------------------------------------------------
// 3. Tenta abrir a conexão via getConnection() (config.php)
// -------------------------------------------------------------------
$pdo = null;
$connectionOk = false;
$connectionDetail = '';

if ($pdoOdbcLoaded && $hasOdbcDriver) {
    try {
        $pdo = getConnection();
        $connectionOk = true;
        $connectionDetail = (t('connection_success_dsn') ?? 'Conexão aberta com sucesso usando o DSN "') . DSN_NAME . '".';
    } catch (PDOException $e) {
        $connectionDetail = (t('connection_failed') ?? 'Falha ao conectar: ') . $e->getMessage();
    }
} else {
    $connectionDetail = t('step_skipped_prerequisites') ?? 'Etapa pulada — pré-requisitos acima não atendidos.';
}

addStep($steps, (t('pdo_odbc_connection_dsn') ?? 'Conexão PDO ODBC com o System DSN "') . DSN_NAME . '"', $connectionOk, $connectionDetail);

// -------------------------------------------------------------------
// 4. Query simples de sanidade (SELECT 1)
// -------------------------------------------------------------------
$pingOk = false;
$pingDetail = '';

if ($connectionOk) {
    try {
        $result = $pdo->query('SELECT 1 AS ping')->fetch();
        $pingOk = isset($result['ping']) && (int)$result['ping'] === 1;
        $pingDetail = $pingOk ? (t('select_1_success') ?? 'SELECT 1 executado com sucesso.') : (t('unexpected_db_response') ?? 'Resposta inesperada do banco.');
    } catch (PDOException $e) {
        $pingDetail = (t('select_1_error') ?? 'Erro ao executar SELECT 1: ') . $e->getMessage();
    }
} else {
    $pingDetail = t('step_skipped_no_connection') ?? 'Etapa pulada — conexão não estabelecida.';
}

addStep($steps, t('sanity_query_label') ?? 'Consulta de sanidade (SELECT 1)', $pingOk, $pingDetail);

// -------------------------------------------------------------------
// 5. Identifica o servidor/banco atual e a versão do SQL Server
// -------------------------------------------------------------------
$serverInfoOk = false;
$serverInfoDetail = '';

if ($pingOk) {
    try {
        $row = $pdo->query('SELECT DB_NAME() AS db_name, @@SERVERNAME AS server_name, @@VERSION AS version')->fetch();
        $serverInfoOk = true;
        $serverInfoDetail = sprintf(
            t('server_info_format') ?? 'Banco: %s | Servidor: %s | Versão: %s',
            $row['db_name'] ?? '?',
            $row['server_name'] ?? '?',
            isset($row['version']) ? strtok($row['version'], "\n") : '?'
        );
    } catch (PDOException $e) {
        $serverInfoDetail = (t('server_info_error') ?? 'Erro ao obter informações do servidor: ') . $e->getMessage();
    }
} else {
    $serverInfoDetail = t('step_skipped_sanity_failed') ?? 'Etapa pulada — consulta de sanidade falhou.';
}

addStep($steps, t('sql_server_info_label') ?? 'Informações do servidor SQL Server', $serverInfoOk, $serverInfoDetail);

// -------------------------------------------------------------------
// 6. Verifica se as tabelas/procedures-chave do projeto existem
// -------------------------------------------------------------------
$objectsOk = false;
$objectsDetail = '';
$expectedObjects = [
    'pangya.account'                     => 'U',  // tabela
    'pangya.contas_beta'                 => 'U',  // tabela
    'pangya.pangya_item_warehouse'       => 'U',  // tabela
    'pangya.ProcMakeUserBeta'            => 'P',  // procedure
    'pangya.ProcAutoItem'                => 'P',  // procedure
];

if ($serverInfoOk) {
    try {
        $found = [];
        $stmt = $pdo->prepare("SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(?) AND type = ?");
        foreach ($expectedObjects as $objName => $type) {
            $stmt->execute([$objName, $type]);
            $found[$objName] = (bool)$stmt->fetchColumn();
        }
        $objectsOk = !in_array(false, $found, true);
        $lines = [];
        foreach ($found as $objName => $exists) {
            $lines[] = ($exists ? '✔ ' : '✘ ') . $objName;
        }
        $objectsDetail = implode(' | ', $lines);
    } catch (PDOException $e) {
        $objectsDetail = (t('object_check_error') ?? 'Erro ao verificar objetos: ') . $e->getMessage();
    }
} else {
    $objectsDetail = t('step_skipped_server_unavailable') ?? 'Etapa pulada — informações do servidor indisponíveis.';
}

addStep($steps, t('expected_tables_procedures_label') ?? 'Tabelas e procedures esperadas existem no banco', $objectsOk, $objectsDetail);

$pageTitle = t('connection_test_title') ?? 'Teste de Conexão';
require __DIR__ . '/includes/header.php';
?>

<div class="row justify-content-center">
    <div class="col-lg-9">
        <div class="card p-4 p-md-5">
            <h2 class="mb-1"><?= htmlspecialchars(t('connection_test_heading') ?? 'Teste de Conexão PHP + SQL Server') ?></h2>
            <p class="text-secondary mb-4"><?= htmlspecialchars(t('connection_test_subtitle') ?? 'Diagnóstico via PDO_ODBC / System DSN.') ?></p>

            <div class="alert <?= $connectionOk ? 'alert-success' : 'alert-danger' ?>">
                <strong><?= $connectionOk ? ('✅ ' . (t('connection_working') ?? 'Conexão funcionando')) : ('❌ ' . (t('connection_failed_status') ?? 'Conexão com falha')) ?></strong>
                — <?= htmlspecialchars(t('check_steps_details_below') ?? 'verifique os detalhes de cada etapa abaixo.') ?>
            </div>

            <table class="table table-dark align-middle">
                <thead>
                    <tr>
                        <th style="width:40px;">#</th>
                        <th><?= htmlspecialchars(t('table_header_step') ?? 'Etapa') ?></th>
                        <th style="width:90px;"><?= htmlspecialchars(t('table_header_status') ?? 'Status') ?></th>
                        <th><?= htmlspecialchars(t('table_header_details') ?? 'Detalhes') ?></th>
                    </tr>
                </thead>
                <tbody>
                <?php foreach ($steps as $i => $step): ?>
                    <tr>
                        <td><?= $i + 1 ?></td>
                        <td><?= htmlspecialchars($step['label']) ?></td>
                        <td>
                            <?php if ($step['ok']): ?>
                                <span class="badge bg-success"><?= htmlspecialchars(t('status_ok') ?? 'OK') ?></span>
                            <?php else: ?>
                                <span class="badge bg-danger"><?= htmlspecialchars(t('status_fail') ?? 'FALHA') ?></span>
                            <?php endif; ?>
                        </td>
                        <td class="small"><?= htmlspecialchars($step['detail']) ?></td>
                    </tr>
                <?php endforeach; ?>
                </tbody>
            </table>

            <div class="alert alert-warning mt-4 mb-0">
                ⚠️ <?= htmlspecialchars(t('security_warning_test_file') ?? 'Este arquivo expõe detalhes técnicos do servidor. Apague-o ou bloqueie o acesso (ex.: .htaccess) assim que terminar os testes.') ?>
            </div>
        </div>
    </div>
</div>

<?php require __DIR__ . '/includes/footer.php'; ?>