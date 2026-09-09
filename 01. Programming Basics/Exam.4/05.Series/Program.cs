
double budget = double.Parse(Console.ReadLine());
int serialsCount = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int i = 0; i < serialsCount; i++)
{
    string serialName = Console.ReadLine();
    double serialPrice = double.Parse(Console.ReadLine());

    if (serialName == "Thrones")
    {
        serialPrice *= 0.50;
    }
    else if (serialName == "Lucifer")
    {
        serialPrice *= 0.60;
    }
    else if (serialName == "Protector")
    {
        serialPrice *= 0.70;
    }
    else if (serialName == "TotalDrama")
    {
        serialPrice *= 0.80;
    }
    else if (serialName == "Area")
    {
        serialPrice *= 0.90;
    }

    totalPrice += serialPrice;
}

if (budget >= totalPrice)
{
    double moneyLeft = budget - totalPrice;
    Console.WriteLine($"You bought all the series and left with {moneyLeft:F2} lv.");
}
else
{
    double moneyNeed = totalPrice - budget;
    Console.WriteLine($"You need {moneyNeed:F2} lv. more to buy the series!");
}