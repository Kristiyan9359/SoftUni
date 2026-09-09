internal class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

        List<int> topIntegers = new();

        int maxRights = int.MinValue;

        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            if (numbers[i] > maxRights)
            {
                topIntegers.Add(numbers[i]);

                maxRights = numbers[i];
            }
        }

        topIntegers.Reverse();

        Console.WriteLine(string.Join(" ", topIntegers));
    }
}