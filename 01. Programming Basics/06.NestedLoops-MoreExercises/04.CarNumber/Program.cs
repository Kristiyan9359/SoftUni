int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
string result = "";

for (int a = start; a <= end; a++)
{
    for (int b = start; b <= end; b++)
    {
        for (int c = start; c <= end; c++)
        {
            for (int d = start; d <= end; d++)
            {
                bool isEvenOddMatch = (a % 2 == 0 && d % 2 != 0) || (a % 2 != 0 && d % 2 == 0);

                bool isFirstGreaterThanLast = a > d;

                bool isSumEven = (b + c) % 2 == 0;

                if (isEvenOddMatch && isFirstGreaterThanLast && isSumEven)
                {
                    result += $"{a}{b}{c}{d} ";
                }
            }
        }
    }
}
Console.WriteLine(result.Trim());
