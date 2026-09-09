
double budget = double.Parse(Console.ReadLine());
string season = Console.ReadLine();

string carClass = "";
string carType = "";
double rentPrice = 0;

if (budget <= 100)
{
    carClass = "Economy class";

    if (season == "Summer")
    {
        carType = "Cabrio";
        rentPrice = budget * 0.35;
    }
    else if (season == "Winter")
    {
        carType = "Jeep";
        rentPrice = budget * 0.65;
    }
}
else if (budget > 100 && budget <= 500)
{
    carClass = "Compact class";

    if (season == "Summer")
    {
        carType = "Cabrio";
        rentPrice = budget * 0.45;
    }
    else if (season == "Winter")
    {
        carType = "Jeep";
        rentPrice = budget * 0.80;
    }
}
else if (budget > 500)
{
    carClass = "Luxury class";
    carType = "Jeep";
    rentPrice = budget * 0.90;
}

Console.WriteLine(carClass);
Console.WriteLine($"{carType} - {rentPrice:f2}");