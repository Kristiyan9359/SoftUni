
int a1 = int.Parse(Console.ReadLine());
int a2 = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

for (int symbol1 = a1; symbol1 <= a2 - 1; symbol1++)
{
    if (symbol1 % 2 == 0)
    {
        continue;
    }

    for (int symbol2 = 1; symbol2 <= n - 1; symbol2++)
    {
        for (int symbol3 = 1; symbol3 <= n / 2 - 1; symbol3++)
        {
            int symbol4 = symbol1;

            if ((symbol2 + symbol3 + symbol4) % 2 != 0)
            {
                Console.WriteLine($"{(char)symbol1}-{symbol2}{symbol3}{symbol4}");
            }
        }
    }
}