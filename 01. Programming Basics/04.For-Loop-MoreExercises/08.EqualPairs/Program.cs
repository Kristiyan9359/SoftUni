int couples = int.Parse(Console.ReadLine());

int previousSum = 0;
int maxDifference = 0;
bool isFirstPair = true;

for (int i = 0; i < couples; i++)
{
    int firstNumber = int.Parse(Console.ReadLine());
    int secondNumber = int.Parse(Console.ReadLine());

    int currentSum = firstNumber + secondNumber;

    if (isFirstPair)
    {
        previousSum = currentSum;
        isFirstPair = false;
    }
    else
    {
        int currentDifference = Math.Abs(currentSum - previousSum);

        if (currentDifference > maxDifference)
        {
            maxDifference = currentDifference;
        }
        previousSum = currentSum;
    }
}

if (maxDifference == 0)
{
    Console.WriteLine($"Yes, value={previousSum}");
}
else
{
    Console.WriteLine($"No, maxdiff={maxDifference}");
}
