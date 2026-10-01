<?php
/**
 * config.php
 * -----------------------------------------------------------------------
 * Arquivo central de conexão com o banco de dados SQL Server através de
 * uma fonte de dados ODBC do sistema (System DSN), configurada previamente
 * no Painel de Controle do Windows / Servidor
 * (Ferramentas Administrativas > Fontes de Dados ODBC (64 bits)).
 *
 * IMPORTANTE:
 *  - Se o DSN já tiver usuário/senha do SQL Server configurados, você
 *    pode deixar UID/PWD do PDO em branco. Caso o DSN use autenticação
 *    do Windows, também não é necessário enviar UID/PWD aqui.
 * -----------------------------------------------------------------------
 */

// Nome do System DSN configurado no servidor
define('DSN_NAME', 'pangya');

// Credenciais do SQL Server (deixe em branco se o DSN já as define)
define('DB_USER', 'sa');
define('DB_PASS', '@pangya');

/**
 * -----------------------------------------------------------------------
 * OPCIONAL: driver sqlsrv/pdo_sqlsrv (recomendado para Unicode/Shift-JIS)
 * -----------------------------------------------------------------------
 * Preencha DB_SERVER e DB_DATABASE abaixo e instale a extensão
 * "pdo_sqlsrv" (Microsoft Drivers for PHP for SQL Server) para que o
 * site passe a usar esse driver automaticamente em vez do PDO_ODBC.
 * Deixe DB_SERVER em branco para continuar usando o DSN/ODBC atual.
 *
 * Exemplo: define('DB_SERVER', 'localhost\\SQLEXPRESS');
 */
define('DB_SERVER', 'localhost');      // ex.: 'localhost' ou 'NOME_DO_SERVIDOR\\INSTANCIA'
define('DB_DATABASE', 'pangya');

/**
 * -----------------------------------------------------------------------
 * Gateways de pagamento (doações / recarga de Pang & Cookie)
 * -----------------------------------------------------------------------
 * Preencha com as credenciais reais da sua conta antes de colocar em
 * produção. As credenciais de teste (sandbox) servem só para validar o
 * fluxo sem mexer em dinheiro de verdade.
 */

// Mercado Pago (https://www.mercadopago.com.br/developers/panel/app)
define('MP_PUBLIC_KEY', 'APP_USR-1a9b951c-f2db-43cc-bde0-9daad4d431ba');
define('MP_ACCESS_TOKEN', 'APP_USR-503348620746302-072615-ea43a8267412b51ba09171dc2d1a8246-3295901167');

// PayPal (https://developer.paypal.com/dashboard/applications)
define('PAYPAL_CLIENT_ID', 'AYL-fCfBsoEnJDUJkpLZhJ1FifgxfoS2ygXUIFsonAg8aqoc9MnLz_ANvk1ruksMHjQ1tAWkPc8Mnm17');
define('PAYPAL_SECRET', 'AYL-fCfBsoEnJDUJkpLZhJ1FifgxfoS2ygXUIFsonAg8aqoc9MnLz_ANvk1ruksMHjQ1tAWkPc8Mnm17');
define('PAYPAL_MODE', 'sandbox'); // 'sandbox' ou 'live'

// Cotação usada só pra exibir valores aproximados de Pang/Cookie no PayPal (cobrado em BRL mesmo)
define('DONATION_CURRENCY', 'BRL');

// Sessão precisa estar ativa em (quase) todas as páginas
if (session_status() === PHP_SESSION_NONE) {
    session_start();
}

require_once __DIR__ . '/../includes/i18n.php';
require_once __DIR__ . '/permissions.php';

function getConnection(): PDO
{
    static $pdo = null;

    if ($pdo === null) {
        $pdoOptions = [
            PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
            PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC,
        ];

        if (DB_SERVER !== '' && in_array('sqlsrv', PDO::getAvailableDrivers(), true)) {
            $connStr = 'sqlsrv:Server=' . DB_SERVER . ';Database=' . DB_DATABASE . ';CharacterSet=UTF-8';

            try {
                $pdo = new PDO($connStr, DB_USER, DB_PASS, $pdoOptions);
                return $pdo;
            } catch (PDOException $e) {
                error_log('Falha na conexão com o banco (PDO_SQLSRV): ' . $e->getMessage());
                throw $e;
            }
        }

        // Caminho padrão: PDO_ODBC via System DSN (sujeito à limitação de
        // Unicode descrita acima para caracteres fora do code page ANSI).
        $connStr = 'odbc:DSN=' . DSN_NAME;

        try {
            $pdo = new PDO($connStr, DB_USER, DB_PASS, $pdoOptions);
        } catch (PDOException $e) {
            error_log('Falha na conexão com o banco (System DSN): ' . $e->getMessage());
            throw $e;
        }
    }

    return $pdo;
}

/**
 * Captura o IP real do cliente, considerando proxies/load balancers comuns.
 */
function getClientIp(): string
{
    $headers = ['HTTP_CF_CONNECTING_IP', 'HTTP_X_FORWARDED_FOR', 'HTTP_CLIENT_IP', 'REMOTE_ADDR'];

    foreach ($headers as $header) {
        if (!empty($_SERVER[$header])) {
            $ipList = explode(',', $_SERVER[$header]);
            $ip = trim($ipList[0]);
            if (filter_var($ip, FILTER_VALIDATE_IP)) {
                return substr($ip, 0, 20); // respeita NVARCHAR(20) do banco
            }
        }
    }

    return '0.0.0.0';
}

/**
 * Gera o hash de senha no formato esperado pelas procedures
 * (MD5 em maiúsculas).
 */
function hashPassword(string $plainPassword): string
{
    return strtoupper(md5($plainPassword));
}
