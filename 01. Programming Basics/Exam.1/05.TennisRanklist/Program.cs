
int tournamentsCount = int.Parse(Console.ReadLine());
int startPoints = int.Parse(Console.ReadLine());

int winnedPoints = 0;
int winnedTournaments = 0;

for (int i = 0; i < tournamentsCount; i++)
{
    string tournamentStage = Console.ReadLine();

    if (tournamentStage == "W")
    {
        winnedPoints += 2000;
        winnedTournaments++;
    }
    else if (tournamentStage == "F")
    {
        winnedPoints += 1200;
    }
    else if (tournamentStage == "SF")
    {
        winnedPoints += 720;
    }
}

int finalPoints = winnedPoints + startPoints;
int averagePoints = winnedPoints / tournamentsCount;
double percent = ((double)winnedTournaments / tournamentsCount) * 100;

Console.WriteLine($"Final points: {finalPoints}");
Console.WriteLine($"Average points: {averagePoints}");
Console.WriteLine($"{percent:F2}%");