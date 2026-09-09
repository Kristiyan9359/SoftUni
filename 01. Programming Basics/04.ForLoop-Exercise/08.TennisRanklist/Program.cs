
int tournamentsCount = int.Parse(Console.ReadLine());
int initialPoints = int.Parse(Console.ReadLine());

int winsCount = 0;
int points = 0;

for (int i = 1; i <= tournamentsCount; i++)
{
    string tournamentResults = Console.ReadLine();

    if (tournamentResults == "W")
    {
        points += 2000;
        winsCount++;
    }
    else if (tournamentResults == "F")
    {
        points += 1200;
    }
    else if (tournamentResults == "SF")
    {
        points += 720;
    }
}
double averagePoints = (double)points / tournamentsCount;
points += initialPoints;
double winsPercent = (double)winsCount / tournamentsCount * 100;

Console.WriteLine($"Final points: {points}");
Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
Console.WriteLine($"{winsPercent:f2}%");


