internal class Program
{
    static void Main()
    {
        Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

        int counts = int.Parse(Console.ReadLine());

        for (int i = 0; i < counts; i++)
        {
            string word = Console.ReadLine();
            string synonim = Console.ReadLine();

            if (!words.ContainsKey(word))
            {
                words[word] = new List<string>();
            }

            words[word].Add(synonim);
        }

        foreach ((string word, List<string> synonyms) in words)
        {
            Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
        }
    }
}