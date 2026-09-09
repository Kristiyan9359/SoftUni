
int fatPercent = int.Parse(Console.ReadLine());
int proteinPercent = int.Parse(Console.ReadLine());
int carbsPercent = int.Parse(Console.ReadLine());
int totalCalories = int.Parse(Console.ReadLine());
int waterPercent = int.Parse(Console.ReadLine());

double fatGrams = (fatPercent / 100.0 * totalCalories) / 9;
double proteinGrams = (proteinPercent / 100.0 * totalCalories) / 4;
double carbsGrams = (carbsPercent / 100.0 * totalCalories) / 4;

double totalFoodWeight = fatGrams + proteinGrams + carbsGrams;

double totalFoodWeightWithWater = totalFoodWeight / (1 - waterPercent / 100.0);

double caloriesPerGram = totalCalories / totalFoodWeightWithWater;

Console.WriteLine($"{caloriesPerGram:f4}");
