
double priceFor20kg = double.Parse(Console.ReadLine());
double luggageKg = double.Parse(Console.ReadLine());
int daysTillTravel = int.Parse(Console.ReadLine());
int luggageCount = int.Parse(Console.ReadLine());

double priceForBags = 0;

if (luggageKg < 10)
{
    priceForBags = priceFor20kg * 0.20;
}
else if (luggageKg >= 10 && luggageKg <= 20)
{
    priceForBags = priceFor20kg / 2;
}
else if (luggageKg > 20)
{
    priceForBags = priceFor20kg;
}
if (daysTillTravel > 30)
{
    priceForBags *= 1.10;
}
else if (daysTillTravel >= 7 && daysTillTravel <= 30)
{
    priceForBags *= 1.15;
}
else if (daysTillTravel < 7)
{
    priceForBags *= 1.40;
}

double totalPrice = priceForBags * luggageCount;

Console.WriteLine($"The total price of bags is: {totalPrice:F2} lv. ");