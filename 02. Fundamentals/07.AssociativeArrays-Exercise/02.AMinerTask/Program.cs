internal class Program
{
    static void Main()
    {
        Dictionary<string, int> resources = new();

        while (true)
        {
            string resource = Console.ReadLine();

            if (resource == "stop")
            {
                break;
            }

            int quantity = int.Parse(Console.ReadLine());

            if (!resources.ContainsKey(resource))
            {
                resources.Add(resource, 0);
            }
            resources[resource] += quantity;
        }

        foreach (var pair in resources)
        {
            Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
    }
}