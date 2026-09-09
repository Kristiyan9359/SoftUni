
int guests = int.Parse(Console.ReadLine());
int budget = int.Parse(Console.ReadLine());

int easternBreadPrice = 4;
double eggPrice = 0.45;

double easternBreadCount = Math.Ceiling((double)guests / 3);
int eggCount = guests * 2;

double totalSum = (easternBreadPrice * easternBreadCount) + (eggCount * eggPrice);


if (budget >= totalSum)
{
    double moneyLeft = budget - totalSum;
    Console.WriteLine($"Lyubo bought {easternBreadCount} Easter bread and {eggCount} eggs.");
    Console.WriteLine($"He has {moneyLeft:F2} lv. left.");
}
else
{
    double needMoney = budget - totalSum;
    Console.WriteLine($"Lyubo doesn't have enough money.");
    Console.WriteLine($"He needs {Math.Abs(needMoney):F2} lv. more.");
}

