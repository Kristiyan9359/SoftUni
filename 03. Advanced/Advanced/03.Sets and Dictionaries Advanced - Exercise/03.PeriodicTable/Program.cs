internal class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        HashSet<string> set = new();


        for (int i = 0; i < count; i++)
        {
            string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < elements.Length; j++)
            {
                set.Add(elements[j]);
            }
        }

        List<string> orderedSet = set.OrderBy(x => x).ToList();

        foreach (string element in orderedSet)
        {
            Console.Write($"{element} ");
        }
    }
}