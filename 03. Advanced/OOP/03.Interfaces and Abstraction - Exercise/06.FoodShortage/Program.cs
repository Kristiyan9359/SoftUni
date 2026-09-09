using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;

internal class Program
{
    static void Main()
    {
        List<IBuyer> buyers = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            if (tokens.Length == 4)
            {
                Citizen citizen = new(tokens[0], tokens[1], tokens[2], tokens[3]);
                buyers.Add(citizen);
            }
            else
            {
                Rebel rebel = new(tokens[0], tokens[1], tokens[2]);
                buyers.Add(rebel);
            }
        }


        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            buyers.FirstOrDefault(buyer => buyer.Name == command)?.AddFood();
        }
        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}