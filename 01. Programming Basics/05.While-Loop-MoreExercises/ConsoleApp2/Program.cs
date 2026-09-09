
int targetSum = int.Parse(Console.ReadLine());

string input = Console.ReadLine();
int counter = 0;
double sum = 0;
double cash = 0;
double cashCount = 0;
double card = 0;
double cardCount = 0;

while (input != "End")
{
    int price = int.Parse(input);
    counter++;

    if (counter % 2 == 0)
    {
        if (price < 10)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            cardCount++;
            card += price;
            sum += price;
        }
    }
    else
    {
        if (price > 100)
        {
            Console.WriteLine("Error in transaction!");
        }
        else
        {
            Console.WriteLine("Product sold!");
            cardCount++;
            cash += price;
            sum += price;
        }
    }

    if (sum >= targetSum)
    {
        double avgCash = 0; ;
        double avgCard = 0;

        if (cardCount > 0)
        {
            avgCard = card / cardCount;
        }
        else if (cashCount > 0)
        {
            avgCard = cash / cashCount;
        }

        Console.WriteLine($"Average CS: {avgCash:F2}");
        Console.WriteLine($"Average CC: {avgCard:F2}");
        return;
    }



}
Console.WriteLine("Failed to collect required money for charity.");

