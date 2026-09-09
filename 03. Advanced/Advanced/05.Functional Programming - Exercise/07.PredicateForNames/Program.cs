internal class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());

        string[] strings = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> predicate = x => x.Length <= length;

        for (int i = 0; i < strings.Length; i++)
        {
            if (predicate(strings[i]))
            {
                Console.WriteLine(strings[i]);
            }
        }
    }
}