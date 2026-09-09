
double budget = double.Parse(Console.ReadLine());
double fuelLt = double.Parse(Console.ReadLine());
string weekDay = Console.ReadLine();

double fuelPrice = 2.10;

double totalPrice = (fuelLt * fuelPrice) + 100;

if (weekDay == "Saturday")
{
    totalPrice -= totalPrice * 0.10;
}
else if (weekDay == "Sunday")
{
    totalPrice -= totalPrice * 0.20;
}

if (budget >= totalPrice)
{
    double restMoney = budget - totalPrice;
    Console.WriteLine($"Safari time! Money left: {restMoney:F2} lv. ");
}
else
{
    double moneyNeed = totalPrice - budget;
    Console.WriteLine($"Not enough money! Money needed: {moneyNeed:F2} lv.");
}