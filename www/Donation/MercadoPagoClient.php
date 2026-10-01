<?php

final class MercadoPagoClient
{
    private const API_BASE = 'https://api.mercadopago.com';

    public function __construct(private string $accessToken)
    {
    }

    /**
     * Cria um pagamento direto via API (Checkout Transparente).
     * Serve tanto pra cartão (com card_token gerado no front) quanto pra Pix.
     */
    public function createPayment(array $payload, string $idempotencyKey): array
    {
        return $this->request('POST', '/v1/payments', $payload, [
            'X-Idempotency-Key: ' . $idempotencyKey,
        ]);
    }

    public function getPayment(string $paymentId): array
    {
        return $this->request('GET', '/v1/payments/' . urlencode($paymentId));
    }

    private function request(string $method, string $path, ?array $payload = null, array $extraHeaders = []): array
    {
        $ch = curl_init(self::API_BASE . $path);

        $headers = array_merge([
            'Authorization: Bearer ' . $this->accessToken,
            'Content-Type: application/json',
        ], $extraHeaders);

        curl_setopt_array($ch, [
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_CUSTOMREQUEST  => $method,
            CURLOPT_HTTPHEADER     => $headers,
            CURLOPT_TIMEOUT        => 20,
        ]);

        if ($payload !== null) {
            curl_setopt($ch, CURLOPT_POSTFIELDS, json_encode($payload, JSON_UNESCAPED_UNICODE));
        }

        $body = curl_exec($ch);
        $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        $error = curl_error($ch);
        curl_close($ch);

        if ($body === false) {
            throw new RuntimeException('Falha de conexão com o Mercado Pago: ' . $error);
        }

        $decoded = json_decode($body, true) ?? [];
        $decoded['_http_status'] = $httpCode;

        return $decoded;
    }
}
