class Program
{
    static void Main()
    {
        int orders = int.Parse(Console.ReadLine());

        double totalPrice = 0;

        for (int i = 1; i <= orders; i++)
        {
            double pricePerCapsule = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());
            double capsulesCount = double.Parse(Console.ReadLine());

            double price = (days * capsulesCount) * pricePerCapsule;

            Console.WriteLine($"The price for the coffee is: ${price:F2}");

            totalPrice += price;
        }
        Console.WriteLine($"Total: ${totalPrice:F2}");
    }
}