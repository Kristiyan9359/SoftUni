internal class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

        List<int> detonation = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();


        int number = detonation[0];
        int power = detonation[1];

        while (numbers.Contains(number))
        {
            int index = numbers.IndexOf(number);

            int leftIndex = Math.Max(0, index - power);
            int rightIndex = Math.Min(numbers.Count - 1, index + power);

            int range = rightIndex - leftIndex + 1;

            numbers.RemoveRange(leftIndex, range);

        }
        int sum = numbers.Sum();

        Console.WriteLine(sum);
    }
}