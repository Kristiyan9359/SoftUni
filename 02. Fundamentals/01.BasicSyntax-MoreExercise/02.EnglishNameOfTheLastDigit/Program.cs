internal class Program
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(GetLastNumber(number));
    }

    static string GetLastNumber(int number)
    {
        int lastDigit = Math.Abs(number) % 10;

        string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digitNames[lastDigit];
    }
}