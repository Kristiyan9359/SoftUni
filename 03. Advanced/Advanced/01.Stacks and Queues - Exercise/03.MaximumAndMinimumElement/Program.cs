internal class Program
{
    static void Main()
    {
        int operations = int.Parse(Console.ReadLine());

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < operations; i++)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int num = input[0];

            if (num == 1)
            {
                int x = input[1]; ;
                stack.Push(x);
            }
            else if (num == 2)
            {
                stack.Pop();
            }
            else if (num == 3)
            {
                if (stack.Count > 0) Console.WriteLine(stack.Max());
            }
            else if (num == 4)
            {
                if (stack.Count > 0) Console.WriteLine(stack.Min());
            }
        }
        Console.WriteLine(string.Join(", ", stack));
    }
}