
string playerName = Console.ReadLine();
int startingPoints = 301;
int successfulShots = 0;
int unsuccessfulShots = 0;

while (true)
{
    string field = Console.ReadLine();

    if (field == "Retire")
    {
        Console.WriteLine($"{playerName} retired after {unsuccessfulShots} unsuccessful shots.");
        break;
    }

    int points = int.Parse(Console.ReadLine());
    int calculatedPoints = 0;

    switch (field)
    {
        case "Single":
            calculatedPoints = points;
            break;
        case "Double":
            calculatedPoints = points * 2;
            break;
        case "Triple":
            calculatedPoints = points * 3;
            break;
    }

    if (calculatedPoints <= startingPoints)
    {
        startingPoints -= calculatedPoints;
        successfulShots++;
    }
    else
    {
        unsuccessfulShots++;
    }

    if (startingPoints == 0)
    {
        Console.WriteLine($"{playerName} won the leg with {successfulShots} shots.");
        break;
    }
}