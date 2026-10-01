<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../includes/NewsService.php';

requireGameMaster();

if ($_SERVER['REQUEST_METHOD'] !== 'POST' || !csrfValid($_POST['csrf_token'] ?? null)) {
    setFlash('error', 'Solicitação inválida.');
    App::redirect('/Admin/index.php');
}

$newsId = (int) ($_POST['news_id'] ?? 0);

if ($newsId > 0) {
    try {
        (new NewsService())->delete($newsId);
        setFlash('success', 'Notícia removida.');
    } catch (PDOException $e) {
        error_log('Erro ao remover notícia: ' . $e->getMessage());
        setFlash('error', 'Não foi possível remover a notícia.');
    }
}

App::redirect('/Admin/index.php');
