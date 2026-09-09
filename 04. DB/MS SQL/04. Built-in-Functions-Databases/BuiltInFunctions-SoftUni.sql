-- PROBLEM 1

SELECT 
       FirstName,
       LastName
  FROM Employees
  WHERE FirstName LIKE 'Sa%';

GO

-- PROBLEM 2

SELECT
       FirstName,
       LastName
  FROM Employees
 WHERE LastName LIKE '%ei%';

 GO

 -- PROBLEM 3

 SELECT
        FirstName
   FROM Employees
  WHERE DepartmentID IN (3, 10)
    AND   HireDate >= '1995-01-01' AND HireDate <= '2005-12-31'
GO

-- PROBLEM 4

SELECT 
       FirstName,
       LastName
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%';

 GO

 -- PROBLEM 5

 SELECT 
        [Name]
   FROM Towns
  WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC;

GO

-- PROBLEM 6

  SELECT
         [TownID],
         [Name]
    FROM [Towns]
   WHERE [Name] LIKE 'M%'
      OR [Name] LIKE 'K%'
      OR [Name] LIKE 'B%'
      OR [Name] LIKE 'E%'
ORDER BY [Name] ASC;

GO

-- PROBLEM 7

  SELECT
         [TownID],
         [Name]
    FROM [Towns]
   WHERE [Name] NOT LIKE 'R%'
     AND [Name] NOT LIKE 'B%'
     AND [Name] NOT LIKE 'D%'
ORDER BY [Name] ASC;

GO

-- PROBLEM 8

CREATE VIEW V_EmployeesHiredAfter2000 AS
     SELECT 
            FirstName,
            LastName
       FROM Employees
      WHERE HireDate > '2000-12-31';

GO

-- PROBLEM 9

SELECT 
       FirstName,
       LastName
  FROM Employees
 WHERE LEN(LastName) IN (5);

GO

-- PROBLEM 10

SELECT 
       EmployeeID,
       FirstName,
       LastName,
       Salary,
  DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000
  ORDER BY Salary DESC;

GO

-- PROBLEM 11

SELECT EmployeeID, FirstName, LastName, Salary, [Rank]
FROM (
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        Salary,
        DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
) AS RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC;

GO