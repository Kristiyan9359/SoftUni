using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

        string input = Console.ReadLine();

        MatchCollection matchedNames = Regex.Matches(input, regex);

        foreach (Match name in matchedNames)
        {
            Console.Write(name.Value + " ");
        }

        Console.WriteLine();
    }
}