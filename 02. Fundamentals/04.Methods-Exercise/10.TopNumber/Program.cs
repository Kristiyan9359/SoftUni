internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i < n; i++)
        {
            if (IsTopNumber(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsTopNumber(int num)
    {
        if (IsDivisibleByEight(num) && HassOddDigit(num))
        {
            return true;
        }
        return false;
    }

    static bool HassOddDigit(int num)
    {
        while (num > 0)
        {
            int digit = num % 10;
            num /= 10;

            if (digit % 2 != 0)
            {
                return true;
            }
        }
        return false;
    }

    static bool IsDivisibleByEight(int num)
    {
        int sumOfDigits = 0;

        while (num > 0)
        {
            int digit = num % 10;
            sumOfDigits += digit;
            num /= 10;
        }
        return sumOfDigits % 8 == 0;
    }
}