public class Program
{
    public static void Main()
    {
        Stack<int> solarEnergy = new Stack<int>(
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

        Queue<int> dailyDistances = new Queue<int>(
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

        Dictionary<string, int> resourceRequirements = new Dictionary<string, int>()
        {
            { "Iron", 80 },
            { "Titanium", 90 },
            { "Aluminium", 100 },
            { "Chlorine", 60 },
            { "Sulfur", 70 }
        };

        Queue<string> resourceOrder = new Queue<string>(resourceRequirements.Keys);
        List<string> collectedResources = new List<string>();

        int days = 0;

        while (solarEnergy.Count > 0 && dailyDistances.Count > 0 && resourceOrder.Count > 0 && days < 7)
        {
            int energy = solarEnergy.Pop();
            int distance = dailyDistances.Dequeue();
            int total = energy + distance;

            string currentResource = resourceOrder.Peek();
            int requiredAmount = resourceRequirements[currentResource];

            if (total >= requiredAmount)
            {
                collectedResources.Add(currentResource);
                resourceOrder.Dequeue();
            }

            days++;
        }

        if (resourceOrder.Count == 0)
        {
            Console.WriteLine("Mission complete! All minerals have been collected.");
        }
        else
        {
            Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
        }

        if (collectedResources.Count > 0)
        {
            Console.WriteLine("Collected resources:");
            foreach (var resource in collectedResources)
            {
                Console.WriteLine(resource);
            }
        }
    }
}
