using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        int inputs = int.Parse(Console.ReadLine());

        string pattern = @"^(?<symbols>.+)>(?<group1>\d{3})\|(?<group2>[a-z]{3})\|(?<group3>[A-Z]{3})\|(?<group4>[^<>]{3})<\k<symbols>$";

        for (int i = 0; i < inputs; i++)
        {
            string input = Console.ReadLine();

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string encryptedPass = match.Groups["group1"].Value +
                    match.Groups["group2"].Value +
                    match.Groups["group3"].Value +
                    match.Groups["group4"].Value;

                Console.WriteLine($"Password: {encryptedPass}");
            }
            else
            {
                Console.WriteLine("Try another password!");
            }
        }
    }
}