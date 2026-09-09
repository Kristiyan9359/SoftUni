
string fruit = Console.ReadLine();
string setSize = Console.ReadLine();
int setsCount = int.Parse(Console.ReadLine());

double pricePerGel = 0;

int gelsPerSet;

if (setSize == "small")
{
    gelsPerSet = 2;
}
else
{
    gelsPerSet = 5;
}

if (fruit == "Watermelon")
{
    if (setSize == "small")
    {
        pricePerGel = 56;
    }
    else
    {
        pricePerGel = 28.70;
    }
}
else if (fruit == "Mango")
{
    if (setSize == "small")
    {
        pricePerGel = 36.66;
    }
    else
    {
        pricePerGel = 19.60;
    }
}
else if (fruit == "Pineapple")
{
    if (setSize == "small")
    {
        pricePerGel = 42.10;
    }
    else
    {
        pricePerGel = 24.80;
    }
}
else if (fruit == "Raspberry")
{
    if (setSize == "small")
    {
        pricePerGel = 20;
    }
    else
    {
        pricePerGel = 15.20;
    }
}

double totalPrice = gelsPerSet * pricePerGel * setsCount;

if (totalPrice >= 400 && totalPrice <= 1000)
{
    totalPrice *= 0.85;
}
else if (totalPrice > 1000)
{
    totalPrice *= 0.50;
}

Console.WriteLine($"{totalPrice:F2} lv.");