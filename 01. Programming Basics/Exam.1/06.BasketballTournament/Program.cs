
int totalGamesPlayed = 0;
int totalWins = 0;
int totalLosses = 0;

while (true)
{
    string tournamentName = Console.ReadLine();

    if (tournamentName == "End of tournaments")
    {
        break;
    }

    int numberOfGames = int.Parse(Console.ReadLine());
    for (int game = 1; game <= numberOfGames; game++)
    {
        int desiPoints = int.Parse(Console.ReadLine());
        int opponentPoints = int.Parse(Console.ReadLine());

        totalGamesPlayed++;
        if (desiPoints > opponentPoints)
        {
            totalWins++;
            int pointDifference = desiPoints - opponentPoints;
            Console.WriteLine($"Game {game} of tournament {tournamentName}: win with {pointDifference} points.");
        }
        else
        {
            totalLosses++;
            int pointDifference = opponentPoints - desiPoints;
            Console.WriteLine($"Game {game} of tournament {tournamentName}: lost with {pointDifference} points.");
        }
    }
}

double winPercentage = (double)totalWins / totalGamesPlayed * 100;
double lossPercentage = (double)totalLosses / totalGamesPlayed * 100;

Console.WriteLine($"{winPercentage:F2}% matches win");
Console.WriteLine($"{lossPercentage:F2}% matches lost");
