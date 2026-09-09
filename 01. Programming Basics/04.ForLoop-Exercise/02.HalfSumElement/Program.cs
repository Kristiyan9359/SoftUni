
int n = int.Parse(Console.ReadLine());

int sum = 0;
int maxNumber = int.MinValue;

for (int i = 0; i < n; i++)
{
    int currentNum = int.Parse(Console.ReadLine());
    sum += currentNum;

    if (maxNumber < currentNum)
    {
        maxNumber = currentNum;
    }
}

int sumWithoutMaxNum  = sum - maxNumber;

if (maxNumber == sumWithoutMaxNum)
{
    Console.WriteLine("Yes");
    Console.WriteLine($"Sum = {sumWithoutMaxNum}");
}
else
{
    int difference = Math.Abs(maxNumber - sumWithoutMaxNum);
    Console.WriteLine("No");
    Console.WriteLine($"Diff = {difference}");
}