
double moneyLegacy = double.Parse(Console.ReadLine());
int yearToLive = int.Parse(Console.ReadLine());

int ivanchoYears = 18;

for (int i = 1800; i <= yearToLive; i++)
{

    if (i % 2 == 0)
    {
        moneyLegacy -= 12000;
    }
    else
    {
        moneyLegacy -= 12000 + ivanchoYears * 50;
    }
    ivanchoYears++;
}

if (moneyLegacy >= 0)
{
    Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLegacy:F2} dollars left.");
}
else
{
    Console.WriteLine($"He will need {Math.Abs(moneyLegacy):F2} dollars to survive.");
}