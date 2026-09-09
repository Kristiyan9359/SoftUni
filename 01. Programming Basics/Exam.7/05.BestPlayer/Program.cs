
string bestPlayer = string.Empty;
int maxGoals = 0;

while (true)
{
    string playerName = Console.ReadLine();

    if (playerName == "END")
    {
        break;
    }
    int goals = int.Parse(Console.ReadLine());

    if (goals > maxGoals)
    {
        bestPlayer = playerName;
        maxGoals = goals;
    }
    if (goals >= 10)
    {
        break;
    }
}
Console.WriteLine($"{bestPlayer} is the best player!");
if (maxGoals >= 3)
{
    Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
}
else
{
    Console.WriteLine($"He has scored {maxGoals} goals.");
}