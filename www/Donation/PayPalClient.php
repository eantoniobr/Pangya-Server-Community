<?php

final class PayPalClient
{
    private string $apiBase;
    private ?string $token = null;

    public function __construct(private string $clientId, private string $secret, string $mode = 'sandbox')
    {
        $this->apiBase = $mode === 'live'
            ? 'https://api-m.paypal.com'
            : 'https://api-m.sandbox.paypal.com';
    }

    private function accessToken(): string
    {
        if ($this->token !== null) {
            return $this->token;
        }

        $ch = curl_init($this->apiBase . '/v1/oauth2/token');
        curl_setopt_array($ch, [
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_POST           => true,
            CURLOPT_USERPWD        => $this->clientId . ':' . $this->secret,
            CURLOPT_POSTFIELDS     => 'grant_type=client_credentials',
            CURLOPT_TIMEOUT        => 20,
        ]);

        $body = curl_exec($ch);
        curl_close($ch);

        $data = json_decode((string) $body, true) ?? [];

        if (empty($data['access_token'])) {
            throw new RuntimeException('Não foi possível autenticar com o PayPal.');
        }

        return $this->token = $data['access_token'];
    }

    /**
     * Cria a ordem de pagamento. O valor SEMPRE vem do pacote validado no
     * servidor (nunca do que o front manda), pra ninguém adulterar o preço.
     */
    public function createOrder(float $amount, string $currency, string $reference, string $description): array
    {
        return $this->request('POST', '/v2/checkout/orders', [
            'intent' => 'CAPTURE',
            'purchase_units' => [[
                'reference_id' => $reference,
                'description'  => $description,
                'amount' => [
                    'currency_code' => $currency,
                    'value'         => number_format($amount, 2, '.', ''),
                ],
            ]],
        ]);
    }

    public function captureOrder(string $orderId): array
    {
        return $this->request('POST', '/v2/checkout/orders/' . urlencode($orderId) . '/capture');
    }

    private function request(string $method, string $path, ?array $payload = null): array
    {
        $ch = curl_init($this->apiBase . $path);

        curl_setopt_array($ch, [
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_CUSTOMREQUEST  => $method,
            CURLOPT_HTTPHEADER     => [
                'Authorization: Bearer ' . $this->accessToken(),
                'Content-Type: application/json',
            ],
            CURLOPT_TIMEOUT => 20,
        ]);

        if ($payload !== null) {
            curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($payload, JSON_UNESCAPED_UNICODE));
        }

        $body = curl_exec($ch);
        $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        curl_close($ch);

        $decoded = json_decode((string) $body, true) ?? [];
        $decoded['_http_status'] = $httpCode;

        return $decoded;
    }
}
