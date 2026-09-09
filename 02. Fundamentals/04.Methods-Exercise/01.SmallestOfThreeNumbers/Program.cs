internal class Program
{
    static void Main()
    {

        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());

        int minNumber = GetMinNumber(firstNumber, secondNumber);
        minNumber = GetMinNumber(minNumber, thirdNumber);

        Console.WriteLine(minNumber);
    }

    static int GetMinNumber(int firstNumber, int secondNumber)
    {
        if (firstNumber < secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }
}