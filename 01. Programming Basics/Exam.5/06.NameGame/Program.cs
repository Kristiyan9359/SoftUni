
string winner = string.Empty;
int maxPoints = int.MinValue;

while (true)
{
    string playerName = Console.ReadLine();
    if (playerName == "Stop")
    {
        break;
    }

    int points = 0;

    for (int i = 0; i < playerName.Length; i++)
    {
        int number = int.Parse(Console.ReadLine());
        if (number == (int)playerName[i])
        {
            points += 10;
        }
        else
        {
            points += 2;
        }
    }

    if (points >= maxPoints)
    {
        maxPoints = points;
        winner = playerName;
    }
}

Console.WriteLine($"The winner is {winner} with {maxPoints} points!");