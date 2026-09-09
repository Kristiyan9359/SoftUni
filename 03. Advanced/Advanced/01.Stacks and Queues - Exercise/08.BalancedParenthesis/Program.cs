internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        Dictionary<char, char> brackets = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        Stack<char> stack = new Stack<char>();


        bool isBalanced = true;

        for (int i = 0; isBalanced && i < text.Length; i++)
        {
            char currentChar = text[i];
            if (brackets.ContainsKey(currentChar))
            {
                stack.Push(currentChar);
            }
            else if (brackets.ContainsValue(currentChar))
            {
                if (stack.Count == 0 || brackets[stack.Pop()] != currentChar)
                {
                    isBalanced = false;
                }
            }
        }
        if (isBalanced && stack.Count == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}