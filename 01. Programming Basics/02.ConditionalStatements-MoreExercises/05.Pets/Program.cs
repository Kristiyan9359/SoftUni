
double days = double.Parse(Console.ReadLine());
double totalFoodLeft = double.Parse(Console.ReadLine());
double dogFoodLeft = double.Parse(Console.ReadLine());
double catFoodLeft = double.Parse(Console.ReadLine());
double turtoiseFoodLeftMg = double.Parse(Console.ReadLine());

double dogFoodNeed = days * dogFoodLeft;
double catFoodNeed = days * catFoodLeft;
double turtoiseFoodNeed = (days * turtoiseFoodLeftMg) / 1000;

double totalFoodNeed = dogFoodNeed + catFoodNeed + turtoiseFoodNeed;

if (totalFoodNeed <= totalFoodLeft)
{
    double foodLeft = Math.Floor(totalFoodLeft - totalFoodNeed);
    Console.WriteLine($"{foodLeft} kilos of food left.");
}
else
{
    double foodNeed = Math.Ceiling(totalFoodNeed - totalFoodLeft);
    Console.WriteLine($"{foodNeed} more kilos of food are needed.");
}

