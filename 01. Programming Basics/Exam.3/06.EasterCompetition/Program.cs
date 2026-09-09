
int numberOfEasterBreads = int.Parse(Console.ReadLine());

string bestBaker = "";
int highestPoints = 0;

for (int i = 0; i < numberOfEasterBreads; i++)
{
    string bakerName = Console.ReadLine();
    int totalPoints = 0;
    string input;

    while ((input = Console.ReadLine()) != "Stop")
    {
        int points = int.Parse(input);
        totalPoints += points;
    }

    Console.WriteLine($"{bakerName} has {totalPoints} points.");

    if (totalPoints > highestPoints)
    {
        highestPoints = totalPoints;
        bestBaker = bakerName;
        Console.WriteLine($"{bakerName} is the new number 1!");
    }
}

Console.WriteLine($"{bestBaker} won competition with {highestPoints} points!");