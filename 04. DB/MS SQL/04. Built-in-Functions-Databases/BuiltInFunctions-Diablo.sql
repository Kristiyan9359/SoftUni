-- PROBLEM 14

SELECT TOP 50
       [Name],
       FORMAT([Start], 'yyyy-MM-dd') AS [Start]
  FROM Games
 WHERE [Start] >= '2011-01-01' AND [Start] <= '2012-12-31'
 ORDER BY [Start] ASC, [Name];

 GO

 -- PROBLEM 15

  SELECT 
         Username,
         SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS EmailProvider
    FROM Users
ORDER BY EmailProvider, Username;

GO

-- PROBLEM 16

SELECT Username, IPAddress
FROM Users
WHERE IPAddress LIKE '[0-9][0-9][0-9].1[0-9]%.[0-9]%.[0-9][0-9][0-9]'
ORDER BY Username;

GO

-- PROBLEM 17

SELECT 
    [Name] AS Game,
    CASE 
        WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
        WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
    END AS [Part of the Day],
    CASE
        WHEN Duration <= 3 THEN 'Extra Short'
        WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
        WHEN Duration > 6 THEN 'Long'
        ELSE 'Extra Long'
    END AS Duration
FROM Games
ORDER BY [Name], Duration, [Part of the Day];


GO