
int minutesWalk = int.Parse(Console.ReadLine());
int walkingCounts = int.Parse(Console.ReadLine());
int caloriesPerDay = int.Parse(Console.ReadLine());

double walking = minutesWalk * walkingCounts;
double caloriesBurned = walking * 5;
double caloriesTaken = caloriesPerDay / 2;

if (caloriesBurned >= caloriesTaken)
{
    Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
}
else
{
    Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
}