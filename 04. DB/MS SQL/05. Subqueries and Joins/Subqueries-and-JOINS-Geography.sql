-- PROBLEM 12

SELECT 
       c.CountryCode,
       m.MountainRange,
       p.PeakName,
       p.Elevation
  FROM Countries AS c
  JOIN MountainsCountries AS cm
    ON c.CountryCode = cm.CountryCode
  JOIN Mountains AS m
    ON cm.MountainId = m.Id
  JOIN Peaks AS p
    ON p.MountainId = m.Id
 WHERE c.CountryCode = 'BG'
   AND p.Elevation > 2835
ORDER BY p.Elevation DESC;


-- PROBLEM 13


SELECT 
    c.CountryCode,
    COUNT(DISTINCT m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc
    ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
    ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode
ORDER BY c.CountryCode;


-- PROBLEM 14

   SELECT TOP 5
          c.CountryName,
          r.RiverName
     FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
       ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
       ON r.Id = cr.RiverId
     JOIN Continents AS co
       ON c.ContinentCode = co.ContinentCode
    WHERE co.ContinentName = 'Africa'
 ORDER BY c.CountryName ASC;
 


 -- PROBLEM 15


 -- PROBLEM 16

   SELECT 
          COUNT(*) AS Count
     FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
       ON c.CountryCode = mc.CountryCode
    WHERE mc.MountainId IS NULL


 -- PROBLEM 17


 -- PROBLEM 18
