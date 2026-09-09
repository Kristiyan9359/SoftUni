
string fuelType = Console.ReadLine();
double fuelQuantity = double.Parse(Console.ReadLine());
string clubCard = Console.ReadLine();

double fuelPrice = 0;


if (fuelType == "Gasoline")
{
    fuelPrice = 2.22;

    if (clubCard == "Yes")
    {
        fuelPrice -= 0.18;
    }
}
else if (fuelType == "Diesel")
{
    fuelPrice = 2.33;

    if (clubCard == "Yes")
    {
        fuelPrice -= 0.12;
    }
}
else if (fuelType == "Gas")
{
    fuelPrice = 0.93;

    if (clubCard == "Yes")
    {
        fuelPrice -= 0.08;
    }
}
double totalPrice = fuelPrice * fuelQuantity;

if (fuelQuantity >= 20 && fuelQuantity <= 25)
{
    totalPrice *= 0.92;
}
else if (fuelQuantity > 20)
{
    totalPrice *= 0.90;
}


Console.WriteLine($"{totalPrice:F2} lv.");