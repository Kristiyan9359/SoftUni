class Program
{
    static void Main()
    {
        decimal dollars = decimal.Parse(Console.ReadLine());

        decimal pounds = 1.31m;

        decimal sum = dollars * pounds;

        Console.WriteLine($"{sum:F3}");
    }
}