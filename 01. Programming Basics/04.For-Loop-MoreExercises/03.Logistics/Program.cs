
int numberOfLoads = int.Parse(Console.ReadLine());

double totalWeight = 0;
double totalCost = 0;
double microbusWeight = 0;
double truckWeight = 0;
double trainWeight = 0;

for (int i = 0; i < numberOfLoads; i++)
{
    int loadWeight = int.Parse(Console.ReadLine());
    totalWeight += loadWeight;

    if (loadWeight <= 3)
    {
        totalCost += loadWeight * 200;
        microbusWeight += loadWeight;
    }
    else if (loadWeight <= 11)
    {
        totalCost += loadWeight * 175;
        truckWeight += loadWeight;
    }
    else
    {
        totalCost += loadWeight * 120;
        trainWeight += loadWeight;
    }
}

double averagePricePerTon = totalCost / totalWeight;

double microbusPercentage = (microbusWeight / totalWeight) * 100;
double truckPercentage = (truckWeight / totalWeight) * 100;
double trainPercentage = (trainWeight / totalWeight) * 100;

Console.WriteLine($"{averagePricePerTon:F2}");
Console.WriteLine($"{microbusPercentage:F2}%");
Console.WriteLine($"{truckPercentage:F2}%");
Console.WriteLine($"{trainPercentage:F2}%");