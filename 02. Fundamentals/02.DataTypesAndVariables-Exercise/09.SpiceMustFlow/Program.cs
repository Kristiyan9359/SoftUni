class Program
{
    static void Main()
    {

        int yield = int.Parse(Console.ReadLine());

        int extractedSpices = 0;
        int days = 0;

        int minYield = 100;
        int yieldDrops = 10;
        int consumation = 26;

        while (yield >= minYield)
        {
            extractedSpices += yield - consumation;
            days++;
            yield -= yieldDrops;
        }

        extractedSpices -= consumation;

        if (extractedSpices < 0)
        {
            extractedSpices = 0;
        }

        Console.WriteLine(days);
        Console.WriteLine(extractedSpices);
    }
}