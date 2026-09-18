using System.Linq;

public class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine()
           .Split()
           .Select(int.Parse)
           .ToArray();

        Array.Sort(numbers, Compare);

        Console.WriteLine(string.Join(" ", numbers));
    }

    static int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 != 0)
        {
            return -1;
        }

        if (x % 2 != 0 && y % 2 == 0)
        {
            return 1;
        }

        return x.CompareTo(y);
    }
}