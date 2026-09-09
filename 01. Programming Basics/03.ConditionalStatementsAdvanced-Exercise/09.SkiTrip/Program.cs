
int days = int.Parse(Console.ReadLine());
string roomType = Console.ReadLine();
string review = Console.ReadLine();

int nights = days - 1;
double price = 0;

if (roomType == "room for one person")
{
    price = 18;
}
else if (roomType == "apartment")
{
    price = 25;

    if (nights < 10)
    {
        price *= 0.70;
    }
    else if (nights >= 10 && nights <= 15)
    {
        price *= 0.65;
    }
    else
    {
        price /= 2;
    }
}
else if (roomType == "president apartment")
{
    price = 35;

    if (nights < 10)
    {
        price *= 0.90;
    }
    else if (nights >= 10 && nights <= 15)
    {
        price *= 0.85;
    }
    else
    {
        price *= 0.80;
    }
}

double price2 = nights * price;

if (review == "positive")
{
    price2 *= 1.25;
}
else if (review == "negative")
{
    price2 *= 0.90; ;
}

Console.WriteLine($"{price2:F2}");