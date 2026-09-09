internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        int minNum = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number < minNum)
            {
                minNum = number;
            }
        }
        Console.WriteLine(minNum);
    }
}