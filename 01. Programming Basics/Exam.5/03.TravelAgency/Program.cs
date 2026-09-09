
string city = Console.ReadLine();
string pack = Console.ReadLine();
string vipDiscount = Console.ReadLine();
int days = int.Parse(Console.ReadLine());

double pricePerDay = 0;

if (days < 1)
{
    Console.WriteLine("Days must be positive number!");
    return;
}

if (city == "Bansko" || city == "Borovets")
{
    if (pack == "withEquipment")
    {
        pricePerDay = 100;

        if (vipDiscount == "yes")
        {
            pricePerDay *= 0.90;
        }
    }
    else if (pack == "noEquipment")
    {
        pricePerDay = 80;

        if (vipDiscount == "yes")
        {
            pricePerDay *= 0.95;
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
        return;
    }
}
else if (city == "Varna" || city == "Burgas")
{
    if (pack == "withBreakfast")
    {
        pricePerDay = 130;

        if (vipDiscount == "yes")
        {
            pricePerDay *= 0.88;
        }
    }
    else if (pack == "noBreakfast")
    {
        pricePerDay = 100;

        if (vipDiscount == "yes")
        {
            pricePerDay *= 0.93;
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
        return;
    }
}
else
{
    Console.WriteLine("Invalid input!");
    return;
}

if (days > 7)
{
    days--;
}

double finalPrice = pricePerDay * days;

Console.WriteLine($"The price is {finalPrice:F2}lv! Have a nice time!");

