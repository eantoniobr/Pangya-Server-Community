<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/ServerMetrics.php';

$metrics = [
    'registered' => 0,
    'online' => 0,
    'login_online' => false,
    'game_online' => false,
    'pang_rate' => 0,
    'exp_rate' => 0,
    'peak_online' => 0,
];

try {
    $metrics = (new ServerMetrics(getConnection()))->snapshot();
} catch (PDOException $exception) {
    error_log('Página de status do servidor: ' . $exception->getMessage());
}

$pageTitle = t('server_page');
require __DIR__ . '/../includes/header.php';
?>

<style>
    /* 1. Garante que o Footer fique no final da página (Sticky Footer) */
    html, body {
        height: 100%;
    }
    body {
        display: flex;
        flex-direction: column;
        min-height: 100vh;
    }
    .main-content {
        flex: 1 0 auto; /* Empurra o footer pra baixo */
    }

    /* 2. Estilização dos Cards Principais */
    .card-status {
        border: none;
        border-radius: 16px;
        background: #ffffff;
        box-shadow: 0 10px 30px rgba(0, 0, 0, 0.08);
        transition: transform 0.25s ease, box-shadow 0.25s ease;
        overflow: hidden;
    }
    .card-status:hover {
        transform: translateY(-4px);
        box-shadow: 0 15px 35px rgba(0, 0, 0, 0.12);
    }
    
    /* Indicador de status pulsante */
    .status-pulse {
        width: 10px;
        height: 10px;
        border-radius: 50%;
        display: inline-block;
        margin-right: 8px;
    }
    .status-pulse.online {
        background-color: #10b981;
        box-shadow: 0 0 0 0 rgba(16, 185, 129, 0.7);
        animation: pulse-green 2s infinite;
    }
    .status-pulse.offline {
        background-color: #ef4444;
        box-shadow: 0 0 0 0 rgba(239, 68, 68, 0.7);
        animation: pulse-red 2s infinite;
    }

    @keyframes pulse-green {
        0% { box-shadow: 0 0 0 0 rgba(16, 185, 129, 0.7); }
        70% { box-shadow: 0 0 0 8px rgba(16, 185, 129, 0); }
        100% { box-shadow: 0 0 0 0 rgba(16, 185, 129, 0); }
    }
    @keyframes pulse-red {
        0% { box-shadow: 0 0 0 0 rgba(239, 68, 68, 0.7); }
        70% { box-shadow: 0 0 0 8px rgba(239, 68, 68, 0); }
        100% { box-shadow: 0 0 0 0 rgba(239, 68, 68, 0); }
    }

    .icon-box {
        width: 48px;
        height: 48px;
        border-radius: 12px;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 1.25rem;
    }

    .service-item-label {
        color: #334155 !important;
        font-weight: 600;
    }

    .progress {
        background-color: #e2e8f0 !important;
        border-radius: 10px;
        overflow: hidden;
    }

    /* Estilos do Bloco de Atalhos / Informações Extras */
    .banner-info {
        background: linear-gradient(135deg, rgba(255, 255, 255, 0.95), rgba(241, 245, 249, 0.95));
        border-radius: 16px;
        border: 1px solid rgba(255, 255, 255, 0.2);
        box-shadow: 0 10px 30px rgba(0, 0, 0, 0.05);
    }
</style>

<!-- Import de FontAwesome (caso ainda não esteja no header) -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">

<!-- Main Content Wrapper para manter o Footer no fundo -->
<main class="main-content py-5">
    <div class="container">
        
        <!-- Cabeçalho da Página -->
        <div class="d-flex align-items-center justify-content-between mb-4">
            <div>
                <h2 class="fw-bold text-white mb-1"><?= htmlspecialchars(t('server_page')) ?></h2>
                <p class="text-white-50 small mb-0">Acompanhe o desempenho e a disponibilidade dos serviços em tempo real.</p>
            </div>
            <span class="badge bg-light text-dark border px-3 py-2 rounded-pill shadow-sm">
                <i class="fa-solid fa-rotate text-muted me-1"></i> Atualizado ao vivo
            </span>
        </div>

        <!-- Quatro Cards de Métricas Principais -->
        <div class="row g-4 mb-5">
            
            <!-- 1. Jogadores Online -->
            <div class="col-md-3">
                <div class="card card-status p-4 h-100">
                    <div class="d-flex align-items-center justify-content-between mb-3">
                        <span class="text-secondary fw-semibold"><?= htmlspecialchars(t('players_online')) ?></span>
                        <div class="icon-box bg-primary-subtle text-primary">
                            <i class="fa-solid fa-users"></i>
                        </div>
                    </div>
                    
                    <div class="display-5 fw-bold text-dark mb-2">
                        <?= (int) $metrics['online'] ?>
                    </div>

                    <div class="mt-auto pt-3 border-top d-flex align-items-center justify-content-between small text-muted">
                        <span><i class="fa-solid fa-trophy text-warning me-1"></i> <?= htmlspecialchars(t('peak_online')) ?></span>
                        <span class="fw-bold text-dark"><?= (int) $metrics['peak_online'] ?></span>
                    </div>
                </div>
            </div>

            <!-- 2. Contas cadastradas -->
            <div class="col-md-3">
                <div class="card card-status p-4 h-100">
                    <div class="d-flex align-items-center justify-content-between mb-3">
                        <span class="text-secondary fw-semibold"><?= htmlspecialchars(t('registered_users')) ?></span>
                        <div class="icon-box bg-info-subtle text-info">
                            <i class="fa-solid fa-id-card"></i>
                        </div>
                    </div>
                    <div class="display-5 fw-bold text-dark mb-2">
                        <?= number_format((int) $metrics['registered'], 0, ',', '.') ?>
                    </div>
                    <div class="mt-auto pt-3 border-top small text-muted">
                        Total de contas criadas no servidor.
                    </div>
                </div>
            </div>

            <!-- 3. Status dos Serviços -->
            <div class="col-md-3">
                <div class="card card-status p-4 h-100">
                    <div class="d-flex align-items-center justify-content-between mb-3">
                        <span class="text-secondary fw-semibold"><?= htmlspecialchars(t('service_status')) ?></span>
                        <div class="icon-box bg-success-subtle text-success">
                            <i class="fa-solid fa-server"></i>
                        </div>
                    </div>

                    <div class="d-flex flex-column gap-3 my-auto">
                        <!-- Login Server -->
                        <div class="d-flex align-items-center justify-content-between p-2 rounded-3 bg-light">
                            <span class="small service-item-label"><?= htmlspecialchars(t('login_server')) ?></span>
                            <div class="d-flex align-items-center">
                                <span class="status-pulse <?= $metrics['login_online'] ? 'online' : 'offline' ?>"></span>
                                <span class="badge bg-<?= $metrics['login_online'] ? 'success' : 'danger' ?>-subtle text-<?= $metrics['login_online'] ? 'success' : 'danger' ?> fw-bold">
                                    <?= htmlspecialchars($metrics['login_online'] ? t('online') : t('offline')) ?>
                                </span>
                            </div>
                        </div>

                        <!-- Game Server -->
                        <div class="d-flex align-items-center justify-content-between p-2 rounded-3 bg-light">
                            <span class="small service-item-label"><?= htmlspecialchars(t('game_server')) ?></span>
                            <div class="d-flex align-items-center">
                                <span class="status-pulse <?= $metrics['game_online'] ? 'online' : 'offline' ?>"></span>
                                <span class="badge bg-<?= $metrics['game_online'] ? 'success' : 'danger' ?>-subtle text-<?= $metrics['game_online'] ? 'success' : 'danger' ?> fw-bold">
                                    <?= htmlspecialchars($metrics['game_online'] ? t('online') : t('offline')) ?>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 4. Taxas do Servidor (Rates) -->
            <div class="col-md-3">
                <div class="card card-status p-4 h-100">
                    <div class="d-flex align-items-center justify-content-between mb-3">
                        <span class="text-secondary fw-semibold"><?= htmlspecialchars(t('active_rates')) ?></span>
                        <div class="icon-box bg-warning-subtle text-warning">
                            <i class="fa-solid fa-bolt"></i>
                        </div>
                    </div>

                    <div class="d-flex flex-column gap-3 my-auto">
                        <!-- Pang Rate -->
                        <div>
                            <div class="d-flex justify-content-between small fw-medium mb-1">
                                <span class="text-dark"><i class="fa-solid fa-coins text-warning me-1"></i> Pang</span>
                                <span class="fw-bold text-primary"><?= htmlspecialchars((string) $metrics['pang_rate']) ?>x</span>
                            </div>
                            <div class="progress" style="height: 8px;">
                                <div class="progress-bar bg-warning rounded-pill" role="progressbar" 
                                     style="width: <?= max(4, min(100, (float)$metrics['pang_rate'] * 10)) ?>%"></div>
                            </div>
                        </div>

                        <!-- EXP Rate -->
                        <div>
                            <div class="d-flex justify-content-between small fw-medium mb-1">
                                <span class="text-dark"><i class="fa-solid fa-angles-up text-info me-1"></i> EXP</span>
                                <span class="fw-bold text-primary"><?= htmlspecialchars((string) $metrics['exp_rate']) ?>x</span>
                            </div>
                            <div class="progress" style="height: 8px;">
                                <div class="progress-bar bg-info rounded-pill" role="progressbar" 
                                     style="width: <?= max(4, min(100, (float)$metrics['exp_rate'] * 10)) ?>%"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- SEÇÃO EXTRA: Preenche o espaço vago e dá mais utilidade à página -->
        <div class="banner-info p-4 p-md-5">
            <div class="row align-items-center g-4">
                <div class="col-lg-8">
                    <h4 class="fw-bold text-dark mb-2">Pronto para entrar em campo?</h4>
                    <p class="text-secondary mb-0">
                        Baixe o jogo atualizado, crie sua conta e venha jogar com a comunidade. Se encontrar alguma instabilidade nos serviços, informe em nosso Discord.
                    </p>
                </div>
                <div class="col-lg-4 text-lg-end d-flex gap-2 justify-content-lg-end flex-wrap">
                    <a href="/downloads.php" class="btn btn-primary fw-bold px-4 py-2 rounded-pill">
                        <i class="fa-solid fa-download me-1"></i> Baixar Game
                    </a>
                    <a href="https://discord.gg" target="_blank" class="btn btn-outline-dark fw-bold px-3 py-2 rounded-pill">
                        <i class="fa-brands fa-discord me-1"></i> Discord
                    </a>
                </div>
            </div>
        </div>

    </div>
</main>

<?php require __DIR__ . '/../includes/footer.php'; ?>