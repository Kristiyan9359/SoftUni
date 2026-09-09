
int n = int.Parse(Console.ReadLine());

string result = "";

for (int d1 = 1; d1 <= 9; d1++)
{
    for (int d2 = 1; d2 <= 9; d2++)
    {
        for (int d3 = 1; d3 <= 9; d3++)
        {
            for (int d4 = 1; d4 <= 9; d4++)
            {
                int sum1 = d1 + d2;
                int sum2 = d3 + d4;

                if (sum1 == sum2 && n % sum1 == 0)
                {
                    result += $"{d1}{d2}{d3}{d4} ";
                }
            }
        }
    }
}

Console.WriteLine(result.Trim());