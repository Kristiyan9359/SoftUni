
int numberOfEasterBreads = int.Parse(Console.ReadLine());
int totalSugar = 0;
int totalFlour = 0;
int maxSugar = 0;
int maxFlour = 0;

for (int i = 0; i < numberOfEasterBreads; i++)
{
    int sugarUsed = int.Parse(Console.ReadLine());
    int flourUsed = int.Parse(Console.ReadLine());

    totalSugar += sugarUsed;
    totalFlour += flourUsed;

    if (sugarUsed > maxSugar)
    {
        maxSugar = sugarUsed;
    }

    if (flourUsed > maxFlour)
    {
        maxFlour = flourUsed;
    }
}
int sugarPackages = (int)Math.Ceiling(totalSugar / 950.0);
int flourPackages = (int)Math.Ceiling(totalFlour / 750.0);

Console.WriteLine($"Sugar: {sugarPackages}");
Console.WriteLine($"Flour: {flourPackages}");
Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");