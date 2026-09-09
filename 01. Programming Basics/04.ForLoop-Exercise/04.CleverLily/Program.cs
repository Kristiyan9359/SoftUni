
int age = int.Parse(Console.ReadLine());
double washingMaschinePrice = double.Parse(Console.ReadLine());
int toysPrice = int.Parse(Console.ReadLine());

int toysCount = 0;
int money = 0;
int moneyIntake = 0;

for (int i = 1; i <= age; i++)
{
    if (i % 2 == 1)
    {
        toysCount++;
    }
    else
    {
        moneyIntake += 10;
        money += moneyIntake;
        money--;
    }
}
money += toysCount * toysPrice;

if (money >= washingMaschinePrice)
{
    double remainingMoney = money - washingMaschinePrice;
    Console.WriteLine($"Yes! {remainingMoney:f2}");
}
else
{
    double moneyLeft = washingMaschinePrice - money;
    Console.WriteLine($"No! {moneyLeft:f2}");
}