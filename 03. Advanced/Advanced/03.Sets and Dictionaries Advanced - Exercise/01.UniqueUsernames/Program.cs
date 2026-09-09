internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        HashSet<string> names = new();

        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine();

            names.Add(name);
        }
        Console.WriteLine(string.Join("\n", names));
    }
}