
double budget = double.Parse(Console.ReadLine());
string category = Console.ReadLine();
int peopleCount = int.Parse(Console.ReadLine());

double ticketPrice = 0;

if (peopleCount <= 4)
{
    budget *= 0.25;
}
else if (peopleCount < 10 && peopleCount > 4)
{
    budget *= 0.40;
}
else if (peopleCount >= 10 && peopleCount <= 24)
{
    budget /= 2;
}
else if (peopleCount > 24 && peopleCount <= 49)
{
    budget *= 0.60;
}
else if (peopleCount >= 50)
{
    budget *= 0.75;
}

if (category == "VIP")
{
    ticketPrice = 499.99;
}
else if (category == "Normal")
{
    ticketPrice = 249.99;
}

double totalPrice = ticketPrice * peopleCount;

if (budget >= totalPrice)
{
    double moneyLeft = budget - totalPrice;
    Console.WriteLine($"Yes! You have {moneyLeft:F2} leva left.");
}
else
{
    double moneyNeed = totalPrice - budget;
    Console.WriteLine($"Not enough money! You need {moneyNeed:F2} leva.");
}