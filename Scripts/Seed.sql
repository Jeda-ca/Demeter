-- Script para poblar la base de datos DEMETER_DB con datos de ejemplo

USE DEMETER_DB;
GO

-- 1. Poblando Tablas de Catálogo (Manteniendo las existentes)
PRINT 'Poblando tablas de catálogo...';
IF NOT EXISTS (SELECT 1 FROM document_types WHERE name = N'Cédula de Ciudadanía')
    INSERT INTO document_types (name) VALUES (N'Cédula de Ciudadanía');
IF NOT EXISTS (SELECT 1 FROM document_types WHERE name = N'NIT')
    INSERT INTO document_types (name) VALUES (N'NIT');
IF NOT EXISTS (SELECT 1 FROM document_types WHERE name = N'Cédula de Extranjería')
    INSERT INTO document_types (name) VALUES (N'Cédula de Extranjería');
IF NOT EXISTS (SELECT 1 FROM document_types WHERE name = N'Pasaporte')
    INSERT INTO document_types (name) VALUES (N'Pasaporte');
IF NOT EXISTS (SELECT 1 FROM document_types WHERE name = N'PEP')
    INSERT INTO document_types (name) VALUES (N'PEP'); -- Permiso Especial de Permanencia
PRINT 'Tabla document_types poblada.';

IF NOT EXISTS (SELECT 1 FROM roles WHERE name = N'ADMIN')
    INSERT INTO roles (name) VALUES (N'ADMIN');
IF NOT EXISTS (SELECT 1 FROM roles WHERE name = N'VENDEDOR')
    INSERT INTO roles (name) VALUES (N'VENDEDOR');
PRINT 'Tabla roles poblada.';

IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'KILOGRAMO')
    INSERT INTO measurement_units (name) VALUES (N'KILOGRAMO'); -- ID: 1
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'UNIDAD')
    INSERT INTO measurement_units (name) VALUES (N'UNIDAD');    -- ID: 2
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'ATADO')
    INSERT INTO measurement_units (name) VALUES (N'ATADO');     -- ID: 3
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'LIBRA')
    INSERT INTO measurement_units (name) VALUES (N'LIBRA');     -- ID: 4
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'BULTO')
    INSERT INTO measurement_units (name) VALUES (N'BULTO');     -- ID: 5
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'CANASTA')
    INSERT INTO measurement_units (name) VALUES (N'CANASTA');   -- ID: 6
IF NOT EXISTS (SELECT 1 FROM measurement_units WHERE name = N'DOCENA')
    INSERT INTO measurement_units (name) VALUES (N'DOCENA');    -- ID: 7
PRINT 'Tabla measurement_units poblada.';

IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'FRUTAS')
    INSERT INTO product_categories (name) VALUES (N'FRUTAS'); -- ID: 1
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'VERDURAS Y HORTALIZAS')
    INSERT INTO product_categories (name) VALUES (N'VERDURAS Y HORTALIZAS'); -- ID: 2
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'TUBÉRCULOS Y RAÍCES')
    INSERT INTO product_categories (name) VALUES (N'TUBÉRCULOS Y RAÍCES'); -- ID: 3
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'HIERBAS AROMÁTICAS Y CONDIMENTOS')
    INSERT INTO product_categories (name) VALUES (N'HIERBAS AROMÁTICAS Y CONDIMENTOS'); -- ID: 4
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'GRANOS Y LEGUMBRES')
    INSERT INTO product_categories (name) VALUES (N'GRANOS Y LEGUMBRES'); -- ID: 5
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'PROCESADOS ARTESANALES')
    INSERT INTO product_categories (name) VALUES (N'PROCESADOS ARTESANALES'); -- ID: 6
IF NOT EXISTS (SELECT 1 FROM product_categories WHERE name = N'HUEVOS Y LÁCTEOS')
    INSERT INTO product_categories (name) VALUES (N'HUEVOS Y LÁCTEOS'); -- ID: 7
PRINT 'Tabla product_categories poblada.';

IF NOT EXISTS (SELECT 1 FROM sale_statuses WHERE name = N'PENDIENTE')
    INSERT INTO sale_statuses (name) VALUES (N'PENDIENTE'); -- ID: 1
IF NOT EXISTS (SELECT 1 FROM sale_statuses WHERE name = N'COMPLETADA')
    INSERT INTO sale_statuses (name) VALUES (N'COMPLETADA'); -- ID: 2
IF NOT EXISTS (SELECT 1 FROM sale_statuses WHERE name = N'CANCELADA')
    INSERT INTO sale_statuses (name) VALUES (N'CANCELADA'); -- ID: 3
PRINT 'Tabla sale_statuses poblada.';

IF NOT EXISTS (SELECT 1 FROM report_types WHERE name = N'VENTAS GENERALES')
    INSERT INTO report_types (name) VALUES (N'VENTAS GENERALES'); -- ID: 1
IF NOT EXISTS (SELECT 1 FROM report_types WHERE name = N'VENTAS POR VENDEDOR')
    INSERT INTO report_types (name) VALUES (N'VENTAS POR VENDEDOR'); -- ID: 2
IF NOT EXISTS (SELECT 1 FROM report_types WHERE name = N'INVENTARIO GENERAL')
    INSERT INTO report_types (name) VALUES (N'INVENTARIO GENERAL'); -- ID: 3
IF NOT EXISTS (SELECT 1 FROM report_types WHERE name = N'INVENTARIO POR VENDEDOR')
    INSERT INTO report_types (name) VALUES (N'INVENTARIO POR VENDEDOR'); -- ID: 4
IF NOT EXISTS (SELECT 1 FROM report_types WHERE name = N'LISTA DE CLIENTES')
    INSERT INTO report_types (name) VALUES (N'LISTA DE CLIENTES'); -- ID: 5
PRINT 'Tabla report_types poblada.';
GO

-- 2. Poblando Tablas Principales
PRINT 'Poblando tablas principales...';

-- Persona para Admin (ID Persona: 1)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Admin', N'Principal', 1, '1999999999', '3000000000', DATEADD(YEAR, -2, GETDATE()));

-- Personas para Vendedores (12 personas)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Carlos', N'Vargas López', 1, '1001001001', '3101234501', DATEADD(MONTH, -12, GETDATE())),
(N'Lucía', N'Fernández Díaz', 1, '1001001002', '3202345602', DATEADD(MONTH, -11, GETDATE())),
(N'Miguel', N'Suárez Peña', 2, '900123456-1', '3113456703', DATEADD(MONTH, -10, GETDATE())),
(N'Isabela', N'Mendoza Castro', 1, '1001001003', '3214567804', DATEADD(MONTH, -9, GETDATE())),
(N'Andrés', N'Rojas Gómez', 1, '1001001004', '3125678905', DATEADD(MONTH, -8, GETDATE())),
(N'Valentina', N'Silva Torres', 1, '1001001005', '3226789016', DATEADD(MONTH, -7, GETDATE())),
(N'Javier', N'Pérez Luna', 2, '900234567-2', '3137890127', DATEADD(MONTH, -6, GETDATE())),
(N'Sofía', N'Martínez Ortiz', 1, '1001001006', '3238901238', DATEADD(MONTH, -5, GETDATE())),
(N'David', N'García Niño', 1, '1001001007', '3149012349', DATEADD(MONTH, -4, GETDATE())),
(N'Camila', N'Herrera Pinto', 1, '1001001008', '3240123450', DATEADD(MONTH, -3, GETDATE())),
(N'Juan', N'Soto Ramírez', 1, '1001001009', '3151234561', DATEADD(MONTH, -2, GETDATE())),
(N'Laura', N'Chaparro Vega', 1, '1001001010', '3252345672', DATEADD(MONTH, -1, GETDATE()));

-- Personas para Clientes (20 personas)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Ana', N'Gómez Pérez', 1, '2002002001', '3011122301', DATEADD(DAY, -60, GETDATE())),
(N'Jorge', N'Martínez Silva', 1, '2002002002', '3152233402', DATEADD(DAY, -55, GETDATE())),
(N'Sofía', N'Rojas Luna', 3, 'X000001Z', '3213344503', DATEADD(DAY, -50, GETDATE())),
(N'Andrés', N'Parra Ortiz', 1, '2002002003', '3004455604', DATEADD(DAY, -45, GETDATE())),
(N'Camila', N'Torres Niño', 1, '2002002004', '3105566705', DATEADD(DAY, -40, GETDATE())),
(N'Luis', N'Herrera Pinto', 1, '2002002005', '3206677806', DATEADD(DAY, -35, GETDATE())),
(N'Valentina', N'Soto Ramírez', 1, '2002002006', '3017788907', DATEADD(DAY, -30, GETDATE())),
(N'Mateo', N'Chaparro Vega', 1, '2002002007', '3158899008', DATEADD(DAY, -25, GETDATE())),
(N'Daniela', N'Moreno Ávila', 3, 'Y000002B', '3219900109', DATEADD(DAY, -20, GETDATE())),
(N'Javier', N'Ríos Morales', 1, '2002002008', '3001010210', DATEADD(DAY, -15, GETDATE())),
(N'Paula', N'Castro Jiménez', 1, '2002002009', '3162121311', DATEADD(DAY, -70, GETDATE())),
(N'Ricardo', N'López Méndez', 1, '2002002010', '3263232412', DATEADD(DAY, -65, GETDATE())),
(N'Carolina', N'Díaz Vargas', 4, 'PAS00123', '3024343513', DATEADD(DAY, -80, GETDATE())),
(N'Esteban', N'Peña Suárez', 1, '2002002011', '3175454614', DATEADD(DAY, -75, GETDATE())),
(N'Gabriela', N'Castro Mendoza', 1, '2002002012', '3276565715', DATEADD(DAY, -90, GETDATE())),
(N'Diego', N'Gómez Rojas', 1, '2002002013', '3037676816', DATEADD(DAY, -85, GETDATE())),
(N'Manuela', N'Silva Parra', 1, '2002002014', '3188787917', DATEADD(DAY, -100, GETDATE())),
(N'Felipe', N'Torres Herrera', 2, '800300400-5', '3289898018', DATEADD(DAY, -95, GETDATE())),
(N'Juliana', N'Pinto Soto', 1, '2002002015', '3040909119', DATEADD(DAY, -110, GETDATE())),
(N'Sebastián', N'Ramírez Chaparro', 1, '2002002016', '3191010220', DATEADD(DAY, -105, GETDATE()));
PRINT 'Tabla persons poblada.';

-- Usuario Admin (Usa persona_id 1, rol_id 1 ADMIN) -> ID Usuario: 1
INSERT INTO users (person_id, username, password_hash, role_id, is_active) VALUES
(1, 'admin_demeter', 'admin_password_hashed', 1, 1);

-- Usuarios Vendedores (Usan person_id 2 a 13, rol_id 2 VENDEDOR) -> ID Usuario: 2 a 13
INSERT INTO users (person_id, username, password_hash, role_id, is_active) VALUES
(2, 'cvargas', 'vendedor_password_hashed', 2, 1),
(3, 'lfernandez', 'vendedor_password_hashed', 2, 1),
(4, 'msuarez', 'vendedor_password_hashed', 2, 1),
(5, 'imendoza', 'vendedor_password_hashed', 2, 0), -- Vendedor Inactivo
(6, 'arojas', 'vendedor_password_hashed', 2, 1),
(7, 'vsilva', 'vendedor_password_hashed', 2, 1),
(8, 'jperez', 'vendedor_password_hashed', 2, 0), -- Vendedor Inactivo
(9, 'smartinez', 'vendedor_password_hashed', 2, 1),
(10, 'dgarcia', 'vendedor_password_hashed', 2, 1),
(11, 'cherrera', 'vendedor_password_hashed', 2, 1),
(12, 'jsoto', 'vendedor_password_hashed', 2, 0), -- Vendedor Inactivo
(13, 'lchaparro', 'vendedor_password_hashed', 2, 1);
PRINT 'Tabla users poblada.';

-- Administrador (Usa user_id 1) -> ID Administrador: 1
INSERT INTO administrators (user_id) VALUES (1);
PRINT 'Tabla administrators poblada.';

-- Vendedores (Usan user_id 2 a 13) -> ID Vendedor: 1 a 12
INSERT INTO sellers (user_id, seller_code) VALUES
(2, 'V-001'), (3, 'V-002'), (4, 'V-003'), (5, 'V-004'),
(6, 'V-005'), (7, 'V-006'), (8, 'V-007'), (9, 'V-008'),
(10, 'V-009'), (11, 'V-010'), (12, 'V-011'), (13, 'V-012');
PRINT 'Tabla sellers poblada.';

-- Clientes (Usan person_id 14 a 33) -> ID Cliente: 1 a 20
INSERT INTO clients (person_id, client_code, email, is_active, last_purchase_date) VALUES
(14, 'CLI-AG-001', 'ana.gomez@example.com', 1, DATEADD(DAY, -10, GETDATE())),
(15, 'CLI-JM-002', 'jorge.martinez@example.com', 1, DATEADD(DAY, -5, GETDATE())),
(16, 'CLI-SR-003', 'sofia.rojas@example.com', 1, DATEADD(DAY, -30, GETDATE())),
(17, 'CLI-AP-004', 'andres.parra@example.com', 0, DATEADD(DAY, -46, GETDATE())), -- Cliente Inactivo
(18, 'CLI-CT-005', 'camila.torres@example.com', 1, DATEADD(DAY, -12, GETDATE())),
(19, 'CLI-LH-006', 'luis.herrera@example.com', 1, DATEADD(DAY, -8, GETDATE())),
(20, 'CLI-VS-007', 'valentina.soto@example.com', 1, DATEADD(DAY, -22, GETDATE())),
(21, 'CLI-MC-008', 'mateo.chaparro@example.com', 0, DATEADD(DAY, -50, GETDATE())), -- Cliente Inactivo
(22, 'CLI-DM-009', 'daniela.moreno@example.com', 1, DATEADD(DAY, -3, GETDATE())),
(23, 'CLI-JR-010', 'javier.rios@example.com', 1, DATEADD(DAY, -1, GETDATE())),
(24, 'CLI-PC-011', 'paula.castro@example.com', 1, DATEADD(DAY, -18, GETDATE())),
(25, 'CLI-RL-012', 'ricardo.lopez@example.com', 1, DATEADD(DAY, -28, GETDATE())),
(26, 'CLI-CD-013', 'carolina.diaz@example.com', 0, DATEADD(DAY, -60, GETDATE())), -- Cliente Inactivo
(27, 'CLI-EP-014', 'esteban.pena@example.com', 1, DATEADD(DAY, -7, GETDATE())),
(28, 'CLI-GC-015', 'gabriela.castro@example.com', 1, DATEADD(DAY, -14, GETDATE())),
(29, 'CLI-DG-016', 'diego.gomez@example.com', 1, DATEADD(DAY, -21, GETDATE())),
(30, 'CLI-MS-017', 'manuela.silva@example.com', 1, DATEADD(DAY, -9, GETDATE())),
(31, 'CLI-FT-018', 'felipe.torres@example.com', 0, DATEADD(DAY, -40, GETDATE())), -- Cliente Inactivo
(32, 'CLI-JP-019', 'juliana.pinto@example.com', 1, DATEADD(DAY, -16, GETDATE())),
(33, 'CLI-SR-020', 'sebastian.ramirez@example.com', 1, DATEADD(DAY, -2, GETDATE()));
PRINT 'Tabla clients poblada.';

-- Productos (Distribuidos entre vendedores activos)
-- Vendedor 1 (Carlos Vargas, ID Vendedor: 1, UserID: 2)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Tomate Chonto Maduro', N'Tomate rojo maduro de alta calidad, ideal para ensaladas y guisos.', 2800, 1, 2, 150, 1, 1),
(N'Cilantro Fresco del Huerto', N'Atado grande de cilantro fresco, cultivado localmente.', 1800, 3, 4, 100, 1, 1),
(N'Papa Pastusa Seleccionada', N'Papa pastusa lavada, tamaño mediano.', 2000, 1, 3, 80, 1, 1),
(N'Aguacate Hass Cremoso', N'Aguacate Hass de la región, cremoso y listo para consumir.', 4500, 2, 1, 40, 1, 0); -- Producto Inactivo

-- Vendedor 2 (Lucía Fernández, ID Vendedor: 2, UserID: 3)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Mango Tommy Dulce', N'Mango Tommy grande, dulce y jugoso, calidad extra.', 3200, 2, 1, 60, 2, 1),
(N'Frijol Cargamanto Rojo', N'Frijol cargamanto rojo seco, por libra.', 4800, 4, 5, 40, 2, 1),
(N'Queso Costeño Artesanal', N'Queso fresco artesanal, bloque de 500g aprox.', 8500, 2, 7, 25, 2, 1);

-- Vendedor 3 (Miguel Suárez, ID Vendedor: 3, UserID: 4)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Yuca Amarilla Criolla', N'Yuca suave y sabrosa, por kilogramo.', 1200, 1, 3, 90, 3, 1),
(N'Limón Mandarino Jugoso', N'Limón mandarino grande y con mucho jugo, por kilogramo.', 2500, 1, 1, 55, 3, 1),
(N'Mazorca de Maíz Tierna', N'Mazorcas frescas y tiernas, por unidad.', 1000, 2, 2, 120, 3, 1);

-- Vendedor 5 (Andrés Rojas, ID Vendedor: 5, UserID: 6)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Banano Criollo (Racimo)', N'Racimo de banano criollo, dulce y energético.', 3500, 2, 1, 70, 5, 1),
(N'Cebolla Cabezona Roja', N'Cebolla roja grande, ideal para ensaladas.', 2200, 1, 2, 60, 5, 1),
(N'Mora de Castilla Fresca', N'Libra de mora fresca, perfecta para jugos y postres.', 4000, 4, 1, 30, 5, 1);

-- Vendedor 6 (Valentina Silva, ID Vendedor: 6, UserID: 7)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Panela Cuadrada (Bloque)', N'Bloque de panela tradicional, endulzante natural.', 5000, 2, 6, 50, 6, 1),
(N'Ajo Fresco (Cabeza)', N'Cabeza de ajo fresco, indispensable en la cocina.', 800, 2, 4, 80, 6, 1),
(N'Lulo Grande y Jugoso', N'Lulo para jugo, ácido y refrescante.', 3000, 1, 1, 45, 6, 1);

-- Vendedor 8 (Sofía Martínez, ID Vendedor: 8, UserID: 9)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Pimentón Rojo Grande', N'Pimentón rojo carnoso, para guisos y ensaladas.', 1500, 2, 2, 70, 8, 1),
(N'Lechuga Batavia Crespa', N'Lechuga fresca y crujiente, por unidad.', 1800, 2, 2, 50, 8, 1),
(N'Café Orgánico Molido (250g)', N'Café de la región, tostado y molido.', 12000, 2, 6, 20, 8, 1);

-- Vendedor 9 (David García, ID Vendedor: 9, UserID: 10)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Plátano Hartón Verde', N'Plátano verde para patacones o sopas.', 1300, 2, 1, 100, 9, 1),
(N'Zanahoria Grande', N'Zanahoria fresca y dulce, por libra.', 1500, 4, 2, 90, 9, 1),
(N'Huevos AA (Docena)', N'Docena de huevos frescos calidad AA.', 8500, 7, 7, 60, 9, 1);

-- Vendedor 10 (Camila Herrera, ID Vendedor: 10, UserID: 11)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Fresas Grandes (Libra)', N'Fresas frescas y jugosas.', 7000, 4, 1, 25, 10, 1),
(N'Arracacha Amarilla', N'Arracacha para sopas y purés.', 2500, 1, 3, 40, 10, 1),
(N'Hierbabuena Fresca (Atado)', N'Atado de hierbabuena para infusiones y cocina.', 1500, 3, 4, 50, 10, 0); -- Producto Inactivo

-- Vendedor 12 (Laura Chaparro, ID Vendedor: 12, UserID: 13)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Maracuyá Grande (Unidad)', N'Maracuyá para jugos, ácido y delicioso.', 1200, 2, 1, 60, 12, 1),
(N'Ahuyama Mediana', N'Ahuyama o zapallo, ideal para cremas y sopas.', 3500, 2, 2, 30, 12, 1),
(N'Queso Campesino Fresco (Libra)', N'Queso fresco de finca, por libra.', 9000, 4, 7, 15, 12, 1);
PRINT 'Tabla products poblada.';

-- Ventas (Asegurar que los productos y vendedores existan y estén activos, y que el cliente exista)
-- Venta 1 (Cliente 1, Vendedor 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -9, GETDATE()), 8100.00, 100.00, 8000.00, 2, N'Compra para el hogar.', 1, 1);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 1, 2, 2800, 5600.00), (@@IDENTITY, 2, 1, 2500, 2500.00);

-- Venta 2 (Cliente 2, Vendedor 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -8, GETDATE()), 13300.00, 0.00, 13300.00, 2, NULL, 2, 2);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 5, 1, 3200, 3200.00), (@@IDENTITY, 6, 1, 4800, 4800.00),(@@IDENTITY, 7, 1, 5300, 5300.00);

-- Venta 3 (Cliente 3, Vendedor 3) - PENDIENTE
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -7, GETDATE()), 4700.00, 200.00, 4500.00, 1, N'Pendiente de pago en efectivo.', 3, 3);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 8, 2, 1200, 2400.00), (@@IDENTITY, 9, 1, 2300, 2300.00);

-- Venta 4 (Cliente 5, Vendedor 5)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -6, GETDATE()), 9700.00, 0.00, 9700.00, 2, N'Productos para la semana.', 5, 5);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 11, 2, 3500, 7000.00), (@@IDENTITY, 12, 1, 2700, 2700.00);

-- Venta 5 (Cliente 6, Vendedor 6) - CANCELADA
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -5, GETDATE()), 5800.00, 0.00, 5800.00, 3, N'Cliente canceló el pedido por demora.', 6, 6);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 14, 1, 5000, 5000.00), (@@IDENTITY, 15, 1, 800, 800.00);

-- Venta 6 (Cliente 9, Vendedor 8)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -4, GETDATE()), 15300.00, 300.00, 15000.00, 2, N'Descuento por cliente frecuente.', 9, 8);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 17, 3, 1500, 4500.00), (@@IDENTITY, 18, 2, 1800, 3600.00), (@@IDENTITY, 19, 1, 7200, 7200.00);

-- Venta 7 (Cliente 10, Vendedor 9)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -3, GETDATE()), 11300.00, 0.00, 11300.00, 2, NULL, 10, 9);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 20, 5, 1300, 6500.00), (@@IDENTITY, 21, 2, 1500, 3000.00), (@@IDENTITY, 22, 1, 1800, 1800.00);

-- Venta 8 (Cliente 11, Vendedor 10) - PENDIENTE
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -2, GETDATE()), 7000.00, 0.00, 7000.00, 1, N'Cliente pagará al recoger.', 11, 10);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 23, 1, 7000, 7000.00);

-- Venta 9 (Cliente 12, Vendedor 12)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(DATEADD(DAY, -1, GETDATE()), 13700.00, 500.00, 13200.00, 2, N'Promoción fin de semana.', 12, 12);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 26, 2, 1200, 2400.00), (@@IDENTITY, 27, 1, 3500, 3500.00), (@@IDENTITY, 28, 1, 7800, 7800.00);

-- Venta 10 (Cliente 1, Vendedor 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(GETDATE(), 8000.00, 0.00, 8000.00, 2, N'Compra rápida.', 1, 2);
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES (@@IDENTITY, 5, 1, 3200, 3200.00), (@@IDENTITY, 6, 1, 4800, 4800.00);
PRINT 'Tabla sales y sale_details pobladas.';


-- (Opcional) Reportes (Metadata)
INSERT INTO reports (administrator_id, report_type_id, period_start_date, period_end_date, generation_date) VALUES
(1, 1, DATEADD(MONTH, -1, GETDATE()), GETDATE(), DATEADD(DAY, -1, GETDATE()));
INSERT INTO reports (administrator_id, report_type_id, filter_seller_id, generation_date) VALUES
(1, 2, 1, DATEADD(HOUR, -2, GETDATE()));
PRINT 'Tabla reports poblada (opcional).';
GO

PRINT 'DEMETER_DB seeded successfully with sample data.';
GO

-- Reactivar constraints si fueron deshabilitados
-- EXEC sp_MSforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL"
-- GO