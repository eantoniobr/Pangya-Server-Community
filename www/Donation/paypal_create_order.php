<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/DonationService.php';
require_once __DIR__ . '/PayPalClient.php';

header('Content-Type: application/json');

if (!isLoggedIn()) {
    http_response_code(401);
    echo json_encode(['status' => 'error', 'message' => 'Sua sessão expirou. Faça login novamente.']);
    exit;
}

$input = json_decode(file_get_contents('php://input'), true) ?? [];

if (!csrfValid($input['csrf_token'] ?? null)) {
    http_response_code(400);
    echo json_encode(['status' => 'error', 'message' => 'Token de segurança inválido.']);
    exit;
}

$packageId = (string) ($input['package_id'] ?? '');
$package = DonationService::package($packageId);

if (!$package) {
    http_response_code(400);
    echo json_encode(['status' => 'error', 'message' => 'Pacote inválido.']);
    exit;
}

$uid = (int) $_SESSION['uid'];
$donationService = new DonationService();
$donationId = $donationService->createPending($uid, $packageId, $package, 'paypal');

try {
    $paypal = new PayPalClient(PAYPAL_CLIENT_ID, PAYPAL_SECRET, PAYPAL_MODE);
    $order = $paypal->createOrder(
        $package['price'],
        DONATION_CURRENCY,
        'donation-' . $donationId,
        'PangYa Community - ' . $package['label']
    );

    if (empty($order['id'])) {
        throw new RuntimeException($order['message'] ?? 'Falha ao criar ordem no PayPal.');
    }

    $donationService->markStatus($donationId, 'pending', $order['id']);

    echo json_encode(['status' => 'success', 'order_id' => $order['id'], 'donation_id' => $donationId]);
} catch (Throwable $e) {
    error_log('Erro ao criar ordem PayPal: ' . $e->getMessage());
    http_response_code(500);
    echo json_encode(['status' => 'error', 'message' => 'Não foi possível iniciar o pagamento com o PayPal.']);
}
