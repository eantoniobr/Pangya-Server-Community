IF COL_LENGTH('pangya.pangya_item_warehouse', 'item_id') IS NULL
BEGIN
    THROW 50001, 'A tabela pangya.pangya_item_warehouse precisa expor a coluna única item_id antes da implantação.', 1;
END;
GO

IF OBJECT_ID('pangya.web_audit_log', 'U') IS NULL
BEGIN
    CREATE TABLE pangya.web_audit_log (
        audit_id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        actor_uid INT NOT NULL,
        action NVARCHAR(80) NOT NULL,
        item_id INT NULL,
        ip_address NVARCHAR(45) NOT NULL,
        details NVARCHAR(MAX) NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_web_audit_log_created_at DEFAULT SYSUTCDATETIME()
    );
    CREATE INDEX IX_web_audit_log_actor_created ON pangya.web_audit_log(actor_uid, created_at DESC);
END;
GO

IF OBJECT_ID('pangya.web_marketplace_listing', 'U') IS NULL
BEGIN
    CREATE TABLE pangya.web_marketplace_listing (
        listing_id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        seller_uid INT NOT NULL,
        item_id INT NOT NULL,
        typeid INT NOT NULL,
        price BIGINT NOT NULL CHECK (price > 0),
        currency VARCHAR(10) NOT NULL CHECK (currency IN ('Pang', 'Cookie')),
        status VARCHAR(10) NOT NULL CONSTRAINT DF_web_marketplace_listing_status DEFAULT 'active',
        buyer_uid INT NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_web_marketplace_listing_created_at DEFAULT SYSUTCDATETIME(),
        sold_at DATETIME2 NULL
    );
    CREATE UNIQUE INDEX UX_web_marketplace_listing_active_item
        ON pangya.web_marketplace_listing(item_id)
        WHERE status = 'active';
    CREATE INDEX IX_web_marketplace_listing_active ON pangya.web_marketplace_listing(status, created_at DESC);
END;
GO

IF OBJECT_ID('pangya.web_shop_transaction', 'U') IS NULL
BEGIN
    CREATE TABLE pangya.web_shop_transaction (
        transaction_id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        buyer_uid INT NOT NULL,
        seller_uid INT NULL,
        item_id INT NULL,
        typeid INT NULL,
        amount BIGINT NOT NULL,
        currency VARCHAR(10) NOT NULL,
        kind VARCHAR(30) NOT NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_web_shop_transaction_created_at DEFAULT SYSUTCDATETIME()
    );
    CREATE INDEX IX_web_shop_transaction_buyer_created ON pangya.web_shop_transaction(buyer_uid, created_at DESC);
END;
GO

IF OBJECT_ID('pangya.web_donation', 'U') IS NULL
BEGIN
    CREATE TABLE pangya.web_donation (
        donation_id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        uid INT NOT NULL,
        provider VARCHAR(20) NOT NULL,      -- 'mercadopago' ou 'paypal'
        external_id NVARCHAR(64) NULL,      -- id do pagamento/ordem no gateway
        package_id VARCHAR(20) NOT NULL,
        currency VARCHAR(10) NOT NULL CHECK (currency IN ('Pang', 'Cookie')),
        amount BIGINT NOT NULL,
        price_brl DECIMAL(10,2) NOT NULL,
        status VARCHAR(20) NOT NULL CONSTRAINT DF_web_donation_status DEFAULT 'pending',
        ip_address NVARCHAR(45) NULL,
        raw_payload NVARCHAR(MAX) NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_web_donation_created_at DEFAULT SYSUTCDATETIME(),
        updated_at DATETIME2 NOT NULL CONSTRAINT DF_web_donation_updated_at DEFAULT SYSUTCDATETIME()
    );
    CREATE INDEX IX_web_donation_uid_created ON pangya.web_donation(uid, created_at DESC);
    CREATE INDEX IX_web_donation_provider_external ON pangya.web_donation(provider, external_id);
END;
GO

IF OBJECT_ID('pangya.web_news', 'U') IS NULL
BEGIN
    CREATE TABLE pangya.web_news (
        news_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        title NVARCHAR(160) NOT NULL,
        slug NVARCHAR(180) NOT NULL,
        summary NVARCHAR(400) NULL,
        content NVARCHAR(MAX) NOT NULL,
        cover_image NVARCHAR(255) NULL,
        author_uid INT NOT NULL,
        published INT NOT NULL CONSTRAINT DF_web_news_published DEFAULT 1,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_web_news_created_at DEFAULT SYSUTCDATETIME(),
        updated_at DATETIME2 NOT NULL CONSTRAINT DF_web_news_updated_at DEFAULT SYSUTCDATETIME()
    );
    CREATE UNIQUE INDEX UX_web_news_slug ON pangya.web_news(slug);
    CREATE INDEX IX_web_news_published_created ON pangya.web_news(published, created_at DESC);
END;
GO
