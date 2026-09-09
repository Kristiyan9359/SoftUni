
double budget = double.Parse(Console.ReadLine());
double statists = double.Parse(Console.ReadLine());
double outfitPrice = double.Parse(Console.ReadLine());

double decoration = budget * 0.10;

double statistCost = statists * outfitPrice;

if (statists >= 150)
{
    statistCost -= statistCost * 0.10;
}

double finalPrice = statistCost + decoration;

if (budget >= finalPrice)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine("Action!");
    Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
}
else
{
    double moneyNeed = finalPrice - budget;
    Console.WriteLine("Not enough money!");
    Console.WriteLine($"Wingard needs {moneyNeed:F2} leva more.");
}