<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/DonationService.php';
require_once __DIR__ . '/MercadoPagoClient.php';

// O Mercado Pago manda notificação tanto por GET (?topic=payment&id=123)
// quanto por POST com JSON no corpo, dependendo da configuração da conta.
$paymentId = $_GET['id'] ?? $_GET['data_id'] ?? null;

if (!$paymentId) {
    $body = json_decode(file_get_contents('php://input'), true);
    $paymentId = $body['data']['id'] ?? null;
}

if (!$paymentId) {
    http_response_code(200); // responde 200 pra o MP não ficar reenviando notificação vazia
    exit;
}

try {
    $mp = new MercadoPagoClient(MP_ACCESS_TOKEN);
    $payment = $mp->getPayment((string) $paymentId);

    $externalReference = (string) ($payment['external_reference'] ?? '');
    $status = (string) ($payment['status'] ?? '');

    if (str_starts_with($externalReference, 'donation-') && $status === 'approved') {
        $donationId = (int) substr($externalReference, strlen('donation-'));

        if ($donationId > 0) {
            (new DonationService())->approveAndCredit($donationId, (string) $paymentId, json_encode($payment, JSON_UNESCAPED_UNICODE));
        }
    }
} catch (Throwable $e) {
    error_log('Erro no webhook do Mercado Pago: ' . $e->getMessage());
}

http_response_code(200);
