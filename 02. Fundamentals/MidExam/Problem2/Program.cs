namespace Problem2;

internal class Program
{
    static void Main()
    {
        string coffee = Console.ReadLine();
        int commandsCount = int.Parse(Console.ReadLine());

        List<string> coffeeNames = coffee.Split(" ").ToList();

        for (int i = 0; i < commandsCount; i++)
        {
            string input = Console.ReadLine();

            string[] tokens = input.Split();

            string command = tokens[0];

            switch (command)
            {
                case "Include":
                    coffeeNames.Add(tokens[1]);
                    break;

                case "Remove":
                    int numberOfCoffees = int.Parse(tokens[2]);

                    if (numberOfCoffees <= coffeeNames.Count)
                    {
                        if (tokens[1] == "first")
                        {
                            coffeeNames.RemoveRange(0, numberOfCoffees);
                        }
                        else if (tokens[1] == "last")
                        {
                            coffeeNames.RemoveRange(coffeeNames.Count - numberOfCoffees, numberOfCoffees);
                        }
                    }
                    break;

                case "Prefer":
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    if (index1 >= 0 && index1 < coffeeNames.Count && index2 >= 0 && index2 < coffeeNames.Count)
                    {
                        string temp = coffeeNames[index1];
                        coffeeNames[index1] = coffeeNames[index2];
                        coffeeNames[index2] = temp;
                    }
                    break;

                case "Reverse":
                    coffeeNames.Reverse();
                    break;

            }
        }
        Console.WriteLine("Coffees:");
        Console.WriteLine(string.Join(" ", coffeeNames));
    }
}