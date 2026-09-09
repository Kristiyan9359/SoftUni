
int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
int magicNumber = int.Parse(Console.ReadLine());

int combinationCount = 0;
bool found = false;

for (int i = start; i <= end; i++)
{
    for (int j = start; j <= end; j++)
    {
        combinationCount++;

        if (i + j == magicNumber)
        {
            Console.WriteLine($"Combination N:{combinationCount} ({i} + {j} = {magicNumber})");
            found = true;
            return;
        }
    }
}

if (!found)
{
    Console.WriteLine($"{combinationCount} combinations - neither equals {magicNumber}");
}
