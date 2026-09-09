internal class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int n = numbers[0];
        int s = numbers[1];
        int x = numbers[2];

        int[] ints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            stack.Push(ints[i]);
        }

        for (int i = 0; i < s; i++)
        {
            stack.Pop();
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("0");
        }
        else if (stack.Contains(x))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}