<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../includes/NewsService.php';

requireGameMaster();

$news = new NewsService();
$newsId = (int) ($_GET['id'] ?? 0);
$article = $newsId ? $news->find($newsId) : null;

if ($newsId && !$article) {
    setFlash('error', 'Notícia não encontrada.');
    App::redirect('/Admin/index.php');
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (!csrfValid($_POST['csrf_token'] ?? null)) {
        setFlash('error', 'Token de segurança inválido, tente novamente.');
    } else {
        $title = trim((string) ($_POST['title'] ?? ''));
        $summary = trim((string) ($_POST['summary'] ?? ''));
        $content = trim((string) ($_POST['content'] ?? ''));
        $coverImage = trim((string) ($_POST['cover_image'] ?? ''));
        $published = isset($_POST['published']);

        if ($title === '' || $content === '') {
            setFlash('error', 'Preencha ao menos o título e o conteúdo da notícia.');
        } else {
            try {
                $savedId = $news->save([
                    'title' => $title,
                    'summary' => $summary,
                    'content' => $content,
                    'cover_image' => $coverImage,
                    'published' => $published,
                ], (int) $_SESSION['uid'], $newsId ?: null);

                setFlash('success', $newsId ? 'Notícia atualizada.' : 'Notícia publicada.');
                App::redirect('/Admin/index.php');
            } catch (PDOException $e) {
                error_log('Erro ao salvar notícia: ' . $e->getMessage());
                setFlash('error', 'Não foi possível salvar a notícia (verifique se a tabela pangya.web_news já foi criada).');
            }
        }
    }
}

$pageTitle = $newsId ? 'Editar notícia' : 'Nova notícia';
require __DIR__ . '/../includes/header.php';
?>

<a href="/Admin/index.php" class="btn btn-sm btn-outline-light mb-3"><i class="bi bi-arrow-left me-1"></i> Voltar ao painel</a>

<div class="card bg-dark text-white border-secondary p-4">
    <h3 class="mb-4"><?= $newsId ? 'Editar notícia' : 'Nova notícia' ?></h3>

    <form method="post">
        <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">

        <div class="mb-3">
            <label class="form-label">Título</label>
            <input type="text" name="title" class="form-control bg-dark text-light border-secondary" maxlength="160" required value="<?= htmlspecialchars($article['title'] ?? '') ?>">
        </div>

        <div class="mb-3">
            <label class="form-label">Resumo (aparece na listagem)</label>
            <input type="text" name="summary" class="form-control bg-dark text-light border-secondary" maxlength="400" value="<?= htmlspecialchars($article['summary'] ?? '') ?>">
        </div>

        <div class="mb-3">
            <label class="form-label">Imagem de capa (URL, opcional)</label>
            <input type="text" name="cover_image" class="form-control bg-dark text-light border-secondary" placeholder="/assets/img/bg/beach-event-banner.jpg" value="<?= htmlspecialchars($article['cover_image'] ?? '') ?>">
        </div>

        <div class="mb-3">
            <label class="form-label">Conteúdo</label>
            <textarea name="content" rows="12" class="form-control bg-dark text-light border-secondary" required><?= htmlspecialchars($article['content'] ?? '') ?></textarea>
            <div class="form-text">Quebras de linha simples são convertidas automaticamente ao exibir.</div>
        </div>

        <div class="form-check mb-4">
            <input type="checkbox" class="form-check-input" id="published" name="published" <?= (!$article || (int) $article['published'] === 1) ? 'checked' : '' ?>>
            <label class="form-check-label" for="published">Publicada (visível no site)</label>
        </div>

        <button type="submit" class="btn btn-primary px-4">Salvar</button>
    </form>
</div>

<?php require __DIR__ . '/../includes/footer.php'; ?>
