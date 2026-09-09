internal class Program
{
    static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        char @operator = char.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());

        Console.WriteLine(Calculation(firstNum, @operator, secondNum));
    }

    static double Calculation(int firstNum, char @operator, int secondNum)
    {
        switch (@operator)
        {
            case '+': return firstNum + secondNum;
            case '-': return firstNum - secondNum;
            case '*': return firstNum * secondNum;
            default: return (double)firstNum / secondNum;
        }
    }
}