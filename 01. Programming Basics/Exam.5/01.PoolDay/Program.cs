
int people = int.Parse(Console.ReadLine());
double entryFee = double.Parse(Console.ReadLine());
double sunbedPrice = double.Parse(Console.ReadLine());
double umbrellaPrice = double.Parse(Console.ReadLine());

double totalEntryFee = people * entryFee;

int umbrellasNeeded = (int)Math.Ceiling(people / 2.0);

int sunbedsNeeded = (int)Math.Ceiling(people * 0.75);

double totalUmbrellaCost = umbrellasNeeded * umbrellaPrice;
double totalSunbedCost = sunbedsNeeded * sunbedPrice;

double totalCost = totalEntryFee + totalUmbrellaCost + totalSunbedCost;

Console.WriteLine($"{totalCost:F2} lv.");