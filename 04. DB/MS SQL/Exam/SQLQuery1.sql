CREATE DATABASE EuroLeagues;


-- PROBLEM 1 -- DDL

CREATE TABLE Leagues
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL
);


CREATE TABLE Teams
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) UNIQUE NOT NULL,
City NVARCHAR(50) NOT NULL,
LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
);


CREATE TABLE Players
(
Id INT PRIMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL,
Position NVARCHAR(20) NOT NULL
);


CREATE TABLE Matches
(
Id INT PRIMARY KEY IDENTITY,
HomeTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
AwayTeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
MatchDate DATETIME2 NOT NULL,
HomeTeamGoals INT NOT NULL DEFAULT (0),
AwayTeamGoals INT NOT NULL DEFAULT (0),
LeagueId INT FOREIGN KEY REFERENCES Leagues(Id) NOT NULL
);


CREATE TABLE PlayersTeams
(
PlayerId INT FOREIGN KEY REFERENCES Players(Id) NOT NULL,
TeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
PRIMARY KEY(PlayerId, TeamId)
);


CREATE TABLE PlayerStats
(
PlayerId INT FOREIGN KEY REFERENCES Players(Id) NOT NULL,
Goals INT NOT NULL DEFAULT (0),
Assists INT NOT NULL DEFAULT (0)
PRIMARY KEY(PlayerId)
);


CREATE TABLE TeamStats
(
TeamId INT FOREIGN KEY REFERENCES Teams(Id) NOT NULL,
Wins INT NOT NULL DEFAULT(0),
Draws INT NOT NULL DEFAULT(0),
Losses INT NOT NULL DEFAULT(0),
PRIMARY KEY(TeamId)
);



-- PROBLEM 2 -- INSERT

INSERT INTO Leagues (Name)
     VALUES ('Eredivisie');

INSERT INTO Teams (Name, City, LeagueId)
     VALUES ('PSV', 'Eindhoven', 6),
            ('Ajax', 'Amsterdam', 6);

INSERT INTO Players (Name, Position)
     VALUES ('Luuk de Jong', 'Forward'),
            ('Josip Sutalo', 'Defender');

INSERT INTO Matches (HomeTeamId, AwayTeamId, MatchDate,	HomeTeamGoals, AwayTeamGoals, LeagueId)
     VALUES (98, 97, '2024-11-02 20:45:00', 3, 2, 6);

INSERT INTO PlayersTeams (PlayerId, TeamId)
     VALUES (2305, 97),
            (2306, 98);

INSERT INTO PlayerStats (PlayerId, Goals, Assists)
     VALUES (2305, 2, 0),
            (2306, 2, 0);

INSERT INTO TeamStats (TeamId, Wins, Draws, Losses)
     VALUES (97, 15, 1, 3),
            (98, 14, 3, 2);



-- PROBLEM 3 -- UPDATE

UPDATE ps
   SET ps.Goals += 1
  FROM PlayerStats AS ps
  JOIN Players AS p
    ON ps.PlayerId = p.Id
  JOIN PlayersTeams AS pt
    ON p.Id = pt.PlayerId
  JOIN Teams AS t
    ON pt.TeamId = t.Id
  JOIN Leagues AS l
    ON t.LeagueId = l.Id
 WHERE p.Position = 'Forward'
   AND l.Name = 'La Liga';



-- PROBLEM 4 -- DELETE

DELETE FROM PlayerStats
      WHERE PlayerId IN (
     SELECT p.Id 
       FROM Players p
       JOIN PlayersTeams pt 
         ON p.Id = pt.PlayerId
       JOIN Teams t 
         ON pt.TeamId = t.Id
       JOIN Leagues l 
         ON t.LeagueId = l.Id
      WHERE l.Name = 'Eredivisie'
);

DELETE FROM PlayersTeams
      WHERE PlayerId IN (
     SELECT p.Id 
       FROM Players p
       JOIN PlayersTeams pt 
         ON p.Id = pt.PlayerId
       JOIN Teams t
         ON pt.TeamId = t.Id
       JOIN Leagues l 
         ON t.LeagueId = l.Id
      WHERE l.Name = 'Eredivisie'
);

DELETE FROM Players
      WHERE Id IN (
     SELECT p.Id 
       FROM Players p
       JOIN PlayersTeams pt 
         ON p.Id = pt.PlayerId
       JOIN Teams t 
         ON pt.TeamId = t.Id
       JOIN Leagues l 
         ON t.LeagueId = l.Id
      WHERE l.Name = 'Eredivisie'
);



-- PROBLEM 5 -- Matches by Goals and Date

  SELECT
         FORMAT(MatchDate, 'yyyy-MM-dd') AS MatchDate,
         HomeTeamGoals,
         AwayTeamGoals,
         (HomeTeamGoals + AwayTeamGoals) AS TotalGoals
    FROM Matches
   WHERE (HomeTeamGoals + AwayTeamGoals) >= 5
ORDER BY TotalGoals DESC, MatchDate;




-- PROBLEM 6 -- Players with Common Part in Their Names


  SELECT 
         p.Name,
         t.City
    FROM Players AS p
    JOIN PlayersTeams AS pt
      ON p.Id = pt.PlayerId
    JOIN Teams AS t
      ON t.Id = pt.TeamId
   WHERE p.Name LIKE '%Aaron%'
ORDER BY p.Name;



-- PROBLEM 7 -- Players in Teams Situated in London


  SELECT 
         p.Id,
         p.Name,
         p.Position
    FROM Players AS p
    JOIN PlayersTeams AS pt
      ON p.Id = pt.PlayerId
    JOIN Teams AS t
      ON t.Id = pt.TeamId
   WHERE t.City LIKE 'London'
ORDER BY p.Name;




-- PROBLEM 8 -- First 10 Matches in Early September


  SELECT TOP 10
         ht.Name AS HomeTeamName,
         at.Name AS AwayTeamName,
         l.Name AS LeagueName,
         FORMAT(m.MatchDate, 'yyyy-MM-dd') AS MatchDate
    FROM Matches AS m
    JOIN Teams AS ht
      ON m.HomeTeamId = ht.Id
    JOIN Teams AS at
      ON m.AwayTeamId = at.Id
    JOIN Leagues AS l
      ON l.Id = m.LeagueId
   WHERE l.Id % 2 = 0
     AND m.MatchDate >= '2024-09-01'
     AND m.MatchDate <= '2024-09-15'
ORDER BY m.MatchDate, ht.Name;




-- PROBLEM 9 -- Best Guest Teams


  SELECT
         t.Id,
         t.Name,
         SUM(m.AwayTeamGoals) AS TotalAwayGoals
    FROM Teams AS t
    JOIN Leagues AS l
      ON t.LeagueId = l.Id
    JOIN Matches AS m
      ON t.Id = m.AwayTeamId
GROUP BY t.Id, t.Name
  HAVING SUM(m.AwayTeamGoals) >= 6
ORDER BY TotalAwayGoals DESC, t.Name;




-- PROBLEM 10 -- Average Scoring Rate


  SELECT 
         l.Name,
         ROUND(CAST(SUM(m.HomeTeamGoals + m.AwayTeamGoals) AS FLOAT) / 
         COUNT(m.Id), 2) AS AvgScoringRate
    FROM Leagues AS l
    JOIN Matches AS m
      ON l.Id = m.LeagueId
GROUP BY l.Name
ORDER BY AvgScoringRate DESC;




-- PROBLEM 11 -- League Top Scorrer


CREATE FUNCTION udf_LeagueTopScorer (@LeagueName NVARCHAR(50))
  RETURNS TABLE
             AS
         RETURN
                (
                SELECT
                       p.Name AS PlayerName,
                       ps.Goals AS TotalGoals
                  FROM Players AS p
                  JOIN PlayerStats AS ps
                    ON p.Id = ps.PlayerId
                  JOIN PlayersTeams AS pt
                    ON p.Id = pt.PlayerId
                  JOIN Teams AS t
                    ON pt.TeamId = t.Id
                  JOIN Leagues AS l
                    ON t.LeagueId = l.Id
                 WHERE l.Name = @LeagueName
                   AND ps.Goals =
                       (
                       SELECT MAX(ps2.Goals)
                         FROM PlayerStats AS ps2
                         JOIN PlayersTeams AS pt2
                           ON ps2.PlayerId = pt2.PlayerId
                         JOIN Teams AS t2
                           ON pt2.TeamId = t2.Id
                         JOIN Leagues AS l2
                           ON t2.LeagueId = l2.Id
                        WHERE l2.Name = @LeagueName
                       )
                );




-- PROBLEM 12 -- Update Player Stats


CREATE PROCEDURE usp_UpdatePlayerStats
       @PlayerId INT,
       @GoalsDelta INT = NULL,
       @AssistsDelta INT = NULL
    AS
 BEGIN
       IF @GoalsDelta IS NOT NULL
         UPDATE PlayerStats 
         SET Goals += @GoalsDelta 
         WHERE PlayerId = @PlayerId;
 
       IF @AssistsDelta IS NOT NULL
         UPDATE PlayerStats 
         SET Assists += @AssistsDelta 
         WHERE PlayerId = @PlayerId;
   END;