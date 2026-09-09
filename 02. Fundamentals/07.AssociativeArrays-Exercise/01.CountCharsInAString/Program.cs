internal class Program
{
    static void Main()
    {
        Dictionary<char, int> charOccurences = new();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            var character = input[i];

            if (character == ' ')
            {
                continue;
            }

            if (!charOccurences.ContainsKey(character))
            {
                charOccurences.Add(character, 0);
            }

            charOccurences[character]++;
        }

        foreach (var pair in charOccurences)
        {
            char character = pair.Key;
            int occurences = pair.Value;
            Console.WriteLine($"{character} -> {occurences}");
        }
    }
}