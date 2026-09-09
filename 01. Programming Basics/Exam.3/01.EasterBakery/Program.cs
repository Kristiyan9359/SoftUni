
double flourPriceKg = double.Parse(Console.ReadLine());
double flourKg = double.Parse(Console.ReadLine());
double sugarKg = double.Parse(Console.ReadLine());
double eggsPacks = double.Parse(Console.ReadLine());
double yeastPacks = double.Parse(Console.ReadLine());

double sugarPriceKg = flourPriceKg * 0.75;
double eggsPacksPrice = flourPriceKg * 1.10;
double yeastPackPrice = sugarPriceKg * 0.20;

double totalSum = (flourPriceKg * flourKg) + (sugarPriceKg * sugarKg) + (eggsPacksPrice * eggsPacks) + (yeastPackPrice * yeastPacks);

Console.WriteLine($"{totalSum:F2}");