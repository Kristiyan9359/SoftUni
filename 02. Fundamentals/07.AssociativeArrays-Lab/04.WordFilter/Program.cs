internal class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine()
            .Split()
            .Where(w => w.Length % 2 == 0)
            .ToArray();

        Console.WriteLine(string.Join(Environment.NewLine, words));
    }
}