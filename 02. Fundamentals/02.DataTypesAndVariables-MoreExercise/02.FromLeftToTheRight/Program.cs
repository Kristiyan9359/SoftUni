class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            long leftNum = long.Parse(input[0]);
            long rightNum = long.Parse(input[1]);

            long numToCalculate = leftNum > rightNum ? leftNum : rightNum;

            Console.WriteLine(SumDigits(Math.Abs(numToCalculate)));
        }
    }

    static long SumDigits(long number)
    {
        long sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }
}