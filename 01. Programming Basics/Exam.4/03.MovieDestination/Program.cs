
double budget = double.Parse(Console.ReadLine());
string destination = Console.ReadLine();
string season = Console.ReadLine();
int daysCount = int.Parse(Console.ReadLine());

double pricePerDay = 0;

if (destination == "Dubai")
{
    if (season == "Summer")
    {
        pricePerDay = 40000;
    }
    else if (season == "Winter")
    {
        pricePerDay = 45000;
    }
    pricePerDay *= 0.70;
}
else if (destination == "Sofia")
{
    if (season == "Summer")
    {
        pricePerDay = 12500;
    }
    else if (season == "Winter")
    {
        pricePerDay = 17000;
    }
    pricePerDay *= 1.25;
}
else if (destination == "London")
{
    if (season == "Summer")
    {
        pricePerDay = 20250;
    }
    else if (season == "Winter")
    {
        pricePerDay = 24000;
    }
}

double finalPrice = pricePerDay * daysCount;

if (budget >= finalPrice)
{
    double moneyLeft = budget - finalPrice;
    Console.WriteLine($"The budget for the movie is enough! We have {moneyLeft:F2} leva left!");
}
else
{
    double moneyNeed = finalPrice - budget;
    Console.WriteLine($"The director needs {moneyNeed:F2} leva more!");
}