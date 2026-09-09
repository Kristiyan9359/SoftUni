internal class Program
{
    static void Main()
    {

        string text = Console.ReadLine();

        var stack = new Stack<char>();

        foreach (char item in text)
        {
            stack.Push(item);
        }

        while (stack.Count > 0)
        {
            char item = stack.Pop();
            Console.Write(item);
        }
    }
}