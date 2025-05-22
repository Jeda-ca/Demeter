
USE DEMETER_DB;
GO

-- 1. Populating Catalog Tables
INSERT INTO document_types (name) VALUES
('Cédula de Ciudadanía'),       -- Assumed ID: 1
('NIT'),                        -- Assumed ID: 2
('Cédula de Extranjería'),      -- Assumed ID: 3
('Pasaporte'),                  -- Assumed ID: 4
('PEP');                        -- Assumed ID: 5

INSERT INTO roles (name) VALUES
('ADMIN'),                      -- Assumed ID: 1
('SELLER');                     -- Assumed ID: 2

INSERT INTO measurement_units (name) VALUES
('KILOGRAMO'),                  -- Assumed ID: 1
('UNIDAD'),                     -- Assumed ID: 2
('ATADO'),                      -- Assumed ID: 3
('LIBRA'),                      -- Assumed ID: 4
('BULTO'),                      -- Assumed ID: 5
('CANASTA'),                    -- Assumed ID: 6
('DOCENA');                     -- Assumed ID: 7

INSERT INTO product_categories (name) VALUES
('FRUTAS'),                               -- Assumed ID: 1
('VERDURAS Y HORTALIZAS'),                -- Assumed ID: 2
('TUBÉRCULOS Y RAÍCES'),                  -- Assumed ID: 3
('HIERBAS AROMÁTICAS Y CONDIMENTOS'),     -- Assumed ID: 4
('GRANOS Y LEGUMBRES'),                   -- Assumed ID: 5
('PROCESADOS ARTESANALES'),               -- Assumed ID: 6
('HUEVOS Y LÁCTEOS');                     -- Assumed ID: 7

INSERT INTO sale_statuses (name) VALUES
('PENDIENTE'),                  -- Assumed ID: 1
('COMPLETADA'),                 -- Assumed ID: 2
('CANCELADA');                  -- Assumed ID: 3

INSERT INTO report_types (name) VALUES
('VENTAS GENERALES'),           -- Assumed ID: 1
('VENTAS POR VENDEDOR'),        -- Assumed ID: 2
('INVENTARIO GENERAL'),         -- Assumed ID: 3
('LISTA DE CLIENTES');          -- Assumed ID: 4

-- 2. Populating Main Tables

-- Person for Admin (Assumed person_id: 1)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Admin', N'Demeter', 1, '1999999999', '3000000000', DATEADD(YEAR, -1, GETDATE()));

-- Persons for Sellers (Assumed person_id: 2, 3, 4, 5)
INSERT INTO persons (first_name, last_name, document_type_id, document_number, phone_number, registration_date) VALUES
(N'Carlos', N'Vargas López', 1, '1001001001', '3101234501', DATEADD(MONTH, -6, GETDATE())),
(N'Lucía', N'Fernández Díaz', 1, '1001001002', '3202345602', DATEADD(MONTH, -5, GETDATE())),
(N'Miguel', N'Suárez Peña', 2, '900123456-1', '3113456703', DATEADD(MONTH, -4, GETDATE())), -- Seller with NIT
(N'Isabela', N'Mendoza Castro', 1, '1001001003', '3214567804', DATEADD(MONTH, -3, GETDATE()));

-- Persons for Clients (Assumed person_id: 6 to 15)
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

-- Admin User (Uses person_id 1, role_id 1) -> Assumed user_id: 1
INSERT INTO users (person_id, username, password_hash, role_id) VALUES
(1, 'admin_demeter', 'hashed_password_admin_strong', 1);

-- Seller Users (Use person_id 2,3,4,5. role_id 2) -> Assumed user_id: 2, 3, 4, 5
INSERT INTO users (person_id, username, password_hash, role_id) VALUES
(2, 'cvargas_vende', 'hashed_password_vendedor_cv', 2),
(3, 'lfernandez_vende', 'hashed_password_vendedor_lf', 2),
(4, 'msuarez_vende', 'hashed_password_vendedor_ms', 2),
(5, 'imendoza_vende', 'hashed_password_vendedor_im', 2);

-- Administrator (Uses user_id 1) -> Assumed administrator_id: 1
INSERT INTO administrators (user_id) VALUES (1);

-- Sellers (Use user_id 2,3,4,5) -> Assumed seller_id: 1, 2, 3, 4
INSERT INTO sellers (user_id, seller_code) VALUES
(2, 'VEND-CV-001'),
(3, 'VEND-LF-002'),
(4, 'VEND-MS-003'),
(5, 'VEND-IM-004');

-- Clients (Use person_id 6 to 15) -> Assumed client_id: 1 to 10
INSERT INTO clients (person_id, client_code, email, is_active, last_purchase_date) VALUES
(6, 'CLI-AG-001', 'ana.gomez@email.com', 1, DATEADD(DAY, -10, GETDATE())),
(7, 'CLI-JM-002', 'jorge.martinez@email.com', 1, DATEADD(DAY, -5, GETDATE())),
(8, 'CLI-SR-003', 'sofia.rojas@email.com', 0, DATEADD(DAY, -30, GETDATE())),
(9, 'CLI-AP-004', 'andres.parra@email.com', 1, DATEADD(DAY, -2, GETDATE())),
(10, 'CLI-CT-005', 'camila.torres@email.com', 1, DATEADD(DAY, -12, GETDATE())),
(11, 'CLI-LH-006', 'luis.herrera@email.com', 1, DATEADD(DAY, -8, GETDATE())),
(12, 'CLI-VS-007', 'valentina.soto@email.com', 1, DATEADD(DAY, -22, GETDATE())),
(13, 'CLI-MC-008', 'mateo.chaparro@email.com', 1, DATEADD(DAY, -3, GETDATE())),
(14, 'CLI-DM-009', 'daniela.moreno@email.com', 0, DATEADD(DAY, -40, GETDATE())),
(15, 'CLI-JR-010', 'javier.rios@email.com', 1, DATEADD(DAY, -1, GETDATE()));
PRINT 'Tabla clients poblada.'; -- Total 10 clients

-- Seller 1 (Assumed seller_id: 1) Products (Assumed product_id: 1-5)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Tomate Chonto Maduro', N'Tomate rojo maduro de alta calidad, ideal para ensaladas y guisos.', 2800, 1, 2, 50, 1, 1), 
(N'Cilantro Fresco del Huerto', N'Atado grande de cilantro fresco, cultivado localmente sin pesticidas.', 1800, 3, 4, 100, 1, 1), 
(N'Papa Pastusa Seleccionada', N'Papa pastusa lavada, tamaño mediano, perfecta para sopas y puré.', 2000, 1, 3, 80, 1, 1), 
(N'Aguacate Hass Cremoso', N'Aguacate Hass de la región, cremoso y listo para consumir.', 4500, 2, 1, 40, 1, 1), 
(N'Huevos Criollos AA (Docena)', N'Docena de huevos criollos frescos de gallina feliz, doble A.', 9000, 7, 7, 30, 1, 1); 

-- Seller 2 (Assumed seller_id: 2) Products (Assumed product_id: 6-10)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Mango Tommy Dulce (Unidad)', N'Mango Tommy grande, dulce y jugoso, calidad extra.', 3200, 2, 1, 60, 2, 1), 
(N'Frijol Cargamanto Rojo (Libra)', N'Frijol cargamanto rojo seco, de excelente calidad.', 4800, 4, 5, 40, 2, 1), 
(N'Queso Costeño Artesanal (Unidad)', N'Queso fresco artesanal, típico de la costa, bloque de 500g aprox.', 8500, 2, 7, 25, 2, 1), 
(N'Plátano Maduro Hartón (Unidad)', N'Plátano Hartón maduro, ideal para tajadas fritas o asadas.', 1500, 2, 1, 70, 2, 1), 
(N'Panela Pulverizada Orgánica (Libra)', N'Panela de caña orgánica, sin químicos, fácil de disolver.', 6000, 4, 6, 35, 2, 1); 

-- Seller 3 (Assumed seller_id: 3) Products (Assumed product_id: 11-15)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Yuca Amarilla Criolla (Kilogramo)', N'Yuca suave y sabrosa, cultivada en la región del Cesar.', 1200, 1, 3, 90, 3, 1), 
(N'Limón Mandarino Jugoso (Kilogramo)', N'Limón mandarino grande y con mucho jugo, ideal para limonadas.', 2500, 1, 1, 55, 3, 1), 
(N'Mazorca de Maíz Tierna (Unidad)', N'Mazorcas frescas y tiernas, perfectas para asar o sancocho.', 1000, 2, 2, 120, 3, 1), 
(N'Café Molido de la Sierra (Libra)', N'Café de origen de la Sierra Nevada, tostión media, molido.', 15000, 4, 6, 20, 3, 1), 
(N'Ahuyama Mediana (Unidad)', N'Ahuyama o zapallo, ideal para cremas, sopas y dulces.', 3500, 2, 2, 30, 3, 1); 

-- Seller 4 (Assumed seller_id: 4) Products (Assumed product_id: 16-20)
INSERT INTO products (name, description, price, measurement_unit_id, category_id, stock_quantity, seller_id, is_active) VALUES
(N'Cebolla Larga Fresca (Atado)', N'Atado de cebolla larga (junca), fresca y de buen tamaño.', 2200, 3, 2, 75, 4, 1), 
(N'Patilla Rayada Grande (Unidad)', N'Patilla o sandía grande y dulce, refrescante.', 12000, 2, 1, 15, 4, 1), 
(N'Bocadillo Veleño Genuino (Unidad)', N'Bocadillo de guayaba típico de Vélez, en hoja de bijao.', 2000, 2, 6, 50, 4, 1), 
(N'Lulo Castilla Ácido (Kilogramo)', N'Lulo para jugos, bien ácido y carnoso.', 3800, 1, 1, 40, 4, 1), 
(N'Arroz Blanco Común (Libra)', N'Arroz blanco de primera calidad, por libra.', 2200, 4, 5, 100, 4, 1); 

-- Assumed sale_id: 1 to 20. Dates are for May 2025.
-- Sale 1 (Client 1, Seller 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-04 10:30:00'), 15000.00, 0.00, 15000.00, 2, N'Compra para el hogar', 1, 1);
-- Sale 2 (Client 2, Seller 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-05 11:00:00'), 13200.00, 0.00, 13200.00, 2, NULL, 2, 2);
-- Sale 3 (Client 3, Seller 3)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-06 09:15:00'), 4700.00, 200.00, 4500.00, 2, N'Para el almuerzo del día', 3, 3);
-- Sale 4 (Client 4, Seller 4)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-07 14:00:00'), 18000.00, 1000.00, 17000.00, 2, N'Productos para la tienda de abarrotes', 4, 4);
-- Sale 5 (Client 5, Seller 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-08 16:30:00'), 11800.00, 0.00, 11800.00, 2, NULL, 5, 1);
-- Sale 6 (Client 6, Seller 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-09 08:00:00'), 9700.00, 0.00, 9700.00, 2, N'Para jugos naturales del negocio', 6, 2);
-- Sale 7 (Client 7, Seller 3)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-10 12:45:00'), 16000.00, 500.00, 15500.00, 2, N'Pedido especial para evento', 7, 3);
-- Sale 8 (Client 8, Seller 4)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-11 17:00:00'), 4200.00, 0.00, 4200.00, 1, N'Pendiente de pago en efectivo', 8, 4); -- PENDING
-- Sale 9 (Client 9, Seller 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-12 10:00:00'), 7300.00, 300.00, 7000.00, 2, NULL, 9, 1);
-- Sale 10 (Client 10, Seller 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-13 11:30:00'), 15000.00, 0.00, 15000.00, 2, N'Para evento familiar de fin de semana', 10, 2);
-- Sale 11 (Client 1, Seller 3)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-14 15:00:00'), 18700.00, 700.00, 18000.00, 2, NULL, 1, 3);
-- Sale 12 (Client 2, Seller 4)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-15 09:00:00'), 14200.00, 200.00, 14000.00, 2, N'Compra para el negocio de comidas', 2, 4);
-- Sale 13 (Client 3, Seller 1)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-16 13:20:00'), 6300.00, 0.00, 6300.00, 2, NULL, 3, 1);
-- Sale 14 (Client 4, Seller 2)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-17 10:45:00'), 11700.00, 0.00, 11700.00, 2, NULL, 4, 2);
-- Sale 15 (Client 5, Seller 3)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-18 16:00:00'), 17000.00, 1000.00, 16000.00, 1, N'Confirmar stock antes de completar el pago', 5, 3); -- PENDING
-- Sale 16 (Client 6, Seller 4, Today: May 21, 2025)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-21 08:30:00'), 4400.00, 0.00, 4400.00, 2, N'Entrega inmediata', 6, 4);
-- Sale 17 (Client 7, Seller 1, Today: May 21, 2025)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-21 09:50:00'), 9000.00, 0.00, 9000.00, 2, NULL, 7, 1);
-- Sale 18 (Client 8, Seller 2, Today: May 21, 2025)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-21 10:15:00'), 8500.00, 500.00, 8000.00, 2, N'Cliente frecuente, descuento aplicado', 8, 2);
-- Sale 19 (Client 9, Seller 3, Today: May 21, 2025)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-21 11:00:00'), 15000.00, 0.00, 15000.00, 1, N'Para recoger más tarde en el puesto', 9, 3); -- PENDING
-- Sale 20 (Client 10, Seller 4, Today: May 21, 2025)
INSERT INTO sales (occurrence_date, subtotal, discount_amount, total_amount, status_id, observations, client_id, seller_id) VALUES
(CONVERT(DATETIME2, '2025-05-21 12:00:00'), 2200.00, 0.00, 2200.00, 2, NULL, 10, 4);

-- Details for Sale 1 (Assumed sale_id: 1) - Products: Tomate (ID 1), Cilantro (ID 2), Papa (ID 3) -> Subtotal 15000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(1, 1, 2, 2800, 5600.00), (1, 2, 3, 1800, 5400.00), (1, 3, 2, 2000, 4000.00);
-- Details for Sale 2 (Assumed sale_id: 2) - Products: Mango (ID 6), Plátano (ID 9), Queso (ID 8) -> Subtotal 13200
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(2, 6, 3, 3200, 9600.00), (2, 9, 2, 1500, 3000.00), (2, 8, 1, 600, 600.00); -- Ajuste precio queso para cuadrar
-- Details for Sale 3 (Assumed sale_id: 3) - Products: Yuca (ID 11), Limón (ID 12) -> Subtotal 4700
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(3, 11, 2, 1200, 2400.00), (3, 12, 1, 2300, 2300.00); -- Ajuste precio limón para cuadrar
-- Details for Sale 4 (Assumed sale_id: 4) - Products: Cebolla (ID 16), Patilla (ID 17), Arroz (ID 20) -> Subtotal 18000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(4, 16, 2, 2200, 4400.00), (4, 17, 1, 12000, 12000.00), (4, 20, 1, 1600, 1600.00); -- Ajuste precio arroz para cuadrar
-- Details for Sale 5 (Assumed sale_id: 5) - Products: Aguacate (ID 4), Huevos (ID 5) -> Subtotal 11800
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(5, 4, 2, 4500, 9000.00), (5, 5, 1, 2800, 2800.00); -- Ajuste precio huevos para cuadrar
-- Details for Sale 6 (Assumed sale_id: 6) - Products: Frijol (ID 7), Panela (ID 10) -> Subtotal 9700
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(6, 7, 1, 4800, 4800.00), (6, 10, 1, 4900, 4900.00); -- Ajuste precio panela para cuadrar
-- Details for Sale 7 (Assumed sale_id: 7) - Products: Mazorca (ID 13), Café (ID 14), Ahuyama (ID 15) -> Subtotal 16000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(7, 13, 5, 1000, 5000.00), (7, 14, 1, 7500, 7500.00), (7, 15, 1, 3500, 3500.00); -- Ajuste precio café para cuadrar
-- Details for Sale 8 (Assumed sale_id: 8) - Products: Bocadillo (ID 18) -> Subtotal 4200
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(8, 18, 1, 4200, 4200.00);
-- Details for Sale 9 (Assumed sale_id: 9) - Products: Tomate (ID 1), Papa (ID 3), Cilantro (ID 2) -> Subtotal 7300
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(9, 1, 1, 2800, 2800.00), (9, 3, 2, 2000, 4000.00), (9, 2, 1, 500, 500.00); -- Ajuste precio cilantro para cuadrar
-- Details for Sale 10 (Assumed sale_id: 10) - Products: Mango (ID 6), Queso (ID 8) -> Subtotal 15000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(10, 6, 2, 3200, 6400.00), (10, 8, 1, 8600, 8600.00); -- Ajuste precio queso para cuadrar
-- Details for Sale 11 (Assumed sale_id: 11) - Products: Yuca (ID 11), Limón (ID 12), Café (ID 14) -> Subtotal 18700
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(11, 11, 3, 1200, 3600.00), (11, 12, 2, 2500, 5000.00), (11, 14, 1, 10100, 10100.00); -- Ajuste precio café para cuadrar
-- Details for Sale 12 (Assumed sale_id: 12) - Products: Cebolla (ID 16), Patilla (ID 17), Arroz (ID 20) -> Subtotal 14200
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(12, 16, 3, 2200, 6600.00), (12, 17, 1, 5400, 5400.00), (12, 20, 1, 2200, 2200.00); -- Ajuste precio patilla para cuadrar
-- Details for Sale 13 (Assumed sale_id: 13) - Products: Aguacate (ID 4), Huevos (ID 5) -> Subtotal 6300
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(13, 4, 1, 4500, 4500.00), (13, 5, 1, 1800, 1800.00); -- Ajuste precio huevos para cuadrar
-- Details for Sale 14 (Assumed sale_id: 14) - Products: Plátano (ID 9), Panela (ID 10) -> Subtotal 11700
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(14, 9, 5, 1500, 7500.00), (14, 10, 1, 4200, 4200.00); -- Ajuste precio panela para cuadrar
-- Details for Sale 15 (Assumed sale_id: 15) - Products: Mazorca (ID 13), Ahuyama (ID 15) -> Subtotal 17000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(15, 13, 10, 1000, 10000.00), (15, 15, 2, 3500, 7000.00);
-- Details for Sale 16 (Assumed sale_id: 16) - Products: Bocadillo (ID 18), Arroz (ID 20) -> Subtotal 4400
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(16, 18, 1, 2000, 2000.00), (16, 20, 1, 2400, 2400.00); -- Ajuste precio arroz para cuadrar
-- Details for Sale 17 (Assumed sale_id: 17) - Products: Huevos (ID 5) -> Subtotal 9000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(17, 5, 1, 9000, 9000.00);
-- Details for Sale 18 (Assumed sale_id: 18) - Products: Queso (ID 8) -> Subtotal 8500
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(18, 8, 1, 8500, 8500.00);
-- Details for Sale 19 (Assumed sale_id: 19) - Products: Café (ID 14) -> Subtotal 15000
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(19, 14, 1, 15000, 15000.00);
-- Details for Sale 20 (Assumed sale_id: 20) - Products: Arroz (ID 20) -> Subtotal 2200
INSERT INTO sale_details (sale_id, product_id, quantity, unit_price, line_total) VALUES 
(20, 20, 1, 2200, 2200.00);

-- Reporte de Ventas Generales del mes anterior (Abril 2025), generado por Admin ID 1, Tipo Reporte ID 1
INSERT INTO reports (administrator_id, report_type_id, period_start_date, period_end_date, generation_date) VALUES
(1, 1, CONVERT(DATE, '2025-04-01'), CONVERT(DATE, '2025-04-30'), DATEADD(DAY, -15, GETDATE())); -- Assumed report_id: 1

-- Reporte de Inventario General, generado por Admin ID 1, Tipo Reporte ID 3
INSERT INTO reports (administrator_id, report_type_id, generation_date) VALUES
(1, 3, DATEADD(DAY, -1, GETDATE())); -- Assumed report_id: 2

GO

SELECT * FROM roles;