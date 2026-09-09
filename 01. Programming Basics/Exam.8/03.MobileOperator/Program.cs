
string contractDuration = Console.ReadLine();
string contractType = Console.ReadLine();
string netOption = Console.ReadLine();
int monthsCount = int.Parse(Console.ReadLine());

double price = 0;

if (contractType == "Small")
{
    if (contractDuration == "one")
    {
        price = 9.98;
    }
    else if (contractDuration == "two")
    {
        price = 8.58;
    }

}
else if (contractType == "Middle")
{
    if (contractDuration == "one")
    {
        price = 18.99;
    }
    else if (contractDuration == "two")
    {
        price = 17.09;
    }
}
else if (contractType == "Large")
{
    if (contractDuration == "one")
    {
        price = 25.98;
    }
    else if (contractDuration == "two")
    {
        price = 23.59;
    }
}
else if (contractType == "ExtraLarge")
{
    if (contractDuration == "one")
    {
        price = 35.99;
    }
    else if (contractDuration == "two")
    {
        price = 31.79;
    }
}
if (netOption == "yes")
{
    if (price <= 10)
    {
        price += 5.50;
    }
    else if (price > 10 && price <= 30)
    {
        price += 4.35;
    }
    else if (price > 30)
    {
        price += 3.85;
    }
}
if (contractDuration == "two")
{
    price *= 0.9625;
}

double finalPrice = price * monthsCount;
Console.WriteLine($"{finalPrice:F2} lv.");