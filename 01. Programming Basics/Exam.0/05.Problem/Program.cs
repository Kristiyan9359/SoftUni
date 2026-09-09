
string bestPlayer = "";
int mostGoals = 0;

while (true)
{
    string playerName = Console.ReadLine();

    if (playerName == "END")
    {
        break;
    }

    int goals = int.Parse(Console.ReadLine());

    if (goals > mostGoals)
    {
        bestPlayer = playerName;
        mostGoals = goals;
    }

    if (goals >= 10)
    {
        break;
    }
}

Console.WriteLine($"{bestPlayer} is the best player!");

if (mostGoals >= 3)
{
    Console.WriteLine($"He has scored {mostGoals} goals and made a hat-trick !!!");
}
else
{
    Console.WriteLine($"He has scored {mostGoals} goals.");
}