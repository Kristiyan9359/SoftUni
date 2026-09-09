internal class Program
{
    static void Main()
    {

        List<string> names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        List<string> newNames = new List<string>();

        for (int i = 0; i < names.Count; i++)
        {
            newNames.Add(names[i]);
        }

        for (int i = 0; i < newNames.Count; i++)
        {
            Console.WriteLine(newNames[i]);
        }
    }
}