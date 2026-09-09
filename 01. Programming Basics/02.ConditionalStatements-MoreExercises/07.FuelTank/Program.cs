
string fuelType = Console.ReadLine();
int liters = int.Parse(Console.ReadLine());

if (fuelType == "Diesel" || fuelType == "Gasoline" || fuelType == "Gas")
{
    if (liters < 25)
    {
        Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
    }
    else
    {
        Console.WriteLine($"You have enough {fuelType.ToLower()}.");
    }
}
else
{
    Console.WriteLine($"Invalid fuel!");
}