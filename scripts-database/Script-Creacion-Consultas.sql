use InventoryDB;

-- Obtener la lista de precios de todos los productos
SELECT ProductId, Name, Description, Cost, Price, Stock
FROM Products;

/*
Obtener la lista de productos cuya existencia en el inventario haya llegado al mínimo
permitido (5 unidades) */DECLARE @STOCK_MIN INT = 5;SELECT ProductId, Name, Description, Cost, Price, Stock
FROM ProductsWHERE Stock = @STOCK_MIN;/*Obtener una lista de clientes no mayores de 35 años que hayan realizado compras entre el 
1 de febrero de 2000 y el 25 de mayo de 2000*/SELECT u.UserId, FullName, DocumentType, DocumentNumber, Age, i.InvoiceDateFROM Users [u]INNER JOIN Invoices [i]ON u.UserId = i.UserIdWHERE u.Age < 35AND (i.InvoiceDate BETWEEN '2000-02-01T00:00:00' AND '2000-05-25T00:00:00');-- Obtener el valor total vendido por cada producto en el año 2000SELECT p.Name, SUM(id.QuantitySold) AS 'Productos vendidos'FROM Products [p]INNER JOIN InvoicesDetails [id]ON p.ProductId = id.ProductIdINNER JOIN Invoices [i]ON i.InvoiceId = id.InvoiceIdWHERE YEAR(i.InvoiceDate) = 2000GROUP BY p.Name;/*Obtener la última fecha de compra de un cliente y según su frecuencia de compra estimar 
en qué fecha podría volver a comprar.*/SELECT u.FullName, u.DocumentNumber, MAX(i.InvoiceDate) AS 'última fecha de compra',DATEADD(DAY, (DATEDIFF(DAY, '1970-01-01', i.InvoiceDate) + DATEDIFF(DAY, '1970-01-01', i.InvoiceDate)) / 2, '1970-01-01') 'FechaPromedio'FROM Users [u]INNER JOIN Invoices [i]ON u.UserId = i.UserIdGROUP BY  u.FullName, u.DocumentNumber, i.InvoiceDate