class Program
{
    static void Main()
    {
        double[] numbers = Console.ReadLine()
         .Split(' ')
         .Select(double.Parse)
         .ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            double roundedNumber = (int)Math.Round(numbers[i], MidpointRounding.AwayFromZero);
            Console.WriteLine($"{numbers[i]} => {roundedNumber}");
        }
    }
}