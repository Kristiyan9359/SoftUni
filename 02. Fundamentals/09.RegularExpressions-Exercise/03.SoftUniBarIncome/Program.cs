using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.*\d*)\$";

        double totalIncome = 0;

        string command;

        while ((command = Console.ReadLine()) != "end of shift")
        {
            Match match = Regex.Match(command, pattern);

            if (match.Success)
            {
                string customer = match.Groups[1].Value;
                string product = match.Groups[2].Value;
                int quantity = int.Parse(match.Groups[3].Value);
                double price = double.Parse(match.Groups[4].Value);
                double totalPrice = quantity * price;
                totalIncome += totalPrice;
                Console.WriteLine($"{customer}: {product} - {totalPrice:F2}");
            }
        }
        Console.WriteLine($"Total income: {totalIncome:F2}");
    }
}