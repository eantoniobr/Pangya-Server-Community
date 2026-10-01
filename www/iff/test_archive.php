<?php
/**
 * test_archive.php
 * Diagnóstico visual da leitura do pacote IFF e busca de itens.
 */
require_once __DIR__ . '/generate_cache.php'; 
require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
use PangyaIFF\Parser\IFFArchive;

$isCli = PHP_SAPI === 'cli';

// Se executado via CLI, mantém o comportamento em texto simples
if ($isCli) {
    echo "=== " . (t('archive_test_title_banner') ?? 'Teste do pacote pangya_jp.iff') . " ===\n";
    $zipStatus = class_exists('ZipArchive') ? '✔ disponível' : '✘ NÃO disponível (habilite ext-zip)';
    echo "Extensão zip do PHP: {$zipStatus}\n";
    $archivePath = IFFArchive::getArchivePath();
    echo "Caminho configurado: {$archivePath}\n";
    echo "Arquivo existe: " . (is_file($archivePath) ? '✔ sim' : '✘ não encontrado') . "\n";
    exit;
}

// Execução via Navegador (Painel Visual)
$archivePath = IFFArchive::getArchivePath();
$zipLoaded = class_exists('ZipArchive');
$fileExists = is_file($archivePath);
$entries = $fileExists ? IFFArchive::listEntries() : [];

$expectedFiles = [
    'Card.iff', 'SetItem.iff', 'Part.iff', 'Item.iff', 
    'Skin.iff', 'ClubSet.iff', 'Character.iff', 'Caddie.iff', 
    'AuxPart.iff', 'Ball.iff', 'Mascot.iff'
];

// Teste de busca unitária (se informado via GET)
$testId = (int)($_GET['id'] ?? 0);
$foundItem = null;
if ($testId > 0) {
    $foundItem = find_cache($testId);
}

$pageTitle = t('iff_archive_test_title') ?? 'Teste de Leitura IFF';
require __DIR__ . '/../includes/header.php';
?>

<div class="row justify-content-center">
    <div class="col-lg-10">
        <div class="card p-4 p-md-5 bg-dark text-light border-0 shadow-sm">
            <h2 class="mb-1">📦 <?= htmlspecialchars(t('iff_archive_heading') ?? 'Diagnóstico de Arquivos IFF') ?></h2>
            <p class="text-secondary mb-4"><?= htmlspecialchars(t('iff_archive_subtitle') ?? 'Verificação do empacotamento ZIP, integridade dos arquivos e consulta de cache/type_id.') ?></p>

            <!-- Alerta geral de status -->
            <div class="alert <?= ($zipLoaded && $fileExists) ? 'alert-success' : 'alert-danger' ?>">
                <strong><?= ($zipLoaded && $fileExists) ? '✅ ' . htmlspecialchars(t('iff_status_ok') ?? 'Ambiente IFF Operacional') : '❌ ' . htmlspecialchars(t('iff_status_fail') ?? 'Atenção aos Requisitos IFF') ?></strong>
                — <?= htmlspecialchars(t('iff_status_desc') ?? 'verifique os detalhes da extensão e do arquivo compactado abaixo.') ?>
            </div>

            <!-- Tabela de Diagnóstico Principal -->
            <table class="table table-dark align-middle mb-4">
                <thead>
                    <tr>
                        <th style="width:40px;">#</th>
                        <th><?= htmlspecialchars(t('table_header_check') ?? 'Verificação') ?></th>
                        <th style="width:110px;"><?= htmlspecialchars(t('table_header_status') ?? 'Status') ?></th>
                        <th><?= htmlspecialchars(t('table_header_details') ?? 'Detalhes / Caminho') ?></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td><?= htmlspecialchars(t('check_zip_ext') ?? 'Extensão ZIP do PHP (ext-zip)') ?></td>
                        <td>
                            <?php if ($zipLoaded): ?>
                                <span class="badge bg-success"><?= htmlspecialchars(t('status_ok') ?? 'OK') ?></span>
                            <?php else: ?>
                                <span class="badge bg-danger"><?= htmlspecialchars(t('status_fail') ?? 'FALHA') ?></span>
                            <?php endif; ?>
                        </td>
                        <td class="small"><?= $zipLoaded ? ('OK — ZipArchive ' . htmlspecialchars(t('status_available') ?? 'disponível')) : 'Não encontrada. Habilite extension=zip no php.ini' ?></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td><?= htmlspecialchars(t('check_archive_path') ?? 'Caminho do Arquivo IFF') ?></td>
                        <td>
                            <?php if ($fileExists): ?>
                                <span class="badge bg-success"><?= htmlspecialchars(t('status_ok') ?? 'OK') ?></span>
                            <?php else: ?>
                                <span class="badge bg-danger"><?= htmlspecialchars(t('status_fail') ?? 'FALHA') ?></span>
                            <?php endif; ?>
                        </td>
                        <td class="small font-monospace"><code><?= htmlspecialchars($archivePath) ?></code></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td><?= htmlspecialchars(t('check_entries_count') ?? 'Total de arquivos internos no ZIP') ?></td>
                        <td>
                            <span class="badge bg-info text-dark"><?= count($entries) ?> arquivos</span>
                        </td>
                        <td class="small"><?= $fileExists ? 'Arquivo aberto e indexado com sucesso.' : 'N/A (Arquivo não encontrado)' ?></td>
                    </tr>
                </tbody>
            </table>

            <!-- Listagem de Arquivos Esperados -->
            <h5 class="fw-bold mb-3">🔍 <?= htmlspecialchars(t('expected_files_heading') ?? 'Validação de Componentes IFF Esperados') ?></h5>
            <div class="row g-2 mb-4">
                <?php foreach ($expectedFiles as $expected): 
                    $found = IFFArchive::has($expected);
                ?>
                    <div class="col-md-4">
                        <div class="p-2 border border-secondary rounded bg-secondary bg-opacity-10 d-flex justify-content-between align-items-center">
                            <span class="font-monospace small"><?= $expected ?></span>
                            <span><?= $found ? '✔ <span class="text-success small">OK</span>' : '✘ <span class="text-danger small">Ausente</span>' ?></span>
                        </div>
                    </div>
                <?php endforeach; ?>
            </div>

            <hr class="border-secondary my-4">

            <!-- Formulário de Teste de Busca (find_cache) -->
            <h5 class="fw-bold mb-3">⚡ <?= htmlspecialchars(t('test_item_search_heading') ?? 'Teste de Busca de Item (find_cache / Type ID)') ?></h5>
            <form method="GET" action="" class="row g-3 align-items-center mb-3">
                <div class="col-auto">
                    <label for="id" class="col-form-label"><?= htmlspecialchars(t('label_type_id') ?? 'Digite o Type ID:') ?></label>
                </div>
                <div class="col-auto">
                    <input type="number" id="id" name="id" class="form-control bg-secondary text-light border-0" value="<?= $testId > 0 ? $testId : '' ?>" placeholder="Ex: 10001">
                </div>
                <div class="col-auto">
                    <button type="submit" class="btn btn-primary"><?= htmlspecialchars(t('btn_test_search') ?? 'Testar Busca') ?></button>
                </div>
            </form>

            <?php if ($testId > 0): ?>
                <div class="p-3 rounded bg-black bg-opacity-50 border border-secondary">
                    <?php if ($foundItem): ?>
                        <h6 class="text-success fw-bold mb-2">✔ Item Encontrado com Sucesso!</h6>
                        <ul class="list-unstyled small mb-0 text-secondary">
                            <li><strong>ID / Type ID:</strong> <span class="text-light"><?= htmlspecialchars($foundItem['item_id'] ?? $testId) ?></span></li>
                            <li><strong>Nome:</strong> <span class="text-light fw-bold"><?= htmlspecialchars($foundItem['item_name'] ?? '(sem nome)') ?></span></li>
                            <li><strong>Fonte / Arquivo:</strong> <span class="text-info"><?= htmlspecialchars($foundItem['_source'] ?? '?') ?></span></li>
                        </ul>
                    <?php else: ?>
                        <h6 class="text-danger fw-bold mb-0">✘ Item com ID <?= $testId ?> NÃO foi encontrado em nenhum arquivo IFF ou cache.</h6>
                    <?php endif; ?>
                </div>
            <?php endif; ?>

            <div class="alert alert-warning mt-4 mb-0">
                ⚠️ <?= htmlspecialchars(t('security_warning_test_file') ?? 'Este arquivo expõe detalhes técnicos do servidor. Apague-o ou bloqueie o acesso assim que terminar os testes.') ?>
            </div>
        </div>
    </div>
</div>

<?php require __DIR__ . '/../includes/footer.php'; ?>