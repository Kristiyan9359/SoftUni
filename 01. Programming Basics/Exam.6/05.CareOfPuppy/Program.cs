
int foodKg = int.Parse(Console.ReadLine());
int totalFoodGrams = foodKg * 1000;
int totalEatenFood = 0;

string command = Console.ReadLine();

while (command != "Adopted")
{
    int foodEaten = int.Parse(command);
    totalEatenFood += foodEaten;
    command = Console.ReadLine();
}

if (totalEatenFood <= totalFoodGrams)
{
    int leftovers = totalFoodGrams - totalEatenFood;
    Console.WriteLine($"Food is enough! Leftovers: {leftovers} grams.");
}
else
{
    int neededFood = totalEatenFood - totalFoodGrams;
    Console.WriteLine($"Food is not enough. You need {neededFood} grams more.");
}