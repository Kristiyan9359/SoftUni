-- PROBLEM 12

SELECT CountryName, ISOCode
FROM Countries
WHERE (LEN(UPPER(CountryName)) - LEN(REPLACE(UPPER(CountryName), 'A', ''))) >= 3
ORDER BY ISOCode;

GO

-- PROBLEM 13

SELECT 
    p.PeakName,
    r.RiverName,
    LOWER(LEFT(p.PeakName, LEN(p.PeakName) - 1) + r.RiverName) AS Mix
FROM Peaks AS p
JOIN Rivers AS r
  ON LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix;

GO