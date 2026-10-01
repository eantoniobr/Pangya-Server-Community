<?php
require_once __DIR__ . '/Config/config.php';
require_once __DIR__ . '/includes/functions.php';

$pageTitle = t('home');

// Consulta as informações do servidor direto no banco de dados
$serverInfo = null;

try {

    $sql = '
        SELECT 
            CONVERT(
                VARCHAR(MAX),
                CAST(pangya_server_list.[Name] AS VARBINARY(MAX)),
                2
            ) AS [Name_HEX],

            pangya_server_list.[UID], 
            pangya_server_list.[IP], 
            pangya_server_list.[Port], 
            pangya_server_list.MaxUser, 
            pangya_server_list.CurrUser, 
            pangya_server_list.property, 
            pangya_server_list.AngelicWingsNum, 
            pangya_server_list.EventFlag, 
            pangya_server_list.EventMap, 
            pangya_server_list.ImgNo, 
            pangya_server_list.AppRate, 
            pangya_server_list.ScratchRate

        FROM pangya.pangya_server_list

        WHERE 
            pangya_server_list.[Type] = 1 AND 
            pangya_server_list.UpdateTime > dateadd(second, -8, getdate()) AND 
            pangya_server_list.[State] = 1
    ';

    $pdo = getConnection();

    $stmt = $pdo->query($sql);

    $serverInfo = $stmt->fetch(PDO::FETCH_ASSOC);

    // ---------------------------------------------------------
    // Converte o Name armazenado em UTF-16LE para UTF-8
    // ---------------------------------------------------------
    if ($serverInfo && !empty($serverInfo['Name_HEX'])) {

        $nameBytes = hex2bin($serverInfo['Name_HEX']);

        if ($nameBytes !== false) {

            $serverInfo['Name'] = mb_convert_encoding(
                $nameBytes,
                'UTF-8',
                'UTF-16LE'
            );
        } else {

            $serverInfo['Name'] = '';
        }

        // Não precisamos mais do HEX depois da conversão
        unset($serverInfo['Name_HEX']);
    }

} catch (PDOException $e) {

    error_log(
        'Erro ao buscar lista de servidores: ' . $e->getMessage()
    );
}

$newsPreview = [];
try {
    require_once __DIR__ . '/includes/NewsService.php';
    $newsPreview = (new NewsService())->listPublished(1, 3);
} catch (PDOException $e) {
    error_log('Prévia de notícias na home: ' . $e->getMessage());
}

require __DIR__ . '/includes/header.php';
?>

<!-- Hero Banner -->
<div class="hero-banner rounded-3 mb-4">
    <div class="hero-overlay p-5">
        <h1 class="display-6 fw-bold"><?= htmlspecialchars(t('welcome')) ?></h1>
        <p class="col-md-8 fs-5"><?= htmlspecialchars(t('hero')) ?></p>
        
        <div class="d-flex flex-wrap gap-2 mt-3 align-items-center">
            <?php if (isLoggedIn()): ?>
                <a class="btn btn-primary btn-lg" href="Account/dashboard.php">
                    <?= htmlspecialchars(t('dashboard')) ?>
                </a>
            <?php else: ?>
                <a class="btn btn-primary btn-lg" href="Account/register.php">
                    <?= htmlspecialchars(t('create_account')) ?>
                </a>
            <?php endif; ?>

            <a class="btn btn-outline-light btn-lg" href="downloads.php">
                <?= htmlspecialchars(t('download_game')) ?>
            </a>

            <a class="btn btn-dark btn-lg border-secondary d-flex align-items-center gap-2" href="https://github.com/luismk/Pangya-Server-Community" target="_blank" rel="noopener noreferrer">
                <span>💻 GitHub</span>
            </a>

            <!-- Leva direto pra página de doações (checkout transparente MP + PayPal) -->
            <a href="<?= isLoggedIn() ? 'Shop/ShopCash.php' : 'Account/login.php' ?>" class="btn btn-warning btn-lg fw-bold text-dark d-flex align-items-center gap-2">
                ☕ <?= htmlspecialchars(t('support_server') ?? 'Apoie o servidor') ?>
            </a>
        </div>
    </div>
</div>

<!-- Banner de Eventos -->
<div id="communityCarousel" class="carousel slide rounded-3 mb-5 shadow" data-bs-ride="carousel">
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#communityCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#communityCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#communityCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
    </div>

    <div class="carousel-inner rounded-3">
        <div class="carousel-item active">
            <img src="assets/img/bg/beach-event-banner.jpg" class="d-block w-100 rounded-3" alt="<?= htmlspecialchars(t('beach_event_alt') ?? 'Evento de Praia') ?>">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                <h5><?= htmlspecialchars(t('carousel_title_1') ?? 'Pangya Community - Evento de Verão') ?></h5>
                <p><?= htmlspecialchars(t('carousel_desc_1') ?? 'Participe dos eventos exclusivos da temporada na comunidade.') ?></p>
            </div>
        </div>

        <div class="carousel-item">
            <img src="assets/img/bg/beach-event-banner.jpg" class="d-block w-100 rounded-3" alt="<?= htmlspecialchars(t('server_news_alt') ?? 'Novidades do Servidor') ?>">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                <h5><?= htmlspecialchars(t('carousel_title_2') ?? 'Atualizações e Ferramentas') ?></h5>
                <p><?= htmlspecialchars(t('carousel_desc_2') ?? 'Explore o PangYa Suite Tools e gerencie seus arquivos IFF com facilidade.') ?></p>
            </div>
        </div>

        <div class="carousel-item">
            <img src="assets/img/bg/beach-event-banner.jpg" class="d-block w-100 rounded-3 bg-secondary" alt="<?= htmlspecialchars(t('open_source_alt') ?? 'Comunidade Open Source') ?>">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded p-2">
                <h5><?= htmlspecialchars(t('carousel_title_3') ?? 'Código Aberto') ?></h5>
                <p><?= htmlspecialchars(t('carousel_desc_3') ?? 'Contribua com o projeto no nosso repositório oficial do GitHub.') ?></p>
            </div>
        </div>
    </div>

    <button class="carousel-control-prev" type="button" data-bs-target="#communityCarousel" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden"><?= htmlspecialchars(t('previous') ?? 'Anterior') ?></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#communityCarousel" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden"><?= htmlspecialchars(t('next') ?? 'Próximo') ?></span>
    </button>
</div>

<!-- Status do Servidor -->
<div class="row g-4 mb-5">
    <div class="col-md-5">
        <div class="card h-100 p-4 border-0 bg-dark text-light shadow-sm">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h6 class="text-uppercase text mb-0"><img src="assets/img/bar/bar_server.png" alt="PangYa Community" height="42"><?= htmlspecialchars(t('server_status')) ?></h6>
                <?php if ($serverInfo): ?>
                    <span class="badge bg-success"><img src="assets/img/bar/bar_online.gif" alt="PangYa Community" height="10" style="margin-right: 4px;margin-top: -4px;"><?= htmlspecialchars(t('online')) ?></span>
                <?php else: ?>
                    <span class="badge bg-danger"><img src="assets/img/bar/bar_offline.gif" alt="PangYa Community" height="10" style="margin-right: 4px;margin-top: -4px;"><?= htmlspecialchars(t('offline')) ?></span>
                <?php endif; ?>
            </div>

            <h3 class="fw-bold mb-1">
            <?= htmlspecialchars($serverInfo['Name'] ?? (t('game_server_offline') ?? 'Game Server no Running')) ?>
            </h3>
            <p class="text small mb-3">
                IP: <?= htmlspecialchars($serverInfo['IP'] ?? '127.0.0.1') ?>:<?= htmlspecialchars($serverInfo['Port'] ?? '20301') ?>
            </p>

            <div class="border-top border-secondary pt-3 mt-2">
                <div class="d-flex justify-content-between small mb-2">
                    <span><?= htmlspecialchars(t('players_online')) ?></span>
                    <span class="fw-bold text-info">
                        <?= htmlspecialchars($serverInfo['CurrUser'] ?? '0') ?> / <?= htmlspecialchars($serverInfo['MaxUser'] ?? '2000') ?>
                    </span>
                </div>
                <div class="d-flex justify-content-between small mb-2">
                    <span><?= htmlspecialchars(t('pang_exp_rate') ?? 'Taxa Pang / EXP (AppRate):') ?></span>
                    <span class="fw-bold text-warning">
                        <?= htmlspecialchars($serverInfo['AppRate'] ?? '0') ?>%
                    </span>
                </div>
                <div class="d-flex justify-content-between small">
                    <span><?= htmlspecialchars(t('scratch_rate') ?? 'Taxa Scratch (Papel Shop):') ?></span>
                    <span class="fw-bold text-warning">
                        <?= htmlspecialchars($serverInfo['ScratchRate'] ?? '100') ?>%
                    </span>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-7">
        <div class="card h-100 p-4 border-0 bg-dark text-light shadow-sm">
            <h5 class="fw-bold mb-3">🛠️ <?= htmlspecialchars(t('open_source')) ?></h5>
            <p class="text">
                <?= htmlspecialchars(t('open_source_text')) ?>
            </p>
 
            <div class="row mt-4">
                <div class="col-12 mb-3">
                    <div class="ratio ratio-16x9">
                        <iframe src="https://www.youtube.com/embed/eQ_2-_OXpL4" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    </div>
                </div>
                 
                <div class="col-12 text-center">
                    <script src="https://apis.google.com/js/platform.js"></script>
                    <div class="g-ytsubscribe" 
                         data-channelid="UCVF6-TAC1WW5eB-C9eBI31g" 
                         data-layout="full" 
                         data-count="default">
                    </div>
                    <p class="mt-2 text small"><?= htmlspecialchars(t('follow_updates')) ?></p>
                </div>
            </div>

            <div class="d-flex flex-wrap gap-2 mt-auto pt-3 justify-content-center">
                <a href="https://github.com/luismk/Pangya-Server-Community" target="_blank" rel="noopener noreferrer" class="btn btn-sm btn-outline-light">
                    📦 <?= htmlspecialchars(t('server_repository')) ?>
                </a>
                <a href="https://github.com/luismk/PangYa-Suite-Tools" target="_blank" rel="noopener noreferrer" class="btn btn-sm btn-outline-light">
                    🔧 PangYa Suite Tools
                </a>
                <a href="https://github.com/luismk/Pangya-Server-Community/issues" target="_blank" rel="noopener noreferrer" class="btn btn-sm btn-outline-warning">
                    🐛 <?= htmlspecialchars(t('report_issue')) ?>
                </a>
                <a href="test_connection.php" class="btn btn-sm btn-outline-info">
                    <i class="bi bi-database-check me-1"></i> <?= htmlspecialchars(t('test_connection')) ?>
                </a>
                <a href="iff/test_archive.php" class="btn btn-sm btn-outline-warning">
                    <i class="bi bi-file-earmark-binary me-1"></i> <?= htmlspecialchars(t('test_iff_reading') ?? 'Testar Leitura IFF') ?>
                </a>
                <a href="<?= isLoggedIn() ? 'Shop/ShopCash.php' : 'Account/login.php' ?>" class="btn btn-sm btn-warning text-dark fw-bold">
                    ☕ <?= htmlspecialchars(t('support_server') ?? 'Apoie o servidor') ?>
                </a>
            </div>
        </div>
    </div>
</div>

<!-- Destaques -->
<div class="row g-4 mb-5">
    <div class="col-md-4">
        <div class="card h-100 p-3">
            <h5>⛳ <?= htmlspecialchars(t('classic')) ?></h5>
            <p class="mb-0 text"><?= htmlspecialchars(t('classic_text')) ?></p>
        </div>
    </div>
    
    <div class="col-md-4">
        <div class="card h-100 p-3">
            <h5>🤝 <?= htmlspecialchars(t('community')) ?></h5>
            <p class="mb-0 text"><?= htmlspecialchars(t('community_text')) ?></p>
        </div>
    </div>
    
    <div class="col-md-4">
        <div class="card h-100 p-3">
            <h5>🎁 <?= htmlspecialchars(t('starter_items')) ?></h5>
            <p class="mb-0 text"><?= htmlspecialchars(t('starter_items_text')) ?></p>
        </div>
    </div>
</div>

<!-- Como Jogar -->
<div class="card p-4 p-md-5 mb-5 border-0 bg-dark text-light">
    <h3 class="text-center fw-bold mb-4">🚀 <?= htmlspecialchars(t('how_to_play_title') ?? 'Como começar a jogar?') ?></h3>
    <div class="row text-center g-4">
        <div class="col-md-4">
            <div class="p-3">
                <div class="display-5 text-primary fw-bold mb-2">1</div>
                <h5 class="fw-bold"><?= htmlspecialchars(t('how_to_play_step1_title') ?? 'Crie sua conta') ?></h5>
                <p class="text small"><?= htmlspecialchars(t('how_to_play_step1_desc') ?? 'Cadastre-se no painel em menos de 1 minuto para obter seu acesso ao jogo.') ?></p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="p-3">
                <div class="display-5 text-primary fw-bold mb-2">2</div>
                <h5 class="fw-bold"><?= htmlspecialchars(t('how_to_play_step2_title') ?? 'Baixe o Cliente') ?></h5>
                <p class="text small"><?= htmlspecialchars(t('how_to_play_step2_desc') ?? 'Acesse a aba de downloads e baixe o cliente completo com o patch instalado.') ?></p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="p-3">
                <div class="display-5 text-primary fw-bold mb-2">3</div>
                <h5 class="fw-bold"><?= htmlspecialchars(t('how_to_play_step3_title') ?? 'Entre em Campo') ?></h5>
                <p class="text small"><?= htmlspecialchars(t('how_to_play_step3_desc') ?? 'Execute o jogo, faça login com a conta criada e resgate seus itens iniciais!') ?></p>
            </div>
        </div>
    </div>
    <div class="text-center mt-3">
        <a href="Account/register.php" class="btn btn-primary btn-lg"><?= htmlspecialchars(t('create_account')) ?></a>
    </div>
</div>

<!-- Últimas Notícias -->
<?php if (!empty($newsPreview)): ?>
<div class="mb-5">
    <div class="d-flex justify-content-between align-items-center mb-3">
        <h3 class="fw-bold text-white mb-0">📰 <?= htmlspecialchars(t('news')) ?></h3>
        <a href="noticias.php" class="btn btn-sm btn-outline-light"><?= htmlspecialchars(t('view_all') ?? 'Ver todas') ?></a>
    </div>
    <div class="row g-4">
        <?php foreach ($newsPreview as $item): ?>
            <div class="col-md-4">
                <a href="noticias.php?n=<?= urlencode($item['slug']) ?>" class="text-decoration-none">
                    <div class="card h-100 bg-dark text-light border-secondary">
                        <?php if (!empty($item['cover_image'])): ?>
                            <img src="<?= htmlspecialchars($item['cover_image']) ?>" class="card-img-top" style="height:160px;object-fit:cover;" alt="">
                        <?php endif; ?>
                        <div class="card-body">
                            <div class="text-secondary small mb-1"><?= htmlspecialchars((new DateTime($item['created_at']))->format('d/m/Y')) ?></div>
                            <h6 class="fw-bold mb-1"><?= htmlspecialchars($item['title']) ?></h6>
                            <?php if (!empty($item['summary'])): ?>
                                <p class="small text-secondary mb-0"><?= htmlspecialchars($item['summary']) ?></p>
                            <?php endif; ?>
                        </div>
                    </div>
                </a>
            </div>
        <?php endforeach; ?>
    </div>
</div>
<?php endif; ?>

<?php require __DIR__ . '/includes/footer.php'; ?>