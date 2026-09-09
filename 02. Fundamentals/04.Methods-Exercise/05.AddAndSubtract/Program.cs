internal class Program
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());

        int sum = FirstSum(firstNum, secondNum) - thirdNum;

        Console.WriteLine(sum);
    }

    static int FirstSum(int firstNum, int secondNum)
    {
        int result = firstNum + secondNum;
        return result;
    }
}