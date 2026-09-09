internal class Program
{
    static void Main()
    {
        string product = Console.ReadLine();
        int quantity = int.Parse(Console.ReadLine());

        PrintOrder(product, quantity);
    }
    static void PrintOrder(string product, int quantity)
    {
        decimal coffee = 1.50m;
        decimal water = 1.00m;
        decimal coke = 1.40m;
        decimal snacks = 2.00m;

        switch (product)
        {
            case "coffee":
                Console.WriteLine($"{(quantity * coffee):F2}");
                break;
            case "water":
                Console.WriteLine($"{(quantity * water):F2}");
                break;
            case "coke":
                Console.WriteLine($"{(quantity * coke):F2}");
                break;
            case "snacks":
                Console.WriteLine($"{(quantity * snacks):F2}");
                break;
        }
    }
}