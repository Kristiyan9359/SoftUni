internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Stack<int> stack = new();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                stack.Push(i);
            }
            else if (input[i] == ')')
            {
                int startIndex = stack.Pop();
                string substring = input.Substring(startIndex, i - startIndex + 1);
                Console.WriteLine(substring);
            }
        }
    }
}