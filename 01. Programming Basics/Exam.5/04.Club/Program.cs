
double targetProfit = double.Parse(Console.ReadLine());
double totalIncome = 0.0;

while (true)
{
    string cocktailName = Console.ReadLine();

    if (cocktailName == "Party!")
    {
        double remainingMoney = targetProfit - totalIncome;
        Console.WriteLine($"We need {remainingMoney:F2} leva more.");
        break;
    }

    int cocktailCount = int.Parse(Console.ReadLine());

    double orderPrice = cocktailName.Length * cocktailCount;

    if (orderPrice % 2 != 0)
    {
        orderPrice *= 0.75;
    }

    totalIncome += orderPrice;

    if (totalIncome >= targetProfit)
    {
        Console.WriteLine("Target acquired.");
        break;
    }
}

Console.WriteLine($"Club income - {totalIncome:F2} leva.");