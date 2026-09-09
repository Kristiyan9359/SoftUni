
int loze = int.Parse(Console.ReadLine());
double grapesPro1SqM = double.Parse(Console.ReadLine());
int neededLtWine = int.Parse(Console.ReadLine());
int workersCount = int.Parse(Console.ReadLine());

double grapes = loze * grapesPro1SqM;
double grapesForWine = grapes * 0.4;
double wineProduced = grapesForWine / 2.5;

if (wineProduced < neededLtWine)
{
    double wineNeed = neededLtWine - wineProduced;
    Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeed)} liters wine needed.");
}

else
{
    double moreWine = wineProduced - neededLtWine;
    double wineForPeople = moreWine / workersCount;
    Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProduced)} liters.");
    Console.WriteLine($"{Math.Ceiling(moreWine)} liters left -> {Math.Ceiling(wineForPeople)} liters per person.");
}