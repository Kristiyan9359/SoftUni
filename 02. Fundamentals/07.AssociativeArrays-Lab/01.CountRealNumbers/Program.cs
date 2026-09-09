internal class Program
{
    static void Main()
    {

        double[] numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(double.Parse)
        .ToArray();

        SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

        foreach (var number in numbers)
        {
            if (counts.ContainsKey(number))
            {
                counts[number]++;
            }

            else
            {
                counts.Add(number, 1);
            }
        }

        foreach (var number in counts)
        {
            Console.WriteLine($"{number.Key} -> {number.Value}");
        }
    }
}