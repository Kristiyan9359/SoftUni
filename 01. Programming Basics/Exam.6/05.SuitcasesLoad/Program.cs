
double trunkCapacity = double.Parse(Console.ReadLine());
int suitcaseCounter = 0;
int suitcaseNumber = 0;

string input = Console.ReadLine();

while (input != "End")
{
    double suitcaseVolume = double.Parse(input);
    suitcaseNumber++;

    if (suitcaseNumber % 3 == 0)
    {
        suitcaseVolume *= 1.10;
    }

    if (trunkCapacity >= suitcaseVolume)
    {
        trunkCapacity -= suitcaseVolume;
        suitcaseCounter++;
    }
    else
    {
        Console.WriteLine("No more space!");
        Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");
        return;
    }

    input = Console.ReadLine();
}

Console.WriteLine("Congratulations! All suitcases are loaded!");
Console.WriteLine($"Statistic: {suitcaseCounter} suitcases loaded.");