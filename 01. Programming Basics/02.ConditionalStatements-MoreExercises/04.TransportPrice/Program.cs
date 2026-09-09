
int km = int.Parse(Console.ReadLine());
string dayOrNight = Console.ReadLine();

double tarifPrice = 0;
double price = 0;

if (km < 20)
{
    price = 0.70;

    if (dayOrNight == "day")
    {
        tarifPrice = 0.79;
    }
    else if (dayOrNight == "night")
    {
        tarifPrice = 0.90;
    }
}
else if (km >= 20 && km < 100)
{
    tarifPrice = 0.09;
}
else if (km >= 100)
{
    tarifPrice = 0.06;
}

double finalPrice = price + (km * tarifPrice);

Console.WriteLine($"{finalPrice:F2}");