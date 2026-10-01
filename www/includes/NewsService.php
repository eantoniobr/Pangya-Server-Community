<?php

final class NewsService
{
    public function listPublished(int $page = 1, int $perPage = 6): array
    {
        $pdo = getConnection();
        $offset = max(0, ($page - 1) * $perPage);

        $stmt = $pdo->prepare(
            'SELECT [news_id], [title], [slug], [summary], [cover_image], [created_at]
               FROM pangya.web_news
              WHERE [published] = 1
              ORDER BY [created_at] DESC
              OFFSET ? ROWS FETCH NEXT ? ROWS ONLY'
        );
        $stmt->execute([$offset, $perPage]);

        return $stmt->fetchAll();
    }

    public function countPublished(): int
    {
        return (int) getConnection()->query('SELECT COUNT(*) FROM pangya.web_news WHERE [published] = 1')->fetchColumn();
    }

    public function findBySlug(string $slug): ?array
    {
        $stmt = getConnection()->prepare('SELECT * FROM pangya.web_news WHERE [slug] = ? AND [published] = 1');
        $stmt->execute([$slug]);
        $row = $stmt->fetch();

        return $row ?: null;
    }

    public function find(int $id): ?array
    {
        $stmt = getConnection()->prepare('SELECT * FROM pangya.web_news WHERE [news_id] = ?');
        $stmt->execute([$id]);
        $row = $stmt->fetch();

        return $row ?: null;
    }

    public function listAll(): array
    {
        return getConnection()->query(
            'SELECT [news_id], [title], [slug], [published], [created_at] FROM pangya.web_news ORDER BY [created_at] DESC'
        )->fetchAll();
    }

    public function slugify(string $title): string
    {
        $slug = strtolower(trim($title));
        $slug = iconv('UTF-8', 'ASCII//TRANSLIT//IGNORE', $slug) ?: $slug;
        $slug = preg_replace('/[^a-z0-9]+/', '-', $slug);
        $slug = trim((string) $slug, '-');

        return $slug !== '' ? $slug : ('noticia-' . time());
    }

    public function save(array $data, int $authorUid, ?int $newsId = null): int
    {
        $pdo = getConnection();
        $slug = $this->slugify($data['title']);

        // Garante slug único mesmo se o título repetir
        $baseSlug = $slug;
        $suffix = 2;
        while ($this->slugExists($slug, $newsId)) {
            $slug = $baseSlug . '-' . $suffix++;
        }

        if ($newsId) {
            $stmt = $pdo->prepare(
                'UPDATE pangya.web_news
                    SET [title] = ?, [slug] = ?, [summary] = ?, [content] = ?, [cover_image] = ?, [published] = ?, [updated_at] = SYSUTCDATETIME()
                  WHERE [news_id] = ?'
            );
            $stmt->execute([
                $data['title'], $slug, $data['summary'], $data['content'],
                $data['cover_image'] ?: null, $data['published'] ? 1 : 0, $newsId,
            ]);

            return $newsId;
        }

        $stmt = $pdo->prepare(
            'INSERT INTO pangya.web_news ([title], [slug], [summary], [content], [cover_image], [author_uid], [published])
             VALUES (?, ?, ?, ?, ?, ?, ?)'
        );
        $stmt->execute([
            $data['title'], $slug, $data['summary'], $data['content'],
            $data['cover_image'] ?: null, $authorUid, $data['published'] ? 1 : 0,
        ]);

        return (int) $pdo->lastInsertId();
    }

    public function delete(int $newsId): void
    {
        $stmt = getConnection()->prepare('DELETE FROM pangya.web_news WHERE [news_id] = ?');
        $stmt->execute([$newsId]);
    }

    private function slugExists(string $slug, ?int $exceptId): bool
    {
        $sql = 'SELECT COUNT(*) FROM pangya.web_news WHERE [slug] = ?';
        $params = [$slug];

        if ($exceptId) {
            $sql .= ' AND [news_id] != ?';
            $params[] = $exceptId;
        }

        $stmt = getConnection()->prepare($sql);
        $stmt->execute($params);

        return ((int) $stmt->fetchColumn()) > 0;
    }
}
