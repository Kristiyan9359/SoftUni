
double moneyForTrip = double.Parse(Console.ReadLine());
double savedMoney = double.Parse(Console.ReadLine());
int daysCounter = 0;
int spendDaysCounter = 0;

while (savedMoney < moneyForTrip)
{
    string whatJessieDo = Console.ReadLine();
    double currentMoney = double.Parse(Console.ReadLine());
    daysCounter++;

    if (whatJessieDo == "spend")
    {
        spendDaysCounter++;
        savedMoney -= currentMoney;

        if (savedMoney < 0)
        {
            savedMoney = 0;
        }
        if (spendDaysCounter == 5)
        {
            Console.WriteLine("You can't save the money.");
            Console.WriteLine($"{daysCounter}");
            break;
        }
    }

    else if (whatJessieDo == "save")
    {
        spendDaysCounter = 0;
        savedMoney += currentMoney;
    }
}
if (savedMoney >= moneyForTrip)
{
    Console.WriteLine($"You saved the money for {daysCounter} days.");
}