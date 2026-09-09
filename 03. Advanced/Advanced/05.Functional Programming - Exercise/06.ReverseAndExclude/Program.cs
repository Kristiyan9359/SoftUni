internal class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

        int n = int.Parse(Console.ReadLine());

        List<int> newNums = [];

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % n != 0)
            {
                newNums.Add(numbers[i]);
            }
        }
        newNums.Reverse();

        Console.WriteLine(string.Join(" ", newNums));
    }
}