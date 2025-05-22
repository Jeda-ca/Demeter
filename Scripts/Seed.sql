USE DEMETER_DB;
GO

-- 1. Poblando Tablas de Catálogo
INSERT INTO document_types (name) VALUES
(N'Cédula de Ciudadanía'),       -- ID: 1
(N'NIT'),                        -- ID: 2
(N'Cédula de Extranjería'),      -- ID: 3
(N'Pasaporte'),                  -- ID: 4
(N'PEP');                        -- ID: 5
PRINT 'Table document_types populated.';

INSERT INTO roles (name) VALUES
(N'ADMIN'),                      -- ID: 1
(N'VENDEDOR');                   -- ID: 2
PRINT 'Table roles populated.';

INSERT INTO measurement_units (name) VALUES
(N'KILOGRAMO'),                  -- ID: 1
(N'UNIDAD'),                     -- ID: 2
(N'ATADO'),                      -- ID: 3
(N'LIBRA'),                      -- ID: 4
(N'BULTO'),                      -- ID: 5
(N'CANASTA'),                    -- ID: 6
(N'DOCENA');                     -- ID: 7
PRINT 'Table measurement_units populated.';

INSERT INTO product_categories (name) VALUES
(N'FRUTAS'),                               -- ID: 1
(N'VERDURAS Y HORTALIZAS'),                -- ID: 2
(N'TUBÉRCULOS Y RAÍCES'),                  -- ID: 3
(N'HIERBAS AROMÁTICAS Y CONDIMENTOS'),     -- ID: 4
(N'GRANOS Y LEGUMBRES'),                   -- ID: 5
(N'PROCESADOS ARTESANALES'),               -- ID: 6
(N'HUEVOS Y LÁCTEOS');                     -- ID: 7
PRINT 'Table product_categories populated.';

INSERT INTO sale_statuses (name) VALUES
(N'PENDIENTE'),                  -- ID: 1
(N'COMPLETADA'),                 -- ID: 2
(N'CANCELADA');                  -- ID: 3
PRINT 'Table sale_statuses populated.';

INSERT INTO report_types (name) VALUES
(N'VENTAS GENERALES'),           -- ID: 1
(N'VENTAS POR VENDEDOR'),        -- ID: 2
(N'INVENTARIO GENERAL'),         -- ID: 3
(N'INVENTARIO POR VENDEDOR'),    -- ID: 4
(N'LISTA DE CLIENTES');          -- ID: 5
PRINT 'Table report_types populated.';
GO

-- 2. Poblando Tablas Principales

-- Persona para Admin (ID Persona: 1)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Admin', N'Principal', 1, '1999999999', '3000000000', DATEADD(YEAR, -1, GETDATE()));

-- Personas para Vendedores (ID Persona: 2, 3, 4, 5)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Carlos', N'Vargas López', 1, '1001001001', '3101234501', DATEADD(MONTH, -6, GETDATE())),
(N'Lucía', N'Fernández Díaz', 1, '1001001002', '3202345602', DATEADD(MONTH, -5, GETDATE())),
(N'Miguel', N'Suárez Peña', 2, '900123456-1', '3113456703', DATEADD(MONTH, -4, GETDATE())),
(N'Isabela', N'Mendoza Castro', 1, '1001001003', '3214567804', DATEADD(MONTH, -3, GETDATE()));

-- Personas para Clientes (ID Persona: 6 a 15)
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
(N'Javier', N'Ríos Morales', 1, '2002002008', '3001010210', DATEADD(DAY, -15, GETDATE()));
PRINT 'Table persons populated.';

-- Usuario Admin (Usa persona_id 1, rol_id 1) -> ID Usuario: 1
INSERT INTO users (person_id, username, password_hash, role_id, is_active) VALUES
(1, 'admin_demeter', 'admin123_hashed', 1, 1); -- Contraseña placeholder

-- Usuarios Vendedores (Usan person_id 2,3,4,5. rol_id 2) -> ID Usuario: 2, 3, 4, 5
INSERT INTO users (person_id, username, password_hash, role_id, is_active) VALUES
(2, 'cvargas', 'vendedor123_hashed', 2, 1),
(3, 'lfernandez', 'vendedor123_hashed', 2, 1),
(4, 'msuarez', 'vendedor123_hashed', 2, 1),
(5, 'imendoza', 'vendedor123_hashed', 2, 0); -- Vendedor Inactivo
PRINT 'Table users populated.';

-- Administrador (Usa user_id 1) -> ID Administrador: 1
INSERT INTO administrators (user_id) VALUES (1);
PRINT 'Table administrators populated.';

-- Vendedores (Usan user_id 2,3,4,5) -> ID Vendedor: 1, 2, 3, 4
INSERT INTO sellers (user_id, seller_code) VALUES
(2, 'VEND-CV-001'),
(3, 'VEND-LF-002'),
(4, 'VEND-MS-003'),
(5, 'VEND-IM-004'); -- Vendedor Inactivo
PRINT 'Table sellers populated.';

-- Clientes (Usan person_id 6 a 15) -> ID Cliente: 1 a 10
INSERT INTO clients (person_id, client_code, email, is_active, last_purchase_date) VALUES
(6, 'CLI-AG-001', 'ana.gomez@example.com', 1, DATEADD(DAY, -10, GETDATE())),
(7, 'CLI-JM-002', 'jorge.martinez@example.com', 1, DATEADD(DAY, -5, GETDATE())),
(8, 'CLI-SR-003', 'sofia.rojas@example.com', 1, DATEADD(DAY, -30, GETDATE())),
(9, 'CLI-AP-004', 'andres.parra@example.com', 1, DATEADD(DAY, -2, GETDATE())),
(10, 'CLI-CT-005', 'camila.torres@example.com', 1, DATEADD(DAY, -12, GETDATE())),
(11, 'CLI-LH-006', 'luis.herrera@example.com', 1, DATEADD(DAY, -8, GETDATE())),
(12, 'CLI-VS-007', 'valentina.soto@example.com', 1, DATEADD(DAY, -22, GETDATE())),
(13, 'CLI-MC-008', 'mateo.chaparro@example.com', 1, DATEADD(DAY, -3, GETDATE())),
(14, 'CLI-DM-009', 'daniela.moreno@example.com', 0, DATEADD(DAY, -40, GETDATE())), -- Cliente Inactivo
(15, 'CLI-JR-010', 'javier.rios@example.com', 1, DATEADD(DAY, -1, GETDATE()));
PRINT 'Table clients populated.';

-- Productos Vendedor 1 (Carlos Vargas, ID Vendedor: 1) -> ID Producto: 1-5
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Tomate Chonto Maduro', N'Tomate rojo maduro de alta calidad, ideal para ensaladas y guisos.', 2800, 1, 2, 50, 1, 1), 
(N'Cilantro Fresco del Huerto', N'Atado grande de cilantro fresco, cultivado localmente.', 1800, 3, 4, 100, 1, 1), 
(N'Papa Pastusa Seleccionada', N'Papa pastusa lavada, tamaño mediano.', 2000, 1, 3, 80, 1, 1), 
(N'Aguacate Hass Cremoso', N'Aguacate Hass de la región, cremoso y listo para consumir.', 4500, 2, 1, 40, 1, 1), 
(N'Huevos Criollos AA (Docena)', N'Docena de huevos criollos frescos, doble A.', 9000, 7, 7, 30, 1, 0); -- Producto Inactivo

-- Productos Vendedor 2 (Lucía Fernández, ID Vendedor: 2) -> ID Producto: 6-10
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Mango Tommy Dulce', N'Mango Tommy grande, dulce y jugoso, calidad extra.', 3200, 2, 1, 60, 2, 1), 
(N'Frijol Cargamanto Rojo', N'Frijol cargamanto rojo seco, por libra.', 4800, 4, 5, 40, 2, 1), 
(N'Queso Costeño Artesanal', N'Queso fresco artesanal, bloque de 500g aprox.', 8500, 2, 7, 25, 2, 1), 
(N'Plátano Maduro Hartón', N'Plátano Hartón maduro, ideal para tajadas.', 1500, 2, 1, 70, 2, 1), 
(N'Panela Pulverizada Orgánica', N'Panela de caña orgánica, por libra.', 6000, 4, 6, 35, 2, 1); 

-- Productos Vendedor 3 (Miguel Suárez, ID Vendedor: 3) -> ID Producto: 11-15
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Yuca Amarilla Criolla', N'Yuca suave y sabrosa, por kilogramo.', 1200, 1, 3, 90, 3, 1), 
(N'Limón Mandarino Jugoso', N'Limón mandarino grande y con mucho jugo, por kilogramo.', 2500, 1, 1, 55, 3, 1), 
(N'Mazorca de Maíz Tierna', N'Mazorcas frescas y tiernas, por unidad.', 1000, 2, 2, 120, 3, 1), 
(N'Café Molido de la Sierra', N'Café de origen de la Sierra Nevada, tostión media, libra.', 15000, 4, 6, 20, 3, 1), 
(N'Ahuyama Mediana', N'Ahuyama o zapallo, ideal para cremas y sopas.', 3500, 2, 2, 30, 3, 1); 
PRINT 'Table products populated.';

-- Ventas (IDs: 1 a 5)
-- Venta 1 (Cliente 1, Vendedor 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-10 10:30:00'), 10100.00, 100.00, 10000.00, 2, N'Compra para el hogar, descuento aplicado.', 1, 1);
-- Venta 2 (Cliente 2, Vendedor 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-11 11:00:00'), 9500.00, 0.00, 9500.00, 2, NULL, 2, 2);
-- Venta 3 (Cliente 3, Vendedor 3)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-12 09:15:00'), 4700.00, 200.00, 4500.00, 1, N'Pendiente de pago en efectivo.', 3, 3); -- PENDIENTE
-- Venta 4 (Cliente 1, Vendedor 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-13 14:00:00'), 7800.00, 0.00, 7800.00, 2, N'Productos para la semana.', 1, 2);
-- Venta 5 (Cliente 4, Vendedor 1, Venta Cancelada)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-09 16:30:00'), 6500.00, 0.00, 6500.00, 3, N'Cliente canceló el pedido.', 4, 1); -- CANCELADA
PRINT 'Table sales populated.';

-- Detalles de Ventas
-- Detalles Venta 1 (ID Venta: 1) -> Productos: Tomate (ID 1), Papa (ID 3)
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(1, 1, 2, 2800, 5600.00), 
(1, 3, 1, 4500, 4500.00); 

-- Detalles Venta 2 (ID Venta: 2) -> Productos: Mango (ID 6), Queso (ID 8)
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(2, 6, 1, 3200, 3200.00), 
(2, 8, 1, 6300, 6300.00); 

-- Detalles Venta 3 (ID Venta: 3) -> Productos: Yuca (ID 11), Limón (ID 12)
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(3, 11, 2, 1200, 2400.00), 
(3, 12, 1, 2300, 2300.00);

-- Detalles Venta 4 (ID Venta: 4) -> Productos: Plátano (ID 9), Panela (ID 10)
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(4, 9, 2, 1500, 3000.00),
(4, 10, 1, 4800, 4800.00); 

-- Detalles Venta 5 (ID Venta: 5, Venta Cancelada) -> Productos: Aguacate (ID 4)
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(5, 4, 1, 6500, 6500.00); 
PRINT 'Table sale_details populated.';

-- Reportes (Metadata)
-- Reporte de Ventas Generales del mes anterior (Abril 2025), generado por Admin ID 1, Tipo Reporte ID 1
INSERT INTO reports (administrator_id, report_type_id, period_start_date, period_end_date, generation_date) VALUES
(1, 1, CONVERT(DATE, '2025-04-01'), CONVERT(DATE, '2025-04-30'), DATEADD(DAY, -15, GETDATE())); 

-- Reporte de Inventario General, generado por Admin ID 1, Tipo Reporte ID 3
INSERT INTO reports (administrator_id, report_type_id, generation_date) VALUES
(1, 3, DATEADD(DAY, -1, GETDATE())); 

-- Reporte de Ventas por Vendedor (Vendedor ID 1), generado por Admin ID 1, Tipo Reporte ID 2
INSERT INTO reports (administrator_id, report_type_id, filter_seller_id, generation_date) VALUES
(1, 2, 1, DATEADD(HOUR, -2, GETDATE())); 
PRINT 'Table reports populated.';
GO

PRINT 'DEMETER_DB seeded successfully with sample data (INSERTs only).';
GO

-- Consultas de verificación (opcional)
-- SELECT * FROM roles;
-- SELECT * FROM users;
-- SELECT * FROM v_seller_details;
-- SELECT * FROM v_product_details WHERE seller_user_is_active = 1 AND product_is_active_alias = 1;
-- SELECT * FROM v_sales_summary;
-- SELECT * FROM v_report_metadata_details;
-- GO