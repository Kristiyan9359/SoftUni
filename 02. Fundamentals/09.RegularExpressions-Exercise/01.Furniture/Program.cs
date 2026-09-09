using System.Text.RegularExpressions;

internal class Program
{
    static void Main()
    {
        var regex = @">>(?<product>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";

        var products = new List<string>();

        double totalPrice = 0;

        string command;

        while ((command = Console.ReadLine()) != "Purchase")
        {
            var match = Regex.Match(command, regex);

            if (match.Success)
            {
                var name = match.Groups["product"].Value;
                var price = double.Parse(match.Groups["price"].Value);
                var quantity = int.Parse(match.Groups["quantity"].Value);

                totalPrice += price * quantity;
                products.Add(name);
            }
        }

        Console.WriteLine("Bought furniture:");

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine($"Total money spend: {totalPrice:F2}");

    }
}