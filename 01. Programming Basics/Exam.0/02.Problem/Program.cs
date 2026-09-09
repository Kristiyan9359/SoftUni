
double shirtPrice = double.Parse(Console.ReadLine());
double sumNeededToWin = double.Parse(Console.ReadLine());


double shortsPrice = shirtPrice * 0.75;
double socksPrice = shortsPrice * 0.20;
double shoesPrice = (shirtPrice + shortsPrice) * 2;

double totalPrice = shirtPrice + shortsPrice + socksPrice + shoesPrice;

double discount = totalPrice * 0.85;

if (discount >= sumNeededToWin)
{
    Console.WriteLine("Yes, he will earn the world-cup replica ball!");
    Console.WriteLine($"His sum is {discount:f2} lv.");
}
else
{
    double needMoney = sumNeededToWin - discount;
    Console.WriteLine("No, he will not earn the world-cup replica ball.");
    Console.WriteLine($"He needs {needMoney:f2} lv. more.");
}
