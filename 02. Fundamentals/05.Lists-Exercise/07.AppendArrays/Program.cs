internal class Program
{
    static void Main()
    {

        List<string> input = Console.ReadLine()
        .Split("|", StringSplitOptions.RemoveEmptyEntries)
        .Reverse()
        .ToList();

        List<int> result = new();

        foreach (string part in input)
        {
            result.AddRange(part
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
        }
        Console.WriteLine(string.Join(" ", result));
    }
}