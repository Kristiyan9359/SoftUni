
string teamName = Console.ReadLine();
int gamesPlayed = int.Parse(Console.ReadLine());

int points = 0;
int wins = 0;
int draws = 0;
int loses = 0;

if (gamesPlayed == 0)
{
    Console.WriteLine($"{teamName} hasn't played any games during this season.");
    return;
}

for (int i = 0; i < gamesPlayed; i++)
{
    string text = Console.ReadLine();


    if (text == "W")
    {
        points += 3;
        wins++;
    }
    else if (text == "D")
    {
        points += 1;
        draws++;
    }
    else if (text == "L")
    {
        loses++;
    }
}
if (gamesPlayed > 0)
{
    Console.WriteLine($"{teamName} has won {points} points during this season.");
    Console.WriteLine("Total stats:");
    Console.WriteLine($"## W: {wins}");
    Console.WriteLine($"## D: {draws}");
    Console.WriteLine($"## L: {loses}");
    double winRate = (double)wins / gamesPlayed * 100;
    Console.WriteLine($"Win rate: {winRate:F2}%");
}