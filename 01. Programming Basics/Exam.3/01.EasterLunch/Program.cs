
int breadRolls = int.Parse(Console.ReadLine());
int eggsPacks = int.Parse(Console.ReadLine());
int cookiesKg = int.Parse(Console.ReadLine());

double breadRollPrice = 3.20;
double eggPackPrice = 4.35;
double eggPaint = 0.15;
double cookie = 5.40;

double totalSum = (breadRolls * breadRollPrice) + (eggsPacks * eggPackPrice) + (eggsPacks * 12 * eggPaint) + (cookiesKg * cookie);

Console.WriteLine($"{totalSum:F2}");