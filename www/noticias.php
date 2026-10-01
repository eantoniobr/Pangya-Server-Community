<?php
require_once __DIR__ . '/Config/config.php';
require_once __DIR__ . '/includes/functions.php';
require_once __DIR__ . '/includes/NewsService.php';

$news = new NewsService();
$slug = trim((string) ($_GET['n'] ?? ''));

$article = null;
$articles = [];
$totalPages = 1;
$page = max(1, (int) ($_GET['page'] ?? 1));
$perPage = 6;
$loadError = '';

try {
    if ($slug !== '') {
        $article = $news->findBySlug($slug);
        if (!$article) {
            $loadError = 'Notícia não encontrada.';
        }
    } else {
        $articles = $news->listPublished($page, $perPage);
        $totalPages = max(1, (int) ceil($news->countPublished() / $perPage));
    }
} catch (PDOException $e) {
    error_log('Erro ao carregar notícias: ' . $e->getMessage());
    $loadError = 'Não foi possível carregar as notícias agora. Tente novamente mais tarde.';
}

$pageTitle = $article ? $article['title'] : 'Notícias';
require __DIR__ . '/includes/header.php';
?>

<style>
    .news-card { transition: transform .2s ease, box-shadow .2s ease; border: 1px solid rgba(255,255,255,.08); }
    .news-card:hover { transform: translateY(-4px); box-shadow: 0 10px 25px rgba(0,0,0,.4); }
    .news-cover { height: 180px; object-fit: cover; width: 100%; }
    .article-body { line-height: 1.75; }
    .article-body p { margin-bottom: 1rem; }
</style>

<?php if ($loadError): ?>

    <div class="alert alert-warning"><?= htmlspecialchars($loadError) ?></div>
    <a href="/noticias.php" class="btn btn-outline-light btn-sm">Voltar para as notícias</a>

<?php elseif ($article): ?>

    <!-- Artigo individual -->
    <a href="/noticias.php" class="btn btn-sm btn-outline-light mb-3"><i class="bi bi-arrow-left me-1"></i> Voltar</a>

    <article class="card bg-dark text-light border-secondary p-4 p-md-5">
        <?php if (!empty($article['cover_image'])): ?>
            <img src="<?= htmlspecialchars($article['cover_image']) ?>" alt="" class="news-cover rounded-3 mb-4" style="height:320px;">
        <?php endif; ?>

        <h1 class="fw-bold mb-2"><?= htmlspecialchars($article['title']) ?></h1>
        <p class="text-secondary small mb-4">
            <i class="bi bi-calendar3 me-1"></i>
            <?= htmlspecialchars((new DateTime($article['created_at']))->format('d/m/Y \à\s H:i')) ?>
        </p>

        <div class="article-body fs-5">
            <?= nl2br(htmlspecialchars($article['content'])) ?>
        </div>
    </article>

<?php else: ?>

    <!-- Listagem -->
    <div class="d-flex flex-wrap justify-content-between align-items-center gap-2 mb-4">
        <h2 class="mb-0"><i class="bi bi-newspaper me-2"></i>Notícias</h2>
        <?php if (function_exists('isGameMaster') && isGameMaster()): ?>
            <a href="/Admin/news_form.php" class="btn btn-sm btn-warning fw-bold"><i class="bi bi-plus-lg me-1"></i> Nova notícia</a>
        <?php endif; ?>
    </div>

    <?php if (empty($articles)): ?>
        <div class="card bg-dark border-secondary p-5 text-center text-secondary">
            Nenhuma notícia publicada ainda. Volte em breve!
        </div>
    <?php else: ?>
        <div class="row g-4">
            <?php foreach ($articles as $item): ?>
                <div class="col-md-6 col-lg-4">
                    <a href="/noticias.php?n=<?= urlencode($item['slug']) ?>" class="text-decoration-none">
                        <div class="card news-card h-100 bg-dark text-light">
                            <?php if (!empty($item['cover_image'])): ?>
                                <img src="<?= htmlspecialchars($item['cover_image']) ?>" alt="" class="news-cover">
                            <?php else: ?>
                                <div class="news-cover d-flex align-items-center justify-content-center bg-black bg-opacity-25">
                                    <i class="bi bi-image text-secondary fs-1"></i>
                                </div>
                            <?php endif; ?>
                            <div class="card-body">
                                <div class="text-secondary small mb-1"><?= htmlspecialchars((new DateTime($item['created_at']))->format('d/m/Y')) ?></div>
                                <h5 class="card-title fw-bold"><?= htmlspecialchars($item['title']) ?></h5>
                                <?php if (!empty($item['summary'])): ?>
                                    <p class="card-text text-secondary small mb-0"><?= htmlspecialchars($item['summary']) ?></p>
                                <?php endif; ?>
                            </div>
                        </div>
                    </a>
                </div>
            <?php endforeach; ?>
        </div>

        <?php if ($totalPages > 1): ?>
            <nav class="mt-4">
                <ul class="pagination justify-content-center">
                    <?php for ($p = 1; $p <= $totalPages; $p++): ?>
                        <li class="page-item <?= $p === $page ? 'active' : '' ?>">
                            <a class="page-link bg-dark text-white border-secondary" href="?page=<?= $p ?>"><?= $p ?></a>
                        </li>
                    <?php endfor; ?>
                </ul>
            </nav>
        <?php endif; ?>
    <?php endif; ?>

<?php endif; ?>

<?php require __DIR__ . '/includes/footer.php'; ?>
