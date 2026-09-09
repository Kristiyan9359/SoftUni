
int days = int.Parse(Console.ReadLine());
double totalFood = double.Parse(Console.ReadLine());

double dogFoodTotal = 0;
double catFoodTotal = 0;
double biscuitsTotal = 0;

for (int day = 1; day <= days; day++)
{
    int dogFood = int.Parse(Console.ReadLine());
    int catFood = int.Parse(Console.ReadLine());

    double dailyFoodEaten = dogFood + catFood;

    if (day % 3 == 0)
    {
        double biscuits = dailyFoodEaten * 0.1;
        biscuitsTotal += biscuits;
    }

    dogFoodTotal += dogFood;
    catFoodTotal += catFood;
}

double totalFoodEaten = dogFoodTotal + catFoodTotal;
double percentEaten = (totalFoodEaten / totalFood) * 100;
double dogPercent = (dogFoodTotal / totalFoodEaten) * 100;
double catPercent = (catFoodTotal / totalFoodEaten) * 100;

Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsTotal)}gr.");
Console.WriteLine($"{percentEaten:F2}% of the food has been eaten.");
Console.WriteLine($"{dogPercent:F2}% eaten from the dog.");
Console.WriteLine($"{catPercent:F2}% eaten from the cat.");