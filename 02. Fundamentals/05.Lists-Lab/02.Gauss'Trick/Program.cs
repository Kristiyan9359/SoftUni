internal class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToList();

        int initialCount = numbers.Count;

        for (int i = 0; i < initialCount / 2; i++)
        {
            numbers[i] += numbers[numbers.Count - 1];

            numbers.RemoveAt(numbers.Count - 1);
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}