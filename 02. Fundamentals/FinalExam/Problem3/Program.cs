internal class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> heroes = new();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];
            string heroName = tokens[1];

            switch (action)
            {
                case "Enroll":
                    if (!heroes.ContainsKey(heroName))
                    {
                        heroes.Add(heroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    break;


                case "Learn":


                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        break;
                    }
                    if (!heroes[heroName].Contains(tokens[2]))
                    {
                        heroes[heroName].Add(tokens[2]);
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has already learnt {tokens[2]}.");
                    }
                    break;

                case "Unlearn":

                    if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        break;
                    }
                    if (heroes[heroName].Contains(tokens[2]))
                    {
                        heroes[heroName].Remove(tokens[2]);
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} doesn't know {tokens[2]}.");
                    }
                    break;
            }
        }
        Console.WriteLine("Heroes:");
        foreach (var hero in heroes)
        {
            if (hero.Value.Count > 0)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }
            else
            {
                Console.WriteLine($"== {hero.Key}:");
            }
        }
    }
}