int dog = int.Parse(Console.ReadLine());
int cat = int.Parse(Console.ReadLine());

double dogFood = 2.50;
double catFood = 4;

double totalCost  = (dog * dogFood) + (cat * catFood);
Console.WriteLine($"{totalCost} lv.");