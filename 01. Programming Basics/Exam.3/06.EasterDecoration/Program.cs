
int clientsCount = int.Parse(Console.ReadLine());

double basketPrice = 1.50;
double wreathPrice = 3.80;
double chocoBunny = 7.00;

double totalBill = 0;

for (int i = 0; i < clientsCount; i++)
{
    int itemsCount = 0;
    double totalPrice = 0;

    string input = Console.ReadLine();

    while (input != "Finish")
    {
        if (input == "basket")
        {
            itemsCount++;
            totalPrice += basketPrice;
        }
        else if (input == "wreath")
        {
            itemsCount++;
            totalPrice += wreathPrice;
        }
        else if (input == "chocolate bunny")
        {
            itemsCount++;
            totalPrice += chocoBunny;
        }
        input = Console.ReadLine();
    }

    if (itemsCount % 2 == 0)
    {
        totalPrice *= 0.80;
    }

    totalBill += totalPrice;
    Console.WriteLine($"You purchased {itemsCount} items for {totalPrice:F2} leva.");
}

double averagePrice = totalBill / clientsCount;
Console.WriteLine($"Average bill per client is: {averagePrice:F2} leva.");
