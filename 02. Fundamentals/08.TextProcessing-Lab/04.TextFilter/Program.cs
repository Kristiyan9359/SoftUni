internal class Program
{
    static void Main()
    {

        string[] bannedWords = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        string text = Console.ReadLine();

        foreach (string bannedWord in bannedWords)
        {
            string asterisks = new('*', bannedWord.Length);

            text = text.Replace(bannedWord, asterisks);
        }
        Console.WriteLine(text);
    }
}