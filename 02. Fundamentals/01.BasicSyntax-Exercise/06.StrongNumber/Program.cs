class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int originalNumber = number;
        int sumOfFactorials = 0;

        while (number > 0)
        {
            int digit = number % 10;
            sumOfFactorials += Factorial(digit);
            number /= 10;
        }

        if (sumOfFactorials == originalNumber)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }

    static int Factorial(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
