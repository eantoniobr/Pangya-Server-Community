<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/DonationService.php';
require_once __DIR__ . '/MercadoPagoClient.php';

header('Content-Type: application/json');

function jsonFail(string $message, int $status = 400): never
{
    http_response_code($status);
    echo json_encode(['status' => 'error', 'message' => $message]);
    exit;
}

if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    jsonFail('Método não permitido.', 405);
}

if (!isLoggedIn()) {
    jsonFail('Sua sessão expirou. Faça login novamente.', 401);
}

$input = json_decode(file_get_contents('php://input'), true);
if (!is_array($input)) {
    $input = $_POST;
}

if (!csrfValid($input['csrf_token'] ?? null)) {
    jsonFail('Token de segurança inválido. Recarregue a página.');
}

$packageId = (string) ($input['package_id'] ?? '');
$package = DonationService::package($packageId);

if (!$package) {
    jsonFail('Pacote de doação inválido.');
}

$uid = (int) $_SESSION['uid'];
$paymentMethodId = (string) ($input['payment_method_id'] ?? ''); // 'pix' ou a bandeira do cartão (ex: 'visa')
$isPix = $paymentMethodId === 'pix';

if (!$isPix && empty($input['token'])) {
    jsonFail('Não foi possível ler os dados do cartão. Confira os campos e tente novamente.');
}

$donationService = new DonationService();
$donationId = $donationService->createPending($uid, $packageId, $package, 'mercadopago');

$stmt = getConnection()->prepare('SELECT [Login], [Email] FROM pangya.account WHERE [UID] = ?');
$stmt->execute([$uid]);
$account = $stmt->fetch();
$payerEmail = trim((string) ($account['Email'] ?? '')) ?: 'jogador' . $uid . '@pangyacommunity.local';

$payload = [
    'transaction_amount' => (float) $package['price'],
    'description'        => 'PangYa Community - ' . $package['label'],
    'payment_method_id'  => $isPix ? 'pix' : $paymentMethodId,
    'payer' => [
        'email' => $payerEmail,
    ],
    'external_reference' => 'donation-' . $donationId,
    'notification_url'   => rtrim((string) ($input['site_url'] ?? ''), '/') . '/Donation/mp_webhook.php',
];

if (!$isPix) {
    $payload['token'] = (string) $input['token'];
    $payload['installments'] = max(1, (int) ($input['installments'] ?? 1));
    if (!empty($input['issuer_id'])) {
        $payload['issuer_id'] = $input['issuer_id'];
    }
    if (!empty($input['payer']['identification'])) {
        $payload['payer']['identification'] = $input['payer']['identification'];
    }
}

try {
    $mp = new MercadoPagoClient(MP_ACCESS_TOKEN);
    $result = $mp->createPayment($payload, 'donation-' . $donationId . '-' . bin2hex(random_bytes(4)));

    $status = (string) ($result['status'] ?? 'unknown');
    $paymentId = isset($result['id']) ? (string) $result['id'] : null;

    if (($result['_http_status'] ?? 500) >= 400) {
        $reason = $result['message'] ?? ($result['cause'][0]['description'] ?? 'Pagamento recusado.');
        $donationService->markStatus($donationId, 'rejected', $paymentId, json_encode($result, JSON_UNESCAPED_UNICODE));
        jsonFail($reason);
    }

    if ($status === 'approved') {
        $donationService->approveAndCredit($donationId, $paymentId, json_encode($result, JSON_UNESCAPED_UNICODE));

        echo json_encode([
            'status'  => 'success',
            'paid'    => true,
            'message' => 'Pagamento aprovado! Seus créditos já foram adicionados à conta.',
        ]);
        exit;
    }

    if ($status === 'pending' || $status === 'in_process') {
        $donationService->markStatus($donationId, $isPix ? 'awaiting_pix' : 'pending', $paymentId, json_encode($result, JSON_UNESCAPED_UNICODE));

        $response = [
            'status'  => 'success',
            'paid'    => false,
            'message' => $isPix ? 'Pix gerado. Escaneie o QR Code ou copie o código para pagar.' : 'Pagamento em análise.',
        ];

        if ($isPix) {
            $poiData = $result['point_of_interaction']['transaction_data'] ?? [];
            $response['pix'] = [
                'qr_code'     => $poiData['qr_code'] ?? null,
                'qr_code_b64' => $poiData['qr_code_base64'] ?? null,
                'donation_id' => $donationId,
            ];
        }

        echo json_encode($response);
        exit;
    }

    $donationService->markStatus($donationId, 'rejected', $paymentId, json_encode($result, JSON_UNESCAPED_UNICODE));
    jsonFail('Pagamento não aprovado (' . $status . '). Tente outro cartão ou meio de pagamento.');

} catch (Throwable $e) {
    error_log('Erro no checkout Mercado Pago: ' . $e->getMessage());
    jsonFail('Erro ao comunicar com o Mercado Pago. Tente novamente em instantes.', 500);
}
