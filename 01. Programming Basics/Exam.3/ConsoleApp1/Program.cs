
double flourPrice = double.Parse(Console.ReadLine());
double flourKg = double.Parse(Console.ReadLine());
double sugarKg = double.Parse(Console.ReadLine());
double eggsPacks = double.Parse(Console.ReadLine());
double yeastPacks = double.Parse(Console.ReadLine());

double sugarPrice = flourPrice * 0.25;
double eggsPrice = flourPrice * 1.10;
double yeastPrice = sugarPrice * 0.20;

double totalSum = (flourPrice * flourKg) + (sugarPrice * sugarKg) + (eggsPrice * eggsPacks) + (yeastPrice * yeastPacks);

Console.WriteLine($"{totalSum:F2}");