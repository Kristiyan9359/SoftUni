
string drink = Console.ReadLine();
string sugar = Console.ReadLine();
int count = int.Parse(Console.ReadLine());

double pricePerCup = 0;

if (drink == "Espresso")
{
    if (sugar == "Without")
        pricePerCup = 0.90;
    else if (sugar == "Normal")
        pricePerCup = 1.00;
    else if (sugar == "Extra")
        pricePerCup = 1.20;
}
else if (drink == "Cappuccino")
{
    if (sugar == "Without")
        pricePerCup = 1.00;
    else if (sugar == "Normal")
        pricePerCup = 1.20;
    else if (sugar == "Extra")
        pricePerCup = 1.60;
}
else if (drink == "Tea")
{
    if (sugar == "Without")
        pricePerCup = 0.50;
    else if (sugar == "Normal")
        pricePerCup = 0.60;
    else if (sugar == "Extra")
        pricePerCup = 0.70;
}

double totalPrice = pricePerCup * count;

if (sugar == "Without")
{
    totalPrice *= 0.65;
}

if (drink == "Espresso" && count >= 5)
{
    totalPrice *= 0.75;
}

if (totalPrice > 15)
{
    totalPrice *= 0.80;
}

Console.WriteLine($"You bought {count} cups of {drink} for {totalPrice:F2} lv.");