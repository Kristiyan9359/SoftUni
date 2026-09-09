-- PROBLEM 2

SELECT * FROM Departments

GO


-- PROBLEM 3

SELECT [Name]
FROM Departments

GO


-- PROBLEM 4

SELECT
FirstName,
LastName,
Salary
FROM Employees

GO


-- PROBLEM 5

SELECT
FirstName,
MiddleName,
LastName
FROM Employees

GO


-- PROBLEM 6

SELECT
CONCAT(FirstName, '.',  LastName,  '@softuni.bg') 
AS [Full Email Address]
FROM Employees

GO


-- PROBLEM 7

SELECT
DISTINCT Salary
FROM Employees

GO


-- PROBLEM 8

SELECT *
FROM Employees
WHERE [JobTitle] = 'Sales Representative'

GO


-- PROBLEM 9

SELECT
FirstName,
LastName,
JobTitle
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

GO


-- PROBLEM 10

SELECT 
    FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);


GO


-- PROBLEM 11

SELECT
FirstName,
LastName
FROM Employees
WHERE ManagerID IS NULL

GO


-- POBLEM 12

SELECT
FirstName,
LastName,
Salary
FROM Employees
WHERE Salary >= 50000
ORDER BY Salary DESC

GO


-- PROBLEM 13

SELECT TOP 5
FirstName,
LastName
FROM Employees
ORDER BY Salary DESC

GO


-- PROBLEM 14

SELECT
FirstName,
LastName
FROM Employees
WHERE DepartmentID != 4

GO


-- PROBLEM 15

SELECT *
FROM Employees
ORDER BY
Salary DESC,
FirstName ASC,
LastName DESC,
MiddleName ASC

GO


-- PROBLEM 16

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees

GO


-- PROBLEM 17

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
    FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name],
    JobTitle
FROM Employees;

GO


-- PROBLEM 18

SELECT DISTINCT JobTitle
FROM Employees

GO


-- PROBLEM 19

SELECT TOP 10 *
FROM Projects
ORDER BY StartDate ASC, Name ASC;

GO


-- PROBLEM 20

SELECT TOP 7 
FirstName,
LastName,
HireDate
FROM Employees
ORDER BY HireDate DESC

GO


-- PROBLEM 21

UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (
    SELECT DepartmentID
    FROM Departments
    WHERE Name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
);

SELECT Salary
FROM Employees;

GO