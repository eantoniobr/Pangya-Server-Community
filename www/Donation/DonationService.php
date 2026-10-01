<?php

require_once __DIR__ . '/../includes/AuditLogger.php';

final class DonationService
{
    /**
     * Pacotes disponíveis. O preço e a quantidade creditada SEMPRE são lidos
     * daqui no servidor - nunca confiamos em valores vindos do formulário,
     * pra ninguém conseguir comprar 1 milhão de Pang por R$ 0,01 editando o HTML.
     */
    public static function packages(): array
    {
        return [
            'cookie_10'  => ['label' => '100 Cookies',       'currency' => 'Cookie', 'amount' => 100,    'price' => 10.00],
            'cookie_25'  => ['label' => '270 Cookies',       'currency' => 'Cookie', 'amount' => 270,    'price' => 25.00, 'bonus' => '+20 bônus'],
            'cookie_50'  => ['label' => '560 Cookies',       'currency' => 'Cookie', 'amount' => 560,    'price' => 50.00, 'bonus' => '+60 bônus'],
            'cookie_100' => ['label' => '1.200 Cookies',     'currency' => 'Cookie', 'amount' => 1200,   'price' => 100.00, 'bonus' => '+200 bônus', 'popular' => true],
            'pang_10'    => ['label' => '50.000 Pang',       'currency' => 'Pang',   'amount' => 50000,  'price' => 10.00],
            'pang_25'    => ['label' => '140.000 Pang',      'currency' => 'Pang',   'amount' => 140000, 'price' => 25.00, 'bonus' => '+15k bônus'],
            'pang_50'    => ['label' => '300.000 Pang',      'currency' => 'Pang',   'amount' => 300000, 'price' => 50.00, 'bonus' => '+50k bônus'],
            'pang_100'   => ['label' => '700.000 Pang',      'currency' => 'Pang',   'amount' => 700000, 'price' => 100.00, 'bonus' => '+200k bônus'],
        ];
    }

    public static function package(string $packageId): ?array
    {
        return self::packages()[$packageId] ?? null;
    }

    /**
     * Cria o registro da doação com status "pending" e devolve o ID gerado.
     * Todo pagamento passa por aqui antes de falar com o gateway.
     */
    public function createPending(int $uid, string $packageId, array $package, string $provider): int
    {
        $pdo = getConnection();

        $stmt = $pdo->prepare(
            'INSERT INTO pangya.web_donation
                ([uid], [provider], [package_id], [currency], [amount], [price_brl], [status], [ip_address])
             VALUES (?, ?, ?, ?, ?, ?, ?, ?)'
        );

        $stmt->execute([
            $uid,
            $provider,
            $packageId,
            $package['currency'],
            $package['amount'],
            $package['price'],
            'pending',
            getClientIp(),
        ]);

        return (int) $pdo->lastInsertId();
    }

    public function markStatus(int $donationId, string $status, ?string $externalId = null, ?string $rawPayload = null): void
    {
        $pdo = getConnection();
        $stmt = $pdo->prepare(
            'UPDATE pangya.web_donation
                SET [status] = ?, [external_id] = COALESCE(?, [external_id]), [raw_payload] = COALESCE(?, [raw_payload]), [updated_at] = SYSUTCDATETIME()
              WHERE [donation_id] = ?'
        );
        $stmt->execute([$status, $externalId, $rawPayload, $donationId]);
    }

    public function find(int $donationId): ?array
    {
        $stmt = getConnection()->prepare('SELECT * FROM pangya.web_donation WHERE [donation_id] = ?');
        $stmt->execute([$donationId]);
        $row = $stmt->fetch();

        return $row ?: null;
    }

    public function findByExternalId(string $provider, string $externalId): ?array
    {
        $stmt = getConnection()->prepare(
            'SELECT * FROM pangya.web_donation WHERE [provider] = ? AND [external_id] = ?'
        );
        $stmt->execute([$provider, $externalId]);
        $row = $stmt->fetch();

        return $row ?: null;
    }

    /**
     * Credita o valor na conta do jogador e marca a doação como paga.
     * Idempotente: se a doação já estiver "paid", não credita de novo
     * (importante pro webhook do Mercado Pago, que pode chegar mais de uma vez).
     */
    public function approveAndCredit(int $donationId, ?string $externalId = null, ?string $rawPayload = null): bool
    {
        $pdo = getConnection();
        $donation = $this->find($donationId);

        if (!$donation) {
            return false;
        }

        if ($donation['status'] === 'paid') {
            return true; // já processado antes, evita creditar duas vezes
        }

        $pdo->beginTransaction();

        try {
            $column = $donation['currency'] === 'Pang' ? '[Pang]' : '[Cookie]';

            $update = $pdo->prepare(
                "UPDATE pangya.user_info SET {$column} = {$column} + ? WHERE [UID] = ?"
            );
            $update->execute([(int) $donation['amount'], (int) $donation['uid']]);

            $this->markStatus($donationId, 'paid', $externalId, $rawPayload);

            $pdo->commit();
        } catch (PDOException $e) {
            $pdo->rollBack();
            error_log('Falha ao creditar doação #' . $donationId . ': ' . $e->getMessage());
            return false;
        }

        try {
            (new AuditLogger($pdo))->record('donation_paid', $donationId, [
                'provider' => $donation['provider'],
                'package'  => $donation['package_id'],
                'amount'   => $donation['amount'],
                'currency' => $donation['currency'],
            ]);
        } catch (Throwable $e) {
            // auditoria não pode derrubar o fluxo de pagamento
            error_log('Falha ao gravar auditoria da doação #' . $donationId . ': ' . $e->getMessage());
        }

        return true;
    }

    public function history(int $uid, int $limit = 10): array
    {
        $stmt = getConnection()->prepare(
            'SELECT TOP (?) [donation_id], [provider], [package_id], [currency], [amount], [price_brl], [status], [created_at]
               FROM pangya.web_donation
              WHERE [uid] = ?
              ORDER BY [created_at] DESC'
        );
        $stmt->execute([$limit, $uid]);

        return $stmt->fetchAll();
    }
}
