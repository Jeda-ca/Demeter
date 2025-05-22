-- Script para crear y actualizar Vistas
-- Ejecutar en DEMETER_DB

USE DEMETER_DB;
GO

-- Vista para Detalles de Producto
IF OBJECT_ID('v_product_details', 'V') IS NOT NULL
    DROP VIEW v_product_details;
GO
CREATE VIEW v_product_details AS
SELECT 
    p.id_product, 
    p.name AS product_name_alias,
    p.description AS product_description_alias,
    p.price AS product_price_alias,
    p.measurement_unit_id, 
    p.category_id, 
    p.stock_quantity, 
    p.creation_date AS product_creation_date_alias, 
    p.last_stock_update_date AS product_last_stock_update_date_alias, 
    p.seller_id, 
    p.is_active AS product_is_active_alias, -- Estado del producto
    mu.name AS measurement_unit_name,
    pc.name AS category_name,
    s.seller_code,
    s.user_id AS seller_user_id,
    u.username AS seller_username,
    u.role_id AS seller_role_id,
    u.is_active AS seller_user_is_active, -- Estado del usuario vendedor
    u.person_id AS seller_person_id,
    pe.first_name AS seller_first_name,
    pe.last_name AS seller_last_name,
    pe.document_type_id AS seller_document_type_id,
    pe.document_number AS seller_document_number,
    pe.registration_date AS seller_person_registration_date,
    pe.phone_number AS seller_phone_number,
    dt_pe.name AS seller_document_type_name,
    r_u.name AS seller_role_name
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
PRINT 'View v_product_details created/updated.';

-- Vista para Detalles Completos de Cliente
IF OBJECT_ID('v_client_full_details', 'V') IS NOT NULL
    DROP VIEW v_client_full_details;
GO
CREATE VIEW v_client_full_details AS
SELECT 
    c.id_client, 
    c.client_code, 
    c.last_purchase_date, 
    c.email AS client_email,
    c.is_active AS client_is_active, -- Estado del cliente
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
PRINT 'View v_client_full_details created/updated.';

-- Vista para Resumen de Ventas
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
    cli.client_code, 
    cli.person_id AS client_person_id, 
    s.seller_id, 
    s_p.first_name AS seller_first_name, 
    s_p.last_name AS seller_last_name, 
    sel.seller_code,
    sel.user_id AS seller_user_id,   
    sel_u.person_id AS seller_person_id,
    sel_u.is_active AS seller_user_is_active 
FROM 
    sales s
INNER JOIN 
    sale_statuses ss ON s.status_id = ss.id_status
INNER JOIN 
    clients cli ON s.client_id = cli.id_client 
INNER JOIN 
    persons c_p ON cli.person_id = c_p.id_person
INNER JOIN 
    sellers sel ON s.seller_id = sel.id_seller
INNER JOIN 
    users sel_u ON sel.user_id = sel_u.id_user
INNER JOIN 
    persons s_p ON sel_u.person_id = s_p.id_person;
GO
PRINT 'View v_sales_summary created/updated.';

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
    u.is_active AS user_is_active, 
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
PRINT 'View v_administrator_details created/updated.';

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
    u.is_active AS user_is_active, 
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
PRINT 'View v_seller_details created/updated.';

-- Vista para Detalles de Venta Enriquecidos
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
    p.price AS product_current_price,
    p.is_active AS product_is_active, 
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
PRINT 'View v_sale_line_items_enriched created/updated.';

-- Vista para Metadata de Reportes Enriquecida
IF OBJECT_ID('v_report_metadata_details', 'V') IS NOT NULL
    DROP VIEW v_report_metadata_details;
GO
CREATE VIEW v_report_metadata_details AS
SELECT 
    r.id_report, 
    r.administrator_id, 
    adm_u.username AS admin_username, 
    adm_u.is_active AS admin_user_is_active, 
    r.generation_date, 
    r.report_type_id, 
    r.period_start_date, 
    r.period_end_date, 
    r.filter_seller_id, 
    r.filter_client_id,
    rt.name AS report_type_name,
    adm_p.first_name AS admin_first_name, 
    adm_p.last_name AS admin_last_name, 
    s.seller_code AS filter_seller_code,
    sell_p.first_name AS filter_seller_first_name, 
    sell_p.last_name AS filter_seller_last_name, 
    sell_u.is_active AS filter_seller_user_is_active, 
    c.client_code AS filter_client_code,
    cli_p.first_name AS filter_client_first_name, 
    cli_p.last_name AS filter_client_last_name,
    c.is_active AS filter_client_is_active -- CORREGIDO: de cli.is_active a c.is_active
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
    clients c ON r.filter_client_id = c.id_client -- Alias 'c' para clients
LEFT JOIN 
    persons cli_p ON c.person_id = cli_p.id_person; -- cli_p es para la persona del cliente
GO
PRINT 'View v_report_metadata_details created/updated.';

PRINT 'All views created/updated successfully.';
