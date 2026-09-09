class Program
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        int number3 = int.Parse(Console.ReadLine());
        int number4 = int.Parse(Console.ReadLine());

        int first = number1 + number2;
        int second = first / number3;
        int third = second * number4;

        Console.WriteLine(third);
    }
}