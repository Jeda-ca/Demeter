-- Script para crear la Vista v_product_details
-- Ejecutar en DEMETER_DB

USE DEMETER_DB;
GO

IF OBJECT_ID('v_product_details', 'V') IS NOT NULL
    DROP VIEW v_product_details;
GO

CREATE VIEW v_product_details AS
SELECT 
    p.id_product, 
    p.name AS product_name_alias, -- Usar alias para las columnas de la tabla principal si es necesario
    p.description AS product_description_alias,
    p.price AS product_price_alias,
    p.measurement_unit_id, 
    p.category_id, 
    p.stock_quantity, 
    p.creation_date AS product_creation_date_alias, 
    p.last_stock_update_date AS product_last_stock_update_date_alias, 
    p.seller_id, 
    p.is_active AS product_is_active_alias,
    mu.name AS measurement_unit_name,       -- Columna de la tabla unida
    pc.name AS category_name,               -- Columna de la tabla unida
    s.seller_code,                          -- Columna de la tabla unida
    s.user_id AS seller_user_id,            -- Columna de la tabla unida
    u.username AS seller_username,          -- Columna de la tabla unida
    u.role_id AS seller_role_id,            -- Columna de la tabla unida
    u.person_id AS seller_person_id,        -- Columna de la tabla unida
    pe.first_name AS seller_first_name,     -- Columna de la tabla unida
    pe.last_name AS seller_last_name,       -- Columna de la tabla unida
    pe.document_type_id AS seller_document_type_id, -- Columna de la tabla unida
    pe.document_number AS seller_document_number,   -- Columna de la tabla unida
    pe.registration_date AS seller_person_registration_date, -- Columna de la tabla unida
    pe.phone_number AS seller_phone_number, -- Columna de la tabla unida
    dt_pe.name AS seller_document_type_name, -- Columna de la tabla unida
    r_u.name AS seller_role_name             -- Columna de la tabla unida
FROM 
    products p
INNER JOIN 
    measurement_units mu ON p.measurement_unit_id = mu.id_measurement_unit
INNER JOIN 
    product_categories pc ON p.category_id = pc.id_category
INNER JOIN 
    sellers s ON p.seller_id = s.id_seller
INNER JOIN 
    users u ON s.user_id = u.id_user
INNER JOIN 
    persons pe ON u.person_id = pe.id_person
INNER JOIN 
    document_types dt_pe ON pe.document_type_id = dt_pe.id_document_type
INNER JOIN 
    roles r_u ON u.role_id = r_u.id_role;
GO

-- --------------------------------------------------------------------------------
-- Script para crear la Vista v_client_full_details
-- Ejecutar en DEMETER_DB
-- --------------------------------------------------------------------------------

IF OBJECT_ID('v_client_full_details', 'V') IS NOT NULL
    DROP VIEW v_client_full_details;
GO

CREATE VIEW v_client_full_details AS
SELECT 
    c.id_client, 
    c.client_code, 
    c.last_purchase_date, 
    c.email AS client_email, -- Alias para evitar colisión si persona tuviera email
    c.is_active AS client_is_active,
    p.id_person, 
    p.first_name AS person_first_name, 
    p.last_name AS person_last_name, 
    p.document_type_id, 
    p.document_number, 
    p.registration_date AS person_registration_date, 
    p.phone_number AS person_phone_number,
    dt.name AS document_type_name
FROM 
    clients c
INNER JOIN 
    persons p ON c.person_id = p.id_person
INNER JOIN 
    document_types dt ON p.document_type_id = dt.id_document_type;
GO

-- Para probar la vista:
-- SELECT * FROM v_client_full_details WHERE id_client = 1;
-- SELECT * FROM v_client_full_details WHERE person_first_name LIKE N'Ana%';

-- --------------------------------------------------------------------------------
-- Script para crear la Vista v_sales_summary
-- Ejecutar en DEMETER_DB
-- --------------------------------------------------------------------------------

IF OBJECT_ID('v_sales_summary', 'V') IS NOT NULL
    DROP VIEW v_sales_summary;
GO

CREATE VIEW v_sales_summary AS
SELECT 
    s.id_sale, 
    s.occurrence_date, 
    s.subtotal, 
    s.discount_amount, 
    s.total_amount, 
    s.status_id, 
    ss.name AS sale_status_name,
    s.observations, 
    s.client_id, 
    c_p.first_name AS client_first_name, 
    c_p.last_name AS client_last_name, 
    c.client_code,
    c.person_id AS client_person_id, 
    s.seller_id, 
    s_p.first_name AS seller_first_name, 
    s_p.last_name AS seller_last_name, 
    sel.seller_code,
    sel.user_id AS seller_user_id,   
    sel_u.person_id AS seller_person_id 
FROM 
    sales s
INNER JOIN 
    sale_statuses ss ON s.status_id = ss.id_status
INNER JOIN 
    clients c ON s.client_id = c.id_client
INNER JOIN 
    persons c_p ON c.person_id = c_p.id_person
INNER JOIN 
    sellers sel ON s.seller_id = sel.id_seller
INNER JOIN 
    users sel_u ON sel.user_id = sel_u.id_user
INNER JOIN 
    persons s_p ON sel_u.person_id = s_p.id_person;
GO

-- Para probar la vista:
-- SELECT * FROM v_sales_summary WHERE id_sale = 1;
-- SELECT * FROM v_sales_summary WHERE client_first_name LIKE N'Ana%';

-- --------------------------------------------------------------------------------
-- Script para crear Vistas Adicionales en DEMETER_DB
-- Ejecutar en DEMETER_DB
-- --------------------------------------------------------------------------------

-- Vista para Administradores con detalles completos
IF OBJECT_ID('v_administrator_details', 'V') IS NOT NULL
    DROP VIEW v_administrator_details;
GO
CREATE VIEW v_administrator_details AS
SELECT 
    adm.id_administrator,
    u.id_user, 
    u.username, 
    u.password_hash, 
    u.role_id,
    p.id_person, 
    p.first_name AS person_first_name, 
    p.last_name AS person_last_name, 
    p.document_type_id, 
    p.document_number, 
    p.registration_date AS person_registration_date, 
    p.phone_number AS person_phone_number,
    r.name AS role_name,
    dt.name AS document_type_name
FROM 
    administrators adm
INNER JOIN 
    users u ON adm.user_id = u.id_user
INNER JOIN 
    persons p ON u.person_id = p.id_person
INNER JOIN 
    roles r ON u.role_id = r.id_role
INNER JOIN 
    document_types dt ON p.document_type_id = dt.id_document_type;
GO

-- Vista para Vendedores con detalles completos
IF OBJECT_ID('v_seller_details', 'V') IS NOT NULL
    DROP VIEW v_seller_details;
GO
CREATE VIEW v_seller_details AS
SELECT 
    s.id_seller, 
    s.seller_code,
    u.id_user, 
    u.username, 
    u.password_hash, 
    u.role_id,
    p.id_person, 
    p.first_name AS person_first_name, 
    p.last_name AS person_last_name, 
    p.document_type_id, 
    p.document_number, 
    p.registration_date AS person_registration_date, 
    p.phone_number AS person_phone_number,
    r.name AS role_name,
    dt.name AS document_type_name
FROM 
    sellers s
INNER JOIN 
    users u ON s.user_id = u.id_user
INNER JOIN 
    persons p ON u.person_id = p.id_person
INNER JOIN 
    roles r ON u.role_id = r.id_role
INNER JOIN 
    document_types dt ON p.document_type_id = dt.id_document_type;
GO

-- Vista para Detalles de Venta Enriquecidos con información del Producto
IF OBJECT_ID('v_sale_line_items_enriched', 'V') IS NOT NULL
    DROP VIEW v_sale_line_items_enriched;
GO
CREATE VIEW v_sale_line_items_enriched AS
SELECT 
    sd.id_sale_detail, 
    sd.sale_id, 
    sd.product_id, 
    sd.quantity, 
    sd.unit_price, 
    sd.line_total,
    p.name AS product_name, 
    p.description AS product_description,
    p.price AS product_current_price, -- Precio actual del producto en la tabla 'products'
    p.measurement_unit_id AS product_measurement_unit_id,
    mu.name AS product_measurement_unit_name,
    p.category_id AS product_category_id,
    pc.name AS product_category_name
FROM 
    sale_details sd
INNER JOIN 
    products p ON sd.product_id = p.id_product
INNER JOIN 
    measurement_units mu ON p.measurement_unit_id = mu.id_measurement_unit
INNER JOIN 
    product_categories pc ON p.category_id = pc.id_category;
GO

-- Vista para Metadata de Reportes Enriquecida
IF OBJECT_ID('v_report_metadata_details', 'V') IS NOT NULL
    DROP VIEW v_report_metadata_details;
GO
CREATE VIEW v_report_metadata_details AS
SELECT 
    r.id_report, 
    r.administrator_id, 
    r.generation_date, 
    r.report_type_id, 
    r.period_start_date, 
    r.period_end_date, 
    r.filter_seller_id, 
    r.filter_client_id,
    rt.name AS report_type_name,
    adm_p.first_name AS admin_first_name, 
    adm_p.last_name AS admin_last_name, 
    -- Información del vendedor filtrado (si aplica)
    s.seller_code AS filter_seller_code,
    sell_p.first_name AS filter_seller_first_name, 
    sell_p.last_name AS filter_seller_last_name, 
    -- Información del cliente filtrado (si aplica)
    c.client_code AS filter_client_code,
    cli_p.first_name AS filter_client_first_name, 
    cli_p.last_name AS filter_client_last_name 
FROM 
    reports r
INNER JOIN 
    report_types rt ON r.report_type_id = rt.id_report_type
INNER JOIN 
    administrators adm ON r.administrator_id = adm.id_administrator
INNER JOIN 
    users adm_u ON adm.user_id = adm_u.id_user
INNER JOIN 
    persons adm_p ON adm_u.person_id = adm_p.id_person
LEFT JOIN 
    sellers s ON r.filter_seller_id = s.id_seller
LEFT JOIN 
    users sell_u ON s.user_id = sell_u.id_user
LEFT JOIN 
    persons sell_p ON sell_u.person_id = sell_p.id_person
LEFT JOIN 
    clients c ON r.filter_client_id = c.id_client
LEFT JOIN 
    persons cli_p ON c.person_id = cli_p.id_person;
GO
