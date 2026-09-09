internal class Program
{
    static void Main()
    {

        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        Console.WriteLine(Pow(number, power));

    }
    static double Pow(double number, int power)
    {
        double result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= number;
        }
        return result;
    }
}