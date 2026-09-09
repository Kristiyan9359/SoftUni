
int guests = int.Parse(Console.ReadLine());
double ticketPrice = double.Parse(Console.ReadLine());
double budget = double.Parse(Console.ReadLine());

double cakePrice = budget * 0.10;
double discount = 0;

if (guests >= 10 && guests <= 15)
{
    discount = 0.15;
}
else if (guests > 15 && guests <= 20)
{
    discount = 0.20;
}
else if (guests > 20)
{
    discount = 0.25;
}

double discountSum = ticketPrice - (ticketPrice * discount);
double totalSum = (guests * discountSum) + cakePrice;


if (budget >= totalSum)
{
    double moneyLeft = budget - totalSum;
    Console.WriteLine($"It is party time! {moneyLeft:F2} leva left.");
}
else
{
    double moneyNeed = totalSum - budget;
    Console.WriteLine($"No party! {moneyNeed:F2} leva needed.");
}

