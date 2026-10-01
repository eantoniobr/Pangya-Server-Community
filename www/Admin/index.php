<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../Server/ServerMetrics.php';
require_once __DIR__ . '/../includes/NewsService.php';

requireGameMaster();

$pdo = getConnection();
$metrics = (new ServerMetrics($pdo))->snapshot();

$recentDonations = [];
$totalDonatedThisMonth = 0;
try {
    $stmt = $pdo->query(
        "SELECT TOP 10 d.[donation_id], d.[uid], d.[provider], d.[amount], d.[currency], d.[price_brl], d.[status], d.[created_at]
           FROM pangya.web_donation d
          ORDER BY d.[created_at] DESC"
    );
    $recentDonations = $stmt->fetchAll();

    $totalDonatedThisMonth = (float) $pdo->query(
        "SELECT ISNULL(SUM(price_brl), 0) FROM pangya.web_donation
          WHERE status = 'paid' AND created_at >= DATEADD(day, -30, SYSUTCDATETIME())"
    )->fetchColumn();
} catch (PDOException $e) {
    error_log('Admin: doações indisponíveis - ' . $e->getMessage());
}

$recentAudit = [];
try {
    $stmt = $pdo->query('SELECT TOP 15 * FROM pangya.web_audit_log ORDER BY created_at DESC');
    $recentAudit = $stmt->fetchAll();
} catch (PDOException $e) {
    error_log('Admin: auditoria indisponível - ' . $e->getMessage());
}

$newsList = [];
try {
    $newsList = (new NewsService())->listAll();
} catch (PDOException $e) {
    error_log('Admin: notícias indisponíveis - ' . $e->getMessage());
}

$pageTitle = 'Painel Administrativo';
require __DIR__ . '/../includes/header.php';
?>

<div class="d-flex flex-wrap justify-content-between align-items-center gap-2 mb-4">
    <h2 class="mb-0"><i class="bi bi-speedometer2 me-2"></i>Painel Administrativo</h2>
    <span class="badge bg-danger px-3 py-2">Acesso restrito a Game Masters</span>
</div>

<!-- Métricas rápidas -->
<div class="row g-3 mb-4">
    <div class="col-sm-6 col-lg-3">
        <div class="card p-3 bg-dark text-white border-secondary h-100">
            <div class="small text-secondary">Contas cadastradas</div>
            <div class="fs-3 fw-bold"><?= number_format((int) $metrics['registered'], 0, ',', '.') ?></div>
        </div>
    </div>
    <div class="col-sm-6 col-lg-3">
        <div class="card p-3 bg-dark text-white border-secondary h-100">
            <div class="small text-secondary">Jogadores online</div>
            <div class="fs-3 fw-bold text-success"><?= number_format((int) $metrics['online'], 0, ',', '.') ?></div>
        </div>
    </div>
    <div class="col-sm-6 col-lg-3">
        <div class="card p-3 bg-dark text-white border-secondary h-100">
            <div class="small text-secondary">Serviços</div>
            <div>Login: <span class="badge bg-<?= $metrics['login_online'] ? 'success' : 'danger' ?>"><?= $metrics['login_online'] ? 'Online' : 'Offline' ?></span></div>
            <div>Game: <span class="badge bg-<?= $metrics['game_online'] ? 'success' : 'danger' ?>"><?= $metrics['game_online'] ? 'Online' : 'Offline' ?></span></div>
        </div>
    </div>
    <div class="col-sm-6 col-lg-3">
        <div class="card p-3 bg-dark text-white border-secondary h-100">
            <div class="small text-secondary">Arrecadado (30 dias)</div>
            <div class="fs-3 fw-bold text-warning">R$ <?= number_format($totalDonatedThisMonth, 2, ',', '.') ?></div>
        </div>
    </div>
</div>

<div class="row g-4">

    <!-- Notícias -->
    <div class="col-lg-6">
        <div class="card bg-dark text-white border-secondary h-100">
            <div class="card-header border-secondary d-flex justify-content-between align-items-center">
                <span class="fw-bold"><i class="bi bi-newspaper me-2"></i>Notícias</span>
                <a href="news_form.php" class="btn btn-sm btn-warning fw-bold">+ Nova</a>
            </div>
            <div class="card-body p-0">
                <?php if (empty($newsList)): ?>
                    <p class="text-secondary p-3 mb-0">Nenhuma notícia cadastrada ainda.</p>
                <?php else: ?>
                    <div class="table-responsive">
                        <table class="table table-dark table-hover mb-0 align-middle">
                            <tbody>
                                <?php foreach ($newsList as $item): ?>
                                    <tr>
                                        <td>
                                            <?= htmlspecialchars($item['title']) ?>
                                            <?php if (!(int) $item['published']): ?>
                                                <span class="badge bg-secondary ms-1">Rascunho</span>
                                            <?php endif; ?>
                                            <div class="text-secondary small"><?= htmlspecialchars((new DateTime($item['created_at']))->format('d/m/Y H:i')) ?></div>
                                        </td>
                                        <td class="text-end" style="width:1%;white-space:nowrap;">
                                            <a href="news_form.php?id=<?= (int) $item['news_id'] ?>" class="btn btn-sm btn-outline-light"><i class="bi bi-pencil"></i></a>
                                            <form action="news_delete.php" method="post" class="d-inline" onsubmit="return confirm('Excluir esta notícia?');">
                                                <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
                                                <input type="hidden" name="news_id" value="<?= (int) $item['news_id'] ?>">
                                                <button type="submit" class="btn btn-sm btn-outline-danger"><i class="bi bi-trash"></i></button>
                                            </form>
                                        </td>
                                    </tr>
                                <?php endforeach; ?>
                            </tbody>
                        </table>
                    </div>
                <?php endif; ?>
            </div>
        </div>
    </div>

    <!-- Doações recentes -->
    <div class="col-lg-6">
        <div class="card bg-dark text-white border-secondary h-100">
            <div class="card-header border-secondary fw-bold"><i class="bi bi-cash-coin me-2"></i>Últimas doações</div>
            <div class="card-body p-0">
                <?php if (empty($recentDonations)): ?>
                    <p class="text-secondary p-3 mb-0">Nenhuma doação registrada ainda.</p>
                <?php else: ?>
                    <div class="table-responsive">
                        <table class="table table-dark table-hover mb-0 align-middle small">
                            <thead>
                                <tr>
                                    <th>UID</th>
                                    <th>Meio</th>
                                    <th>Pacote</th>
                                    <th>Valor</th>
                                    <th>Status</th>
                                </tr>
                            </thead>
                            <tbody>
                                <?php foreach ($recentDonations as $d): ?>
                                    <?php
                                        $statusMap = [
                                            'paid' => 'success', 'pending' => 'warning',
                                            'awaiting_pix' => 'warning', 'rejected' => 'danger',
                                        ];
                                        $badge = $statusMap[$d['status']] ?? 'secondary';
                                    ?>
                                    <tr>
                                        <td><?= (int) $d['uid'] ?></td>
                                        <td class="text-capitalize"><?= htmlspecialchars($d['provider']) ?></td>
                                        <td><?= (int) $d['amount'] ?> <?= htmlspecialchars($d['currency']) ?></td>
                                        <td>R$ <?= number_format((float) $d['price_brl'], 2, ',', '.') ?></td>
                                        <td><span class="badge bg-<?= $badge ?>"><?= htmlspecialchars($d['status']) ?></span></td>
                                    </tr>
                                <?php endforeach; ?>
                            </tbody>
                        </table>
                    </div>
                <?php endif; ?>
            </div>
        </div>
    </div>

    <!-- Auditoria -->
    <div class="col-12">
        <div class="card bg-dark text-white border-secondary">
            <div class="card-header border-secondary fw-bold"><i class="bi bi-clipboard-data me-2"></i>Log de auditoria</div>
            <div class="card-body p-0">
                <?php if (empty($recentAudit)): ?>
                    <p class="text-secondary p-3 mb-0"><?= htmlspecialchars(t('audit_unavailable')) ?></p>
                <?php else: ?>
                    <div class="table-responsive">
                        <table class="table table-dark table-hover mb-0 align-middle small">
                            <thead>
                                <tr>
                                    <th>Quando</th>
                                    <th>Ator (UID)</th>
                                    <th>Ação</th>
                                    <th>Item</th>
                                    <th>IP</th>
                                </tr>
                            </thead>
                            <tbody>
                                <?php foreach ($recentAudit as $log): ?>
                                    <tr>
                                        <td><?= htmlspecialchars((new DateTime($log['created_at']))->format('d/m/Y H:i')) ?></td>
                                        <td><?= (int) $log['actor_uid'] ?></td>
                                        <td><?= htmlspecialchars($log['action']) ?></td>
                                        <td><?= $log['item_id'] !== null ? (int) $log['item_id'] : '-' ?></td>
                                        <td><?= htmlspecialchars($log['ip_address']) ?></td>
                                    </tr>
                                <?php endforeach; ?>
                            </tbody>
                        </table>
                    </div>
                <?php endif; ?>
            </div>
        </div>
    </div>

</div>

<?php require __DIR__ . '/../includes/footer.php'; ?>
