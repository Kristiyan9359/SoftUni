
int days = int.Parse(Console.ReadLine());
int hoursPerDay = int.Parse(Console.ReadLine());

double totalCost = 0;

for (int day = 1; day <= days; day++)
{
    double dailyCost = 0;

    for (int hour = 1; hour <= hoursPerDay; hour++)
    {
        if (day % 2 == 0 && hour % 2 != 0)
        {
            dailyCost += 2.50;
        }
        else if (day % 2 != 0 && hour % 2 == 0)
        {
            dailyCost += 1.25;
        }
        else
        {
            dailyCost += 1.00;
        }
    }

    Console.WriteLine($"Day: {day} - {dailyCost:F2} leva");
    totalCost += dailyCost;
}

Console.WriteLine($"Total: {totalCost:F2} leva");