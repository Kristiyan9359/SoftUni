internal class Program
{
    static void Main()
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());

        Console.WriteLine($"{(Factorial(first) / Factorial(second)):F2}");
    }

    static double Factorial(int number)
    {
        double result = 1;

        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }
}