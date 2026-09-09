
string match1 = Console.ReadLine();
string match2 = Console.ReadLine();
string match3 = Console.ReadLine();

int wins = 0;
int losses = 0;
int draws = 0;

string[] matches = { match1, match2, match3 };

foreach (string match in matches)
{
    int teamGoals = match[0] - '0';
    int opponentGoals = match[2] - '0';

    if (teamGoals > opponentGoals)
    {
        wins++;
    }
    else if (teamGoals < opponentGoals)
    {
        losses++;
    }
    else
    {
        draws++;
    }
}

Console.WriteLine($"Team won {wins} games.");
Console.WriteLine($"Team lost {losses} games.");
Console.WriteLine($"Drawn games: {draws}");