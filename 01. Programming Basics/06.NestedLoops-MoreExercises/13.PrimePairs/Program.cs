
int startFirstPair = int.Parse(Console.ReadLine());
int startSecondPair = int.Parse(Console.ReadLine());
int rangeFirstPair = int.Parse(Console.ReadLine());
int rangeSecondPair = int.Parse(Console.ReadLine());

for (int a = startFirstPair; a <= startFirstPair + rangeFirstPair; a++)
{
    for (int b = startSecondPair; b <= startSecondPair + rangeSecondPair; b++)
    {
        if (IsPrime(a) && IsPrime(b))
        {
            Console.WriteLine($"{a}{b}");
        }
    }
}

static bool IsPrime(int number)
{
    if (number < 2) return false;
    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0) return false;
    }
    return true;
}