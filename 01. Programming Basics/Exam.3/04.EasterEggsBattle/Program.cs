
int playerOneEggs = int.Parse(Console.ReadLine());
int playerTwoEggs = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

while (input != "End")
{
    if (input == "one")
    {
        playerTwoEggs--;
    }
    else if (input == "two")
    {
        playerOneEggs--;
    }

    if (playerOneEggs == 0)
    {
        Console.WriteLine($"Player one is out of eggs. Player two has {playerTwoEggs} eggs left.");
        return;
    }
    else if (playerTwoEggs == 0)
    {
        Console.WriteLine($"Player two is out of eggs. Player one has {playerOneEggs} eggs left.");
        return;
    }
    input = Console.ReadLine();
}
Console.WriteLine($"Player one has {playerOneEggs} eggs left.");
Console.WriteLine($"Player two has {playerTwoEggs} eggs left.");