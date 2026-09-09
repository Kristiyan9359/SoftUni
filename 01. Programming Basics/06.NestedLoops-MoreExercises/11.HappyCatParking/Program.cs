
int days = int.Parse(Console.ReadLine());
int hours = int.Parse(Console.ReadLine());

double totalSum = 0;

for (int i = 1; i <= days; i++)
{
    double daySum = 0;

    for (int j = 1; j <= hours; j++)
    {
        double price = 1.0;

        if (i % 2 == 0 && j % 2 != 0)
        {
            price = 2.50;
        }
        else if (i % 2 != 0 && j % 2 == 0)
        {
            price = 1.25;
        }

        daySum += price;
    }

    Console.WriteLine($"Day: {i} - {daySum:F2} leva");
    totalSum += daySum;
}

Console.WriteLine($"Total: {totalSum:F2} leva");
