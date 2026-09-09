
int upperLimit1 = int.Parse(Console.ReadLine());
int upperLimit2 = int.Parse(Console.ReadLine());
int upperLimit3 = int.Parse(Console.ReadLine());

for (int i = 1; i <= upperLimit1; i++)
{
    for (int j = 1; j <= upperLimit2; j++)
    {
        for (int k = 1; k <= upperLimit3; k++)
        {
            bool isFirstAndThird = (i % 2 == 0) && (k % 2 == 0);

            bool isSecondPrime = (j == 2 || j == 3 || j == 5 || j == 7);

            if (isFirstAndThird && isSecondPrime)
            {
                Console.WriteLine($"{i} {j} {k}");
            }
        }
    }
}