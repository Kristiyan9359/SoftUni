
int K = int.Parse(Console.ReadLine());
int L = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
int N = int.Parse(Console.ReadLine());

int validSubstitutions = 0;

for (int firstDigit1 = K; firstDigit1 <= 8; firstDigit1++)
{
    for (int secondDigit1 = 9; secondDigit1 >= L; secondDigit1--)
    {
        if (firstDigit1 % 2 == 0 && secondDigit1 % 2 != 0)
        {
            for (int firstDigit2 = M; firstDigit2 <= 8; firstDigit2++)
            {
                for (int secondDigit2 = 9; secondDigit2 >= N; secondDigit2--)
                {
                    if (firstDigit2 % 2 == 0 && secondDigit2 % 2 != 0)
                    {
                        if (firstDigit1 == firstDigit2 && secondDigit1 == secondDigit2)
                        {
                            Console.WriteLine("Cannot change the same player.");
                        }
                        else
                        {
                            Console.WriteLine($"{firstDigit1}{secondDigit1} - {firstDigit2}{secondDigit2}");
                            validSubstitutions++;

                            if (validSubstitutions == 6)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}