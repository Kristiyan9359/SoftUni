internal class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();

        Dictionary<string, int> counts = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string wordInLowerCase = word.ToLower();

            if (counts.ContainsKey(wordInLowerCase))
            {
                counts[wordInLowerCase]++;
            }
            else
            {
                counts.Add(wordInLowerCase, 1);
            }
        }

        Console.WriteLine(string.Join(" ", counts.Keys.Where(key => counts[key] % 2 != 0)));
    }
}