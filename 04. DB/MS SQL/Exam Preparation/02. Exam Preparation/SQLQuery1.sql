-- PROBLEM 1 -- DDL

CREATE TABLE Countries
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
);


CREATE TABLE Addresses
(
Id INT PRIMARY KEY IDENTITY,
StreetName NVARCHAR(20) NOT NULL,
StreetNumber INT,
PostCode INT NOT NULL,
City VARCHAR(25) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries([Id]) NOT NULL
);


CREATE TABLE Vendors
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL
);


CREATE TABLE Clients
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses([Id]) NOT NULL
);


CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
);


CREATE TABLE Products
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(35) NOT NULL,
Price DECIMAL(18, 2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
VendorId INT FOREIGN KEY REFERENCES Vendors([Id]) NOT NULL
);


CREATE TABLE Invoices
(
Id INT PRIMARY KEY IDENTITY,
Number INT UNIQUE NOT NULL,
IssueDate DATETIME2 NOT NULL,
DueDate DATETIME2 NOT NULL,
Amount DECIMAL(18, 2) NOT NULL,
Currency VARCHAR(5) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients([Id]) NOT NULL
);


CREATE TABLE ProductsClients
(
ProductId INT FOREIGN KEY REFERENCES Products([Id]) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients([Id]) NOT NULL,
PRIMARY KEY (ProductId, ClientId)
);


-- PROBLEM 2 --	Insert

INSERT INTO Products ([Name], Price, CategoryId, VendorId)
     VALUES ('SCANIA Oil Filter XD01', 78.69, 1, 1),
            ('MAN Air Filter XD01', 97.38, 1, 5),
            ('DAF Light Bulb 05FG87', 55.00, 2, 13),
            ('ADR Shoes 47-47.5', 49.85, 3, 5),
            ('Anti-slip pads S', 5.87, 5, 7);

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
     VALUES (1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
            (1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
            (1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19);



-- PROBLEM 3 --	Update

UPDATE Invoices
   SET DueDate = '2023-04-01'
 WHERE YEAR(IssueDate) = 2022 AND MONTH(IssueDate) = 11;


UPDATE Clients
   SET AddressId = 3
 WHERE Clients.[Name] LIKE '%CO%';



 -- PROBLEM 4 -- Delete

 DELETE FROM ProductsClients WHERE ClientId = 11
 DELETE FROM Invoices WHERE ClientId = 11
 DELETE FROM Clients WHERE SUBSTRING(NumberVAT, 1, 2) = 'IT'
 ;


 -- PROBLEM 5 -- Invoices by Amount and Date
 
 SELECT 
         Number,
         Currency
    FROM Invoices
ORDER BY Amount DESC
;


-- PROBLEM 6 -- Products by Category

SELECT 
       p.Id,
       p.[Name],
       p.Price,
       c.[Name] AS CategoryName
  FROM Products AS p
  JOIN Categories AS c
    ON p.CategoryId = c.Id
 WHERE c.[Name] LIKE 'ADR'
    OR c.[Name] LIKE 'Others'
ORDER BY p.Price DESC
;

-- PROBLEM 7 -- Clients without Products

    SELECT 
           c.Id,
           c.[Name] AS Client,
           CONCAT(a.StreetName,' ' , a.StreetNumber,', ', a.City,', ', a.PostCode,', ', co.[Name]) AS [Address]
      FROM Clients AS c
 LEFT JOIN ProductsClients AS pc
        ON c.Id = pc.ClientId
 LEFT JOIN Products AS p
        ON p.Id = pc.ProductId
 LEFT JOIN Addresses AS a
        ON c.AddressId = a.Id
 LEFT JOIN Countries AS co
        ON co.Id = a.CountryId
     WHERE pc.ProductId IS NULL
;


-- PROBLEM 8 --	First 7 Invoices
  
  SELECT TOP 7
         i.Number,
         i.Amount,
         c.[Name]
    FROM Invoices AS i
    JOIN Clients AS c
      ON c.Id = i.ClientId
   WHERE i.IssueDate < '2023-01-01'
     AND i.Currency LIKE 'EUR'
      OR i.Amount > 500.00
     AND c.NumberVAT LIKE 'DE%'
ORDER BY i.Number,
         i.Amount DESC
;



-- PROBLEM 9 --	Clients with VAT

SELECT 
       c.[Name] AS Client,
       MAX(p.Price) AS Price,
       c.NumberVAT AS [VAT Number]
  FROM Clients AS c
  JOIN ProductsClients AS pc
    ON c.Id = pc.ClientId
  JOIN Products AS p
    ON pc.ProductId = p.Id
 WHERE c.[Name] NOT LIKE '%KG'
 GROUP BY c.[Name], c.NumberVAT
 ORDER BY Price DESC
 ;


-- PROBLEM 10 -- Clients by Price

SELECT 
       c.[Name] AS Client,
       FLOOR(AVG(p.Price)) AS [Average Price]
  FROM Clients AS c
  JOIN ProductsClients AS pc ON c.Id = pc.ClientId
  JOIN Products AS p ON p.Id = pc.ProductId
  JOIN Vendors AS v ON p.VendorId = v.Id
WHERE pc.ClientId IS NOT NULL
  AND v.NumberVAT LIKE '%FR%'
GROUP BY c.[Name]
ORDER BY AVG(p.Price), c.[Name] DESC
;


-- PROBLEM 11 -- Product with Clients

CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalProductClient INT = 
	(
		SELECT
			COUNT(pc.ClientId)
		FROM Products AS p
		INNER JOIN ProductsClients AS pc ON p.Id = pc.ProductId
		WHERE p.[Name] = @name
	)
	RETURN @totalProductClient
END
;


SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')               


-- PROBLEM 12 -- Search for Vendors from a Specific Country

CREATE OR ALTER PROC usp_SearchByCountry(@country VARCHAR(10))
AS
	SELECT 
	    v.[Name] AS Vendor
		,v.NumberVAT AS VAT
		, CONCAT(a.StreetName, ' ', a.StreetNumber) AS [Street Info]
		, CONCAT(a.City, ' ', a.PostCode) AS [City Info]
	FROM Vendors AS v
	JOIN Addresses AS a ON v.AddressId = a.Id
	JOIN Countries AS c ON c.Id = a.CountryId
	WHERE c.[Name] = @country
	ORDER BY v.[Name], a.City
;

EXEC usp_SearchByCountry 'France'