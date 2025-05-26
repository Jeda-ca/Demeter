-- Create the database if it does not exist
USE master;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DEMETER_DB')
BEGIN
    CREATE DATABASE DEMETER_DB;
END
ELSE
BEGIN
    PRINT 'Database DEMETER_DB already exists.';
END
GO

-- Use the DEMETER_DB database
USE DEMETER_DB;
GO

-- Drop tables in reverse order of creation due to foreign key constraints

IF OBJECT_ID('sale_details', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS sale_details;
END

IF OBJECT_ID('reports', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS reports;
END

IF OBJECT_ID('sales', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS sales;
END

IF OBJECT_ID('products', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS products;
END

IF OBJECT_ID('administrators', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS administrators;
END

IF OBJECT_ID('sellers', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS sellers;
END

IF OBJECT_ID('clients', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS clients;
END

IF OBJECT_ID('users', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS users;
END

IF OBJECT_ID('persons', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS persons;
END

-- tablas catalogo
IF OBJECT_ID('document_types', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS document_types;
END

IF OBJECT_ID('roles', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS roles;
END

IF OBJECT_ID('measurement_units', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS measurement_units;
END

IF OBJECT_ID('product_categories', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS product_categories;
END

IF OBJECT_ID('sale_statuses', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS sale_statuses;
END

IF OBJECT_ID('report_types', 'U') IS NOT NULL
BEGIN
    DROP TABLE IF EXISTS report_types;
END
GO

-- Bloque para crear las tablas
-- 1. Tablas catalogo
CREATE TABLE document_types (
    id_document_type INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE roles (
    id_role INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE -- E.g., ADMIN, SELLER
);

CREATE TABLE measurement_units (
    id_measurement_unit INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE -- E.g., KILOGRAM, UNIT, POUND
);

CREATE TABLE product_categories (
    id_category INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE -- E.g., FRUTAS, VERDURAS
);

CREATE TABLE sale_statuses (
    id_status INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50) NOT NULL UNIQUE -- E.g., PENDIENTE, COMPLETADA, CANCELADA
);

CREATE TABLE report_types (
    id_report_type INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE -- E.g., VENTAS GENERALES, VENTAS POR VENDEDOR
);

-- 2. Tablas de dominio
CREATE TABLE persons (
    id_person INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    document_type_id INT NOT NULL,
    document_number NVARCHAR(50) NOT NULL,
    registration_date DATETIME2 NOT NULL DEFAULT GETDATE(),
    phone_number NVARCHAR(20) NULL,
    CONSTRAINT fk_persons_document_type FOREIGN KEY (document_type_id) REFERENCES document_types(id_document_type),
    CONSTRAINT uq_persons_document UNIQUE (document_type_id, document_number)
);
CREATE INDEX ix_persons_document_number ON persons(document_number);
CREATE INDEX ix_persons_name ON persons(last_name, first_name);

CREATE TABLE users (
    id_user INT IDENTITY(1,1) PRIMARY KEY,
    person_id INT NOT NULL UNIQUE, 
    username NVARCHAR(100) NOT NULL UNIQUE,
    password_hash NVARCHAR(256) NOT NULL, 
    role_id INT NOT NULL,
    is_active BIT NOT NULL DEFAULT 1, 
    CONSTRAINT fk_users_person FOREIGN KEY (person_id) REFERENCES persons(id_person),
    CONSTRAINT fk_users_role FOREIGN KEY (role_id) REFERENCES roles(id_role)
);
CREATE INDEX ix_users_role_id ON users(role_id);
CREATE INDEX ix_users_is_active ON users(is_active);

CREATE TABLE administrators (
    id_administrator INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL UNIQUE, 
    CONSTRAINT fk_administrators_user FOREIGN KEY (user_id) REFERENCES users(id_user)
);

CREATE TABLE sellers (
    id_seller INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL UNIQUE, 
    seller_code NVARCHAR(20) NOT NULL UNIQUE,
    CONSTRAINT fk_sellers_user FOREIGN KEY (user_id) REFERENCES users(id_user)
);
CREATE INDEX ix_sellers_seller_code ON sellers(seller_code);

CREATE TABLE clients (
    id_client INT IDENTITY(1,1) PRIMARY KEY,
    person_id INT NOT NULL UNIQUE, 
    client_code NVARCHAR(20) NOT NULL UNIQUE,
    last_purchase_date DATETIME2 NULL,
    email NVARCHAR(255) NULL UNIQUE,
    is_active BIT NOT NULL DEFAULT 1, 
    CONSTRAINT fk_clients_person FOREIGN KEY (person_id) REFERENCES persons(id_person)
);
CREATE INDEX ix_clients_client_code ON clients(client_code);
CREATE INDEX ix_clients_email ON clients(email);

CREATE TABLE products (
    id_product INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    description NVARCHAR(500) NULL,
    price DECIMAL(18, 2) NOT NULL,
    measurement_unit_id INT NOT NULL,
    category_id INT NOT NULL,
    stock_quantity INT NOT NULL DEFAULT 0,
    creation_date DATETIME2 NOT NULL DEFAULT GETDATE(),
    last_stock_update_date DATETIME2 NOT NULL DEFAULT GETDATE(),
    seller_id INT NOT NULL, 
    is_active BIT NOT NULL DEFAULT 1, 
    CONSTRAINT fk_products_measurement_unit FOREIGN KEY (measurement_unit_id) REFERENCES measurement_units(id_measurement_unit),
    CONSTRAINT fk_products_category FOREIGN KEY (category_id) REFERENCES product_categories(id_category),
    CONSTRAINT fk_products_seller FOREIGN KEY (seller_id) REFERENCES sellers(id_seller),
    CONSTRAINT ck_products_price CHECK (price >= 0),
    CONSTRAINT ck_products_stock_quantity CHECK (stock_quantity >= 0)
);
CREATE INDEX ix_products_name ON products(name);
CREATE INDEX ix_products_measurement_unit_id ON products(measurement_unit_id);
CREATE INDEX ix_products_category_id ON products(category_id);
CREATE INDEX ix_products_seller_id ON products(seller_id);

CREATE TABLE sales (
    id_sale INT IDENTITY(1,1) PRIMARY KEY,
    occurrence_date DATETIME2 NOT NULL DEFAULT GETDATE(),
    subtotal DECIMAL(18, 2) NOT NULL,
    discount_amount DECIMAL(18, 2) NOT NULL DEFAULT 0,
    total_amount DECIMAL(18, 2) NOT NULL,
    status_id INT NOT NULL,
    observations NVARCHAR(1000) NULL,
    client_id INT NOT NULL,
    seller_id INT NOT NULL,
    CONSTRAINT fk_sales_status FOREIGN KEY (status_id) REFERENCES sale_statuses(id_status),
    CONSTRAINT fk_sales_client FOREIGN KEY (client_id) REFERENCES clients(id_client),
    CONSTRAINT fk_sales_seller FOREIGN KEY (seller_id) REFERENCES sellers(id_seller),
    CONSTRAINT ck_sales_subtotal CHECK (subtotal >= 0),
    CONSTRAINT ck_sales_discount_amount CHECK (discount_amount >= 0),
    CONSTRAINT ck_sales_total_amount CHECK (total_amount >= 0)
);
CREATE INDEX ix_sales_occurrence_date ON sales(occurrence_date);
CREATE INDEX ix_sales_status_id ON sales(status_id);
CREATE INDEX ix_sales_client_id ON sales(client_id);
CREATE INDEX ix_sales_seller_id ON sales(seller_id);

CREATE TABLE sale_details (
    id_sale_detail INT IDENTITY(1,1) PRIMARY KEY,
    sale_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(18, 2) NOT NULL, -- Price at the moment of sale
    line_total DECIMAL(18, 2) NOT NULL,
    CONSTRAINT fk_sale_details_sale FOREIGN KEY (sale_id) REFERENCES sales(id_sale) ON DELETE CASCADE, -- Consider ON DELETE CASCADE
    CONSTRAINT fk_sale_details_product FOREIGN KEY (product_id) REFERENCES products(id_product),
    CONSTRAINT ck_sale_details_quantity CHECK (quantity > 0),
    CONSTRAINT ck_sale_details_unit_price CHECK (unit_price >= 0),
    CONSTRAINT ck_sale_details_line_total CHECK (line_total >= 0)
);
CREATE INDEX ix_sale_details_sale_id ON sale_details(sale_id);
CREATE INDEX ix_sale_details_product_id ON sale_details(product_id);

CREATE TABLE reports (
    id_report INT IDENTITY(1,1) PRIMARY KEY,
    administrator_id INT NOT NULL,
    generation_date DATETIME2 NOT NULL DEFAULT GETDATE(),
    report_type_id INT NOT NULL,
    period_start_date DATE NULL,
    period_end_date DATE NULL,
    filter_seller_id INT NULL, 
    filter_client_id INT NULL,   
    CONSTRAINT fk_reports_administrator FOREIGN KEY (administrator_id) REFERENCES administrators(id_administrator),
    CONSTRAINT fk_reports_report_type FOREIGN KEY (report_type_id) REFERENCES report_types(id_report_type),
    CONSTRAINT fk_reports_filter_seller FOREIGN KEY (filter_seller_id) REFERENCES sellers(id_seller),
    CONSTRAINT fk_reports_filter_client FOREIGN KEY (filter_client_id) REFERENCES clients(id_client)
);
CREATE INDEX ix_reports_administrator_id ON reports(administrator_id);
CREATE INDEX ix_reports_report_type_id ON reports(report_type_id);
CREATE INDEX ix_reports_filter_seller_id ON reports(filter_seller_id);
CREATE INDEX ix_reports_filter_client_id ON reports(filter_client_id);
CREATE INDEX ix_reports_generation_date ON reports(generation_date);

USE DEMETER_DB;
GO
Select * from users;