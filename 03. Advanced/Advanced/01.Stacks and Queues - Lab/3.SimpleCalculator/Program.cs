internal class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Stack<int> stack = new Stack<int>();

        stack.Push(int.Parse(input[0]));

        for (int i = 1; i < input.Length; i += 2)
        {
            string operation = input[i];

            int number = int.Parse(input[i + 1]);

            int next = stack.Pop();

            if (operation == "+")
            {
                number += next;
            }
            else if (operation == "-")
            {
                number = next - number;
            }

            stack.Push(number);
        }

        Console.WriteLine(stack.Peek());
    }
}