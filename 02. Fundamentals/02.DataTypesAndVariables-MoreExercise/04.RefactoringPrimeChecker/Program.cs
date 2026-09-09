class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int currentNumber = 2; currentNumber <= n; currentNumber++)
        {
            bool isPrime = true;

            for (int divisor = 2; divisor * divisor <= currentNumber; divisor++)
            {
                if (currentNumber % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine("{0} -> {1}", currentNumber, isPrime.ToString().ToLower());
        }
    }
}