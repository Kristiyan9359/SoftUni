using System.Text;

internal class Program
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();

        StringBuilder result = new();


        foreach (string word in words)
        {
            int count = word.Length;

            for (int i = 0; i < count; i++)
            {
                result.Append(word);
            }
        }
        Console.WriteLine(result);
    }
}