<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/DonationService.php';

header('Content-Type: application/json');

if (!isLoggedIn()) {
    http_response_code(401);
    echo json_encode(['status' => 'error', 'message' => 'Sessão expirada.']);
    exit;
}

$donationId = (int) ($_GET['donation_id'] ?? 0);
$service = new DonationService();
$donation = $service->find($donationId);

if (!$donation || (int) $donation['uid'] !== (int) $_SESSION['uid']) {
    http_response_code(404);
    echo json_encode(['status' => 'error', 'message' => 'Doação não encontrada.']);
    exit;
}

echo json_encode([
    'status' => 'success',
    'paid'   => $donation['status'] === 'paid',
    'donation_status' => $donation['status'],
]);
