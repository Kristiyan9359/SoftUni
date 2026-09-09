namespace Problem1;

internal class Program
{
    static void Main()
    {
        int biscuitPerDay = int.Parse(Console.ReadLine());
        int workersCount = int.Parse(Console.ReadLine());
        int competingFactory = int.Parse(Console.ReadLine());

        int days = 30;
        double biscuitsCount = 0;

        for (int i = 1; i <= days; i++)
        {
            if (i % 3 == 0)
            {
                biscuitsCount += Math.Floor((biscuitPerDay * workersCount) * 0.75);
            }
            else
            {
                biscuitsCount += biscuitPerDay * workersCount;
            }
        }

        Console.WriteLine($"You have produced {biscuitsCount} biscuits for the past month.");

        double difference = biscuitsCount - competingFactory;
        double percent = Math.Abs(difference / competingFactory) * 100;

        if (biscuitsCount > competingFactory)
        {
            Console.WriteLine($"You produce {percent:F2} percent more biscuits.");
        }
        else
        {
            Console.WriteLine($"You produce {percent:F2} percent less biscuits.");
        }
    }
}