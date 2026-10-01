<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/DonationService.php';
require_once __DIR__ . '/PayPalClient.php';

header('Content-Type: application/json');

if (!isLoggedIn()) {
    http_response_code(401);
    echo json_encode(['status' => 'error', 'message' => 'Sua sessão expirou.']);
    exit;
}

$input = json_decode(file_get_contents('php://input'), true) ?? [];
$orderId = (string) ($input['order_id'] ?? '');

if ($orderId === '') {
    http_response_code(400);
    echo json_encode(['status' => 'error', 'message' => 'Ordem inválida.']);
    exit;
}

$donationService = new DonationService();
$donation = $donationService->findByExternalId('paypal', $orderId);

if (!$donation || (int) $donation['uid'] !== (int) $_SESSION['uid']) {
    http_response_code(404);
    echo json_encode(['status' => 'error', 'message' => 'Doação não encontrada para essa ordem.']);
    exit;
}

try {
    $paypal = new PayPalClient(PAYPAL_CLIENT_ID, PAYPAL_SECRET, PAYPAL_MODE);
    $capture = $paypal->captureOrder($orderId);

    $status = $capture['status'] ?? '';

    if ($status !== 'COMPLETED') {
        $donationService->markStatus((int) $donation['donation_id'], 'rejected', $orderId, json_encode($capture, JSON_UNESCAPED_UNICODE));
        http_response_code(400);
        echo json_encode(['status' => 'error', 'message' => 'O PayPal não confirmou o pagamento.']);
        exit;
    }

    $donationService->approveAndCredit((int) $donation['donation_id'], $orderId, json_encode($capture, JSON_UNESCAPED_UNICODE));

    echo json_encode(['status' => 'success', 'message' => 'Pagamento confirmado! Seus créditos já foram adicionados.']);
} catch (Throwable $e) {
    error_log('Erro ao capturar ordem PayPal: ' . $e->getMessage());
    http_response_code(500);
    echo json_encode(['status' => 'error', 'message' => 'Erro ao confirmar o pagamento com o PayPal.']);
}
