
double budget = double.Parse(Console.ReadLine());

string input = string.Empty;

double totalPrice = 0;

int itemsBought = 0;

while (true)
{
    input = Console.ReadLine();

    if (input == "Stop")
    {
        break;
    }
    double priceOfProduct = double.Parse(Console.ReadLine());
    itemsBought++;

    if (itemsBought % 3 == 0)
    {
        priceOfProduct /= 2;
    }

    if (priceOfProduct > budget)
    {
        double moneyNeed = priceOfProduct - budget;
        Console.WriteLine("You don't have enough money!");
        Console.WriteLine($"You need {moneyNeed:F2} leva!");
        return;
    }
    budget -= priceOfProduct;
    totalPrice += priceOfProduct;
}
Console.WriteLine($"You bought {itemsBought} products for {totalPrice:F2} leva.");