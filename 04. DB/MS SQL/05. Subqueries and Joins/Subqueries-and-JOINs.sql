-- PROBLEM 1

SELECT TOP 5
           e.EmployeeID,
           e.JobTitle,
           e.AddressID,
           a.AddressText
      FROM Employees AS e
      JOIN Addresses AS a
        ON e.AddressID = a.AddressID
  ORDER BY e.AddressID ASC;


-- PROBLEM 2

SELECT TOP 50
           e.FirstName,
           e.LastName,
           t.[Name],
           a.AddressText
      FROM Employees AS e
      JOIN Addresses AS a
        ON e.AddressID = a.AddressID
      JOIN Towns AS t
        ON a.TownID = t.TownID
  ORDER BY e.FirstName ASC, e.LastName ASC;


-- PROBLEM 3

  SELECT 
         e.EmployeeID,
         e.FirstName,
         e.LastName,
         d.[Name]
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
   WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID ASC;


-- PROBLEM 4


SELECT TOP 5
           e.EmployeeID,
           e. FirstName,
           e.Salary,
           d.[Name]
      FROM Employees AS e
      JOIN Departments AS d
        ON e.DepartmentID = d.DepartmentID
     WHERE e.Salary > 15000
  ORDER BY e.DepartmentID ASC;


-- PROBLEM 5

SELECT TOP 3
           e.EmployeeID,
           e.FirstName
      FROM Employees AS e
 LEFT JOIN EmployeesProjects as ep
        ON e.EmployeeID = ep.EmployeeID
     WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID ASC;


-- PROBLEM 6

SELECT 
       e.FirstName,
       e.LastName,
       e.HireDate,
       d.[Name]
  FROM Employees AS e
  JOIN Departments AS d
    ON e.DepartmentID = d.DepartmentID
 WHERE e.HireDate > '1999-01-01' 
   AND d.[Name] = 'Sales' OR d.[Name] = 'Finance'
 ORDER BY e.HireDate ASC;



-- PROBLEM 7

SELECT TOP 5
       e.EmployeeID,
       e.FirstName,
       p.[Name]
  FROM Employees AS e
  JOIN EmployeesProjects AS ep
    ON e.EmployeeID = ep.EmployeeID
  JOIN Projects AS p
    ON ep.ProjectID = p.ProjectID
 WHERE p.StartDate > '2002-08-13'
   AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC;


-- PROBLEM 8


 SELECT 
        e.EmployeeID,
        e.FirstName,
   CASE 
        WHEN p.StartDate >= '2005-01-01' THEN NULL
        ELSE p.[Name]
    END AS ProjectName
   FROM Employees AS e
   JOIN EmployeesProjects AS ep
       ON e.EmployeeID = ep.EmployeeID
   JOIN Projects AS p
       ON ep.ProjectID = p.ProjectID
   WHERE e.EmployeeID = 24;


-- PROBLEM 9

   SELECT
          e.EmployeeID,
          e.FirstName,
          e.ManagerID,
          m.FirstName AS ManagerName
     FROM Employees AS e
     JOIN Employees AS m
       ON e.ManagerID = m.EmployeeID
    WHERE e.ManagerID IN (3, 7)
 ORDER BY e.EmployeeID ASC;



 -- PROBLEM 10


 SELECT TOP 50
            e.EmployeeID,
            CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName,
            CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName,
            d.[Name] AS DepartmentName
       FROM Employees AS e
       JOIN Employees AS m
         ON e.ManagerID = m.EmployeeID
       JOIN Departments AS d
         ON e.DepartmentID = d.DepartmentID
   ORDER BY e.EmployeeID ASC;



-- PROBLEM 11

SELECT MIN(AvgSalary) AS MinAverageSalary
FROM (
    SELECT AVG(Salary) AS AvgSalary
    FROM Employees
    GROUP BY DepartmentID
) AS DeptAvg;