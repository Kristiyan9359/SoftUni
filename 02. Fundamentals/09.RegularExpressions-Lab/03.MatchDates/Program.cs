using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"\b(?<day>\d{2})([.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            string day = match.Groups["day"].Value;
            string month = match.Groups["month"].Value;
            string year = match.Groups["year"].Value;

            Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
        }
    }
}