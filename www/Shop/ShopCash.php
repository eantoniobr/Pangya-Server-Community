<?php

require_once __DIR__ . '/../Config/config.php';
require_once __DIR__ . '/../includes/functions.php';
require_once __DIR__ . '/../Donation/DonationService.php';

requireLogin();

$uid = (int) $_SESSION['uid'];

$balances = ['Pang' => 0, 'Cookie' => 0];

try {
    $statement = getConnection()->prepare(
        'SELECT [Pang], [Cookie] FROM pangya.user_info WHERE [UID] = ?'
    );
    $statement->execute([$uid]);
    $balances = $statement->fetch() ?: $balances;
} catch (PDOException $exception) {
    error_log('Saldo da loja: ' . $exception->getMessage());
}

$donationHistory = [];
try {
    $donationHistory = (new DonationService())->history($uid, 8);
} catch (PDOException $exception) {
    error_log('Histórico de doações: ' . $exception->getMessage());
}

$packages = DonationService::packages();
$cookiePackages = array_filter($packages, fn ($p) => $p['currency'] === 'Cookie');
$pangPackages = array_filter($packages, fn ($p) => $p['currency'] === 'Pang');

$pageTitle = t('dash_donations');
require __DIR__ . '/../includes/header.php';
?>

<script src="https://sdk.mercadopago.com/js/v2"></script>
<script src="https://www.paypal.com/sdk/js?client-id=<?= urlencode(PAYPAL_CLIENT_ID) ?>&currency=<?= urlencode(DONATION_CURRENCY) ?>&intent=capture"></script>

<div class="d-flex flex-wrap justify-content-between align-items-center gap-2 mb-4">
    <h2 class="mb-0">💳 <?= htmlspecialchars(t('dash_donations')) ?></h2>
    <div class="btn-group">
        <a class="btn btn-outline-light btn-sm" href="ShopItem.php"><?= htmlspecialchars(t('shop_items')) ?></a>
        <a class="btn btn-outline-light btn-sm" href="ShopSale.php"><?= htmlspecialchars(t('marketplace')) ?></a>
    </div>
</div>

<div id="alert-container">
    <?php if (isset($_SESSION['flash_success'])): ?>
        <div class="alert alert-success alert-dismissible fade show" role="alert">
            <?= htmlspecialchars($_SESSION['flash_success']) ?>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <?php unset($_SESSION['flash_success']); ?>
    <?php endif; ?>
</div>

<!-- Saldo Atual -->
<div class="row g-3 mb-4">
    <div class="col-md-6">
        <div class="card p-3 bg-dark text-white border-secondary">
            <div class="d-flex align-items-center justify-content-between">
                <div>
                    <div class="text-secondary small fw-bold"><?= htmlspecialchars(t('current_balance')) ?></div>
                    <div class="display-6 fw-bold text-info">
                        <span id="pang-balance"><?= number_format((int) $balances['Pang'], 0, ',', '.') ?></span>
                        <small class="fs-6">Pangs</small>
                    </div>
                </div>
                <img src="/assets/img/bar/BtnPang.png" alt="Pang" width="40" height="40" onerror="this.style.display='none'">
            </div>
        </div>
    </div>
    <div class="col-md-6">
        <div class="card p-3 bg-dark text-white border-secondary">
            <div class="d-flex align-items-center justify-content-between">
                <div>
                    <div class="text-secondary small fw-bold"><?= htmlspecialchars(t('current_balance')) ?></div>
                    <div class="display-6 fw-bold text-warning">
                        <span id="cookie-balance"><?= number_format((int) $balances['Cookie'], 0, ',', '.') ?></span>
                        <small class="fs-6">Cookies</small>
                    </div>
                </div>
                <img src="/assets/img/bar/BtnCookie.png" alt="Cookie" width="40" height="40" onerror="this.style.display='none'">
            </div>
        </div>
    </div>
</div>

<ul class="nav nav-tabs border-secondary mb-4" id="rechargeTabs" role="tablist">
    <li class="nav-item" role="presentation">
        <button class="nav-link active fw-bold" data-bs-toggle="tab" data-bs-target="#buy-panel" type="button">💳 <?= htmlspecialchars(t('buy_packages')) ?></button>
    </li>
    <li class="nav-item" role="presentation">
        <button class="nav-link fw-bold" data-bs-toggle="tab" data-bs-target="#epin-panel" type="button">🎟️ <?= htmlspecialchars(t('redeem_epin')) ?></button>
    </li>
    <li class="nav-item" role="presentation">
        <button class="nav-link fw-bold" data-bs-toggle="tab" data-bs-target="#history-panel" type="button">📜 <?= htmlspecialchars(t('my_history')) ?></button>
    </li>
</ul>

<div class="tab-content" id="rechargeTabsContent">

    <!-- ABA 1: PACOTES -->
    <div class="tab-pane fade show active" id="buy-panel" role="tabpanel">

        <?php foreach (['Cookies' => $cookiePackages, 'Pang' => $pangPackages] as $title => $section): ?>
            <h4 class="mb-3 d-flex align-items-center gap-2">
                <span><?= htmlspecialchars(sprintf(t('packages_' . strtolower($title)), $title)) ?></span>
            </h4>
            <div class="row g-3 mb-5">
                <?php foreach ($section as $id => $item): ?>
                    <div class="col-sm-6 col-lg-3">
                        <div class="card h-100 bg-dark text-white border-secondary position-relative">
                            <?php if (!empty($item['popular'])): ?>
                                <span class="position-absolute top-0 start-50 translate-middle badge rounded-pill bg-danger"><?= htmlspecialchars(t('most_popular')) ?></span>
                            <?php endif; ?>
                            <div class="card-body d-flex flex-column text-center p-4">
                                <h5 class="card-title text-secondary mb-1"><?= htmlspecialchars($item['label']) ?></h5>
                                <?php if (!empty($item['bonus'])): ?>
                                    <span class="badge bg-success w-auto mx-auto mb-3"><?= htmlspecialchars($item['bonus']) ?></span>
                                <?php else: ?>
                                    <div class="mb-3" style="height: 21px;"></div>
                                <?php endif; ?>
                                <div class="my-auto py-2">
                                    <span class="fs-3 fw-bold">R$ <?= number_format($item['price'], 2, ',', '.') ?></span>
                                </div>
                                <button
                                    type="button"
                                    class="btn btn-primary w-100 btn-open-checkout"
                                    data-package-id="<?= htmlspecialchars($id) ?>"
                                    data-package-label="<?= htmlspecialchars($item['label']) ?>"
                                    data-package-price="<?= htmlspecialchars(number_format($item['price'], 2, '.', '')) ?>"
                                >
                                    <?= htmlspecialchars(t('donate_now')) ?>
                                </button>
                            </div>
                        </div>
                    </div>
                <?php endforeach; ?>
            </div>
        <?php endforeach; ?>

        <div class="card p-4 bg-dark text-white border-secondary mb-4">
            <div class="d-flex align-items-center gap-3">
                <div class="fs-1 text-info"><i class="bi bi-shield-check"></i></div>
                <div>
                    <h5 class="mb-1"><?= htmlspecialchars(t('payment_direct_title')) ?></h5>
                    <p class="mb-0 text-secondary small">
                        <?= htmlspecialchars(t('payment_direct_desc')) ?>
                    </p>
                </div>
            </div>
        </div>
    </div>

    <!-- ABA 2: EPIN -->
    <div class="tab-pane fade" id="epin-panel" role="tabpanel">
        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">
                <div class="card bg-dark text-white border-secondary p-4">
                    <h4 class="mb-3 text-center"><?= htmlspecialchars(t('activate_epin')) ?></h4>
                    <p class="text-secondary text-center small mb-4">
                        <?= htmlspecialchars(t('epin_desc')) ?>
                    </p>
                    <form id="form-epin" method="post" action="/Donation/process_epin.php">
                        <input type="hidden" name="csrf_token" value="<?= htmlspecialchars(csrfToken()) ?>">
                        <div class="mb-3">
                            <label for="epin_code" class="form-label fw-bold"><?= htmlspecialchars(t('epin_code')) ?></label>
                            <input type="text" id="epin_code" name="epin_code" class="form-control form-control-lg bg-dark text-white border-secondary text-center text-uppercase font-monospace" placeholder="XXXX-XXXX-XXXX-XXXX" required maxlength="36" autocomplete="off">
                        </div>
                        <button type="submit" id="btn-redeem-epin" class="btn btn-success btn-lg w-100 mt-2"><?= htmlspecialchars(t('redeem_code')) ?></button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- ABA 3: HISTÓRICO -->
    <div class="tab-pane fade" id="history-panel" role="tabpanel">
        <?php if (empty($donationHistory)): ?>
            <p class="text-secondary"><?= htmlspecialchars(t('no_donations_yet')) ?></p>
        <?php else: ?>
            <div class="table-responsive">
                <table class="table table-dark table-striped align-middle">
                    <thead>
                        <tr>
                            <th><?= htmlspecialchars(t('date')) ?></th>
                            <th><?= htmlspecialchars(t('package')) ?></th>
                            <th><?= htmlspecialchars(t('method')) ?></th>
                            <th><?= htmlspecialchars(t('value')) ?></th>
                            <th><?= htmlspecialchars(t('status')) ?></th>
                        </tr>
                    </thead>
                    <tbody>
                        <?php foreach ($donationHistory as $row): ?>
                            <?php
                                $statusMap = [
                                    'paid'         => ['label' => t('status_paid'), 'class' => 'success'],
                                    'pending'      => ['label' => t('status_pending'), 'class' => 'warning'],
                                    'awaiting_pix' => ['label' => t('status_awaiting_pix'), 'class' => 'warning'],
                                    'rejected'     => ['label' => t('status_rejected'), 'class' => 'danger'],
                                ];
                                $statusInfo = $statusMap[$row['status']] ?? ['label' => $row['status'], 'class' => 'secondary'];
                            ?>
                            <tr>
                                <td><?= htmlspecialchars((new DateTime($row['created_at']))->format('d/m/Y H:i')) ?></td>
                                <td><?= (int) $row['amount'] ?> <?= htmlspecialchars($row['currency']) ?></td>
                                <td class="text-capitalize"><?= htmlspecialchars($row['provider']) ?></td>
                                <td>R$ <?= number_format((float) $row['price_brl'], 2, ',', '.') ?></td>
                                <td><span class="badge bg-<?= $statusInfo['class'] ?>"><?= htmlspecialchars($statusInfo['label']) ?></span></td>
                            </tr>
                        <?php endforeach; ?>
                    </tbody>
                </table>
            </div>
        <?php endif; ?>
    </div>

</div>

<!-- Modal de Checkout -->
<div class="modal fade" id="checkoutModal" tabindex="-1" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content bg-dark text-light border-secondary">
            <div class="modal-header border-secondary">
                <h5 class="modal-title"><?= htmlspecialchars(t('finish_donation')) ?> — <span id="checkoutPackageLabel"></span></h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal"></button>
            </div>
            <div class="modal-body">
                <p class="text-center mb-4">
                    <?= htmlspecialchars(t('value')) ?>: <strong id="checkoutPackagePrice" class="text-info fs-5"></strong>
                </p>

                <ul class="nav nav-pills nav-justified mb-3" id="paymentMethodTabs">
                    <li class="nav-item">
                        <button class="nav-link active" data-bs-toggle="pill" data-bs-target="#pane-pix" type="button">Pix</button>
                    </li>
                    <li class="nav-item">
                        <button class="nav-link" data-bs-toggle="pill" data-bs-target="#pane-card" type="button"><?= htmlspecialchars(t('card')) ?></button>
                    </li>
                    <li class="nav-item">
                        <button class="nav-link" data-bs-toggle="pill" data-bs-target="#pane-paypal" type="button"><?= htmlspecialchars(t('paypal')) ?></button>
                    </li>
                </ul>

                <div class="tab-content">
                    <!-- PIX -->
                    <div class="tab-pane fade show active" id="pane-pix">
                        <div id="pixIdle" class="text-center py-3">
                            <p class="text-secondary small mb-3"><?= htmlspecialchars(t('pix_desc')) ?></p>
                            <button type="button" class="btn btn-success w-100" id="btnGeneratePix"><?= htmlspecialchars(t('generate_pix')) ?></button>
                        </div>
                        <div id="pixResult" class="text-center d-none">
                            <img id="pixQrImage" src="" alt="QR Code Pix" class="img-fluid rounded mb-3" style="max-width:220px;">
                            <div class="input-group mb-2">
                                <input type="text" id="pixCopyPaste" class="form-control form-control-sm bg-dark text-light border-secondary" readonly>
                                <button class="btn btn-outline-light btn-sm" type="button" id="btnCopyPix"><?= htmlspecialchars(t('copy')) ?></button>
                            </div>
                            <div class="small text-warning" id="pixWaiting">
                                <span class="spinner-border spinner-border-sm me-1"></span> <?= htmlspecialchars(t('waiting_payment_confirmation')) ?>
                            </div>
                        </div>
                    </div>

                    <!-- CARTÃO (checkout transparente) -->
                    <div class="tab-pane fade" id="pane-card">
                        <form id="cardForm">
                            <div class="mb-2">
                                <input type="text" id="form-checkout__cardNumber" class="form-control bg-dark text-light border-secondary" placeholder="<?= htmlspecialchars(t('card_number')) ?>" autocomplete="cc-number">
                            </div>
                            <div class="row g-2 mb-2">
                                <div class="col-6">
                                    <input type="text" id="form-checkout__expirationDate" class="form-control bg-dark text-light border-secondary" placeholder="<?= htmlspecialchars(t('card_expiration')) ?>" autocomplete="cc-exp">
                                </div>
                                <div class="col-6">
                                    <input type="text" id="form-checkout__securityCode" class="form-control bg-dark text-light border-secondary" placeholder="<?= htmlspecialchars(t('card_cvv')) ?>" autocomplete="cc-csc">
                                </div>
                            </div>
                            <div class="mb-2">
                                <input type="text" id="form-checkout__cardholderName" class="form-control bg-dark text-light border-secondary" placeholder="<?= htmlspecialchars(t('card_holder')) ?>" autocomplete="cc-name">
                            </div>
                            <div class="row g-2 mb-2">
                                <div class="col-6">
                                    <select id="form-checkout__issuer" class="form-select bg-dark text-light border-secondary"></select>
                                </div>
                                <div class="col-6">
                                    <select id="form-checkout__installments" class="form-select bg-dark text-light border-secondary"></select>
                                </div>
                            </div>
                            <div class="row g-2 mb-3">
                                <div class="col-6">
                                    <select id="form-checkout__identificationType" class="form-select bg-dark text-light border-secondary"></select>
                                </div>
                                <div class="col-6">
                                    <input type="text" id="form-checkout__identificationNumber" class="form-control bg-dark text-light border-secondary" placeholder="<?= htmlspecialchars(t('cpf')) ?>">
                                </div>
                            </div>
                            <input type="hidden" id="form-checkout__cardExpirationMonth">
                            <input type="hidden" id="form-checkout__cardExpirationYear">
                            <button type="submit" id="btnPayCard" class="btn btn-primary w-100"><?= htmlspecialchars(t('pay_with_card')) ?></button>
                        </form>
                    </div>

                    <!-- PAYPAL -->
                    <div class="tab-pane fade" id="pane-paypal">
                        <p class="text-secondary small text-center mb-3"><?= htmlspecialchars(t('paypal_redirect_desc')) ?></p>
                        <div id="paypal-button-container"></div>
                    </div>
                </div>

                <div id="checkoutFeedback" class="alert d-none mt-3 mb-0" role="alert"></div>
            </div>
        </div>
    </div>
</div>

<script>
document.addEventListener('DOMContentLoaded', function () {
    const csrfToken = <?= json_encode(csrfToken()) ?>;
    const mpPublicKey = <?= json_encode(MP_PUBLIC_KEY) ?>;
    const mp = new MercadoPago(mpPublicKey, { locale: 'pt-BR' });

    const checkoutModalEl = document.getElementById('checkoutModal');
    const checkoutModal = new bootstrap.Modal(checkoutModalEl);
    const feedbackEl = document.getElementById('checkoutFeedback');

    let currentPackageId = null;
    let currentPackagePrice = null;
    let currentPackageLabel = null;
    let cardForm = null;
    let pixPollTimer = null;

    function showFeedback(type, message) {
        feedbackEl.className = 'alert alert-' + type + ' mt-3 mb-0';
        feedbackEl.textContent = message;
    }

    function resetFeedback() {
        feedbackEl.className = 'alert d-none mt-3 mb-0';
        feedbackEl.textContent = '';
    }

    function updateBalances() {
        window.location.reload();
    }

    document.querySelectorAll('.btn-open-checkout').forEach(function (btn) {
        btn.addEventListener('click', function () {
            currentPackageId = btn.dataset.packageId;
            currentPackagePrice = btn.dataset.packagePrice;
            currentPackageLabel = btn.dataset.packageLabel;

            document.getElementById('checkoutPackageLabel').textContent = currentPackageLabel;
            document.getElementById('checkoutPackagePrice').textContent = 'R$ ' + parseFloat(currentPackagePrice).toFixed(2).replace('.', ',');

            document.getElementById('pixIdle').classList.remove('d-none');
            document.getElementById('pixResult').classList.add('d-none');
            resetFeedback();
            clearInterval(pixPollTimer);

            initCardForm();
            initPayPalButtons();

            checkoutModal.show();
        });
    });

    document.getElementById('btnGeneratePix').addEventListener('click', function () {
        resetFeedback();
        const btn = this;
        btn.disabled = true;
        btn.textContent = 'Gerando...';

        fetch('/Donation/mp_pay.php', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                csrf_token: csrfToken,
                package_id: currentPackageId,
                payment_method_id: 'pix',
                site_url: window.location.origin,
            }),
        })
        .then(r => r.json())
        .then(data => {
            btn.disabled = false;
            btn.textContent = 'Gerar Pix';

            if (data.status !== 'success') {
                showFeedback('danger', data.message || 'Não foi possível gerar o Pix.');
                return;
            }

            if (data.pix && data.pix.qr_code_b64) {
                document.getElementById('pixQrImage').src = 'data:image/png;base64,' + data.pix.qr_code_b64;
                document.getElementById('pixCopyPaste').value = data.pix.qr_code || '';
                document.getElementById('pixIdle').classList.add('d-none');
                document.getElementById('pixResult').classList.remove('d-none');

                pixPollTimer = setInterval(function () {
                    fetch('/Donation/mp_check_status.php?donation_id=' + data.pix.donation_id)
                        .then(r => r.json())
                        .then(status => {
                            if (status.paid) {
                                clearInterval(pixPollTimer);
                                document.getElementById('pixWaiting').innerHTML = '<span class="text-success">✔ Pagamento confirmado! Atualizando saldo...</span>';
                                setTimeout(updateBalances, 1500);
                            }
                        });
                }, 4000);
            } else {
                showFeedback('success', data.message || 'Pagamento em processamento.');
            }
        })
        .catch(() => {
            btn.disabled = false;
            btn.textContent = 'Gerar Pix';
            showFeedback('danger', 'Erro de comunicação com o servidor.');
        });
    });

    document.getElementById('btnCopyPix').addEventListener('click', function () {
        const input = document.getElementById('pixCopyPaste');
        input.select();
        navigator.clipboard.writeText(input.value).then(() => {
            this.textContent = '<?= htmlspecialchars(t('copied')) ?>';
            setTimeout(() => { this.textContent = '<?= htmlspecialchars(t('copy')) ?>'; }, 1500);
        });
    });

    function initCardForm() {
        if (cardForm) {
            cardForm.unmount();
            cardForm = null;
        }

        cardForm = mp.cardForm({
            amount: String(currentPackagePrice),
            iframe: true,
            form: {
                id: 'cardForm',
                cardNumber: { id: 'form-checkout__cardNumber', placeholder: 'Número do cartão' },
                expirationDate: { id: 'form-checkout__expirationDate', placeholder: 'MM/AA' },
                securityCode: { id: 'form-checkout__securityCode', placeholder: 'CVV' },
                cardholderName: { id: 'form-checkout__cardholderName', placeholder: 'Titular do cartão' },
                issuer: { id: 'form-checkout__issuer', placeholder: 'Banco emissor' },
                installments: { id: 'form-checkout__installments', placeholder: 'Parcelas' },
                identificationType: { id: 'form-checkout__identificationType' },
                identificationNumber: { id: 'form-checkout__identificationNumber', placeholder: 'CPF do titular' },
                cardholderEmail: { id: 'form-checkout__cardholderEmail' },
            },
            callbacks: {
                onFormMounted: function (error) {
                    if (error) console.warn('Formulário de cartão: ', error);
                },
                onSubmit: function (event) {
                    event.preventDefault();
                    const data = cardForm.getCardFormData();
                    const submitBtn = document.getElementById('btnPayCard');
                    submitBtn.disabled = true;
                    submitBtn.textContent = 'Processando...';
                    resetFeedback();

                    fetch('/Donation/mp_pay.php', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({
                            csrf_token: csrfToken,
                            package_id: currentPackageId,
                            payment_method_id: data.paymentMethodId,
                            token: data.token,
                            installments: data.installments,
                            issuer_id: data.issuerId,
                            payer: {
                                identification: {
                                    type: data.identificationType,
                                    number: data.identificationNumber,
                                },
                            },
                            site_url: window.location.origin,
                        }),
                    })
                    .then(r => r.json())
                    .then(result => {
                        submitBtn.disabled = false;
                        submitBtn.textContent = 'Pagar com cartão';

                        if (result.status === 'success' && result.paid) {
                            showFeedback('success', result.message);
                            setTimeout(updateBalances, 1500);
                        } else {
                            showFeedback('danger', result.message || 'Pagamento não aprovado.');
                        }
                    })
                    .catch(() => {
                        submitBtn.disabled = false;
                        submitBtn.textContent = 'Pagar com cartão';
                        showFeedback('danger', 'Erro de comunicação com o Mercado Pago.');
                    });
                },
            },
        });
    }

    let paypalButtonsRendered = false;
    function initPayPalButtons() {
        const container = document.getElementById('paypal-button-container');
        if (paypalButtonsRendered) {
            container.innerHTML = '';
        }
        paypalButtonsRendered = true;

        paypal.Buttons({
            createOrder: function () {
                return fetch('/Donation/paypal_create_order.php', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ csrf_token: csrfToken, package_id: currentPackageId }),
                })
                .then(r => r.json())
                .then(data => {
                    if (data.status !== 'success') {
                        showFeedback('danger', data.message || 'Não foi possível iniciar o pagamento.');
                        throw new Error(data.message);
                    }
                    return data.order_id;
                });
            },
            onApprove: function (data) {
                return fetch('/Donation/paypal_capture.php', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ order_id: data.orderID }),
                })
                .then(r => r.json())
                .then(result => {
                    if (result.status === 'success') {
                        showFeedback('success', result.message);
                        setTimeout(updateBalances, 1500);
                    } else {
                        showFeedback('danger', result.message || 'Falha ao confirmar o pagamento.');
                    }
                });
            },
            onError: function () {
                showFeedback('danger', 'Ocorreu um erro no pagamento via PayPal.');
            },
        }).render('#paypal-button-container');
    }

    const alertContainer = document.getElementById('alert-container');
    function showAlert(type, message) {
        alertContainer.innerHTML = '<div class="alert alert-' + type + ' alert-dismissible fade show" role="alert">' + message + '<button type="button" class="btn-close" data-bs-dismiss="alert"></button></div>';
    }

    const epinForm = document.getElementById('form-epin');
    if (epinForm) {
        epinForm.addEventListener('submit', function (e) {
            e.preventDefault();
            const btn = document.getElementById('btn-redeem-epin');
            btn.disabled = true;
            btn.innerText = 'Processando...';

            fetch(epinForm.action, {
                method: 'POST',
                body: new FormData(epinForm),
                headers: { 'X-Requested-With': 'XMLHttpRequest' },
            })
            .then(res => res.json())
            .then(data => {
                btn.disabled = false;
                btn.innerText = 'Resgatar Código';

                if (data.status === 'success') {
                    showAlert('success', data.message);
                    if (data.new_cookie_balance !== undefined) {
                        document.getElementById('cookie-balance').innerText = new Intl.NumberFormat('pt-BR').format(data.new_cookie_balance);
                    }
                    if (data.new_pang_balance !== undefined) {
                        document.getElementById('pang-balance').innerText = new Intl.NumberFormat('pt-BR').format(data.new_pang_balance);
                    }
                    epinForm.reset();
                } else {
                    showAlert('danger', data.message || 'Erro ao resgatar o código EPIN.');
                }
            })
            .catch(() => {
                btn.disabled = false;
                btn.innerText = 'Resgatar Código';
                showAlert('danger', 'Ocorreu um erro ao comunicar com o servidor.');
            });
        });
    }
});
</script>

<?php require __DIR__ . '/../includes/footer.php'; ?>