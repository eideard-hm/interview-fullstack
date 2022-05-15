DROP DATABASE IF EXISTS InventoryDB;
CREATE DATABASE InventoryDB;
USE InventoryDB;

DROP TABLE IF EXISTS Users
CREATE TABLE Users
(
UserId INT IDENTITY(1,1),
FullName VARCHAR(200) NOT NULL,
DocumentType VARCHAR(3) NOT NULL,
DocumentNumber VARCHAR(11) NOT NULL,
Age TINYINT NOT NULL,
PRIMARY KEY(UserId)
);

DROP TABLE IF EXISTS Invoices
CREATE TABLE Invoices
(
InvoiceId INT IDENTITY(1,1),
InvoiceNumber INT NOT NULL,
InvoiceDate DATETIME NOT NULL DEFAULT(GETDATE()),
Concept VARCHAR(200) NOT NULL,
Subtotal DECIMAL (18, 2) NOT NULL,
Total DECIMAL(18, 2) NOT NULL,
Tax DECIMAL(18,2) NOT NULL,
Anulado BIT NOT NULL DEFAULT(0),
UserId INT NOT NULL,
PRIMARY KEY(InvoiceId)
);

DROP TABLE IF EXISTS Products
CREATE TABLE Products
(
ProductId INT IDENTITY(1,1),
Name VARCHAR(200) NOT NULL,
Description VARCHAR(2000) NOT NULL,
Cost DECIMAL(18,2) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
Stock INT NOT NULL,
PRIMARY KEY(ProductId)
);

DROP TABLE IF EXISTS InvoicesDetails
CREATE TABLE InvoicesDetails
(
ProductId INT NOT NULL,
InvoiceId INT NOT NULL,
UnitCost DECIMAL(18,2) NOT NULL,
UnitPrice DECIMAL(18,2) NOT NULL,
QuantitySold INT NOT NULL,
Subtotal DECIMAL(18, 2) NOT NULL,
Tax DECIMAL(18, 2) NOT NULL,
Total DECIMAL(18, 2) NOT NULL,
PRIMARY KEY(ProductId, InvoiceId)
);

-- relaciones
-- 1 Users ----------------- M Invoices
ALTER TABLE Invoices ADD CONSTRAINT FK_Invoices_Users_UserId 
FOREIGN KEY(UserId) REFERENCES Users(UserId);

-- 1 Invoices ----------------- M InvoicesDetails
ALTER TABLE InvoicesDetails ADD CONSTRAINT FK_InvoicesDetails_Invoices_InvoiceId
FOREIGN KEY(InvoiceId) REFERENCES Invoices(InvoiceId);

-- 1 Products ----------------- M InvoicesDetails
ALTER TABLE InvoicesDetails ADD CONSTRAINT FK_InvoicesDetails_Products_ProductId
FOREIGN KEY(ProductId) REFERENCES Products(ProductId);

-- Insert test data

-- Table Users
INSERT INTO Users(FullName, DocumentType, DocumentNumber, Age)
VALUES
('Edier Heraldo Hernández Molano', 'CC', '1055550018', 18),
('Judith Molano', 'CC', '1002464655', 34),
('Javier Hernández', 'CC', '4654555', 38),
('Marlon Javier Hernández', 'TI', '1055550017', 11),
('Vanessa Hernández Molano', 'TI', '1055550554', 8);

-- Table Invoices
INSERT INTO Invoices(InvoiceNumber, InvoiceDate, Concept, Subtotal, Tax, Total, UserId)
VALUES
(1,GETDATE(), 'Celulares vendidos',100000, 100000 * 0.19, 100000 + (100000 * 0.19), 1),
(2, N'2000-02-01T00:00:00', 'Computadores vendidos', 2000000, 2000000 * 0.19, 2000000 + (2000000 * 0.19),2),
(3,N'2000-03-15T00:00:00', 'Tablets vendidos', 654000, 654000 * 0.19, 654000 + (654000 * 0.19),3),
(4, N'2000-07-20T00:00:00', 'Laptos vendidos', 1200000, 1200000 * 0.19, 1200000 + (1200000 * 0.19),4),
(5, N'2000-05-25T00:00:00','Repuestos vendidos', 500000, 500000 * 0.19, 500000 + (500000 * 0.19),5);

-- Table Products
INSERT INTO Products(Name, Description, Cost, Price, Stock)
VALUES
('Smartphone Xiaomi Redmi Note 10', 'Buen teléfono de gama media', 5000, 9000, 20),
('Computadora de mesa, HP', 'Computadora de bajos recursos para tareas livianas', 1000000, 1250000, 45),
('Table marca Apple', 'Tablet gama alta', 2000000, 3000000, 5),
('Lapptop Lenovo con Windows 11', 'Computadora con OS Windows 11 para tareas pesadas', 2100000, 2500000, 100),
('Procesador Intel Core i9', 'Procesador para tareas pesadas', 1500000, 200000, 15);

-- Table InvoicesDetails
INSERT INTO InvoicesDetails(ProductId, InvoiceId, UnitCost, UnitPrice, QuantitySold, Subtotal, Tax, Total)
VALUES
(1,1, 5000, 9000, 10, 9000 * 10, 9000 * 10 * 0.19, 9000 * 10 + (9000 * 10 * 0.19)),
(2,2, 1000000, 1250000, 39, 1250000 * 10, 1250000 * 10 * 0.19, 1250000 * 10 + (1250000 * 10 * 0.19)),
(3,3, 2000000, 3000000, 1, 3000000 * 10, 3000000 * 10 * 0.19, 3000000 * 10 + (3000000 * 10 * 0.19)),
(4,4, 2100000, 2500000, 70, 2500000 * 10, 2500000 * 10 * 0.19, 2500000 * 10 + (2500000 * 10 * 0.19)),
(5,5, 1500000, 200000, 10, 200000 * 10, 200000 * 10 * 0.19, 200000 * 10 + (200000 * 10 * 0.19)),
(2,3, 1000000, 1250000, 1, 1250000 * 10, 1250000 * 10 * 0.19, 1250000 * 10 + (1250000 * 10 * 0.19));