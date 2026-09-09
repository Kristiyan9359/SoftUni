using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        var regex = new Regex(@"\+359( |-)2\1\d{3}\1\d{4}\b");

        var input = Console.ReadLine();

        var matchedPhones = regex.Matches(input);

        for (int i = 0; i < matchedPhones.Count; i++)
        {
            Console.Write(matchedPhones[i].Value);

            if (i < matchedPhones.Count - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();

    }
}