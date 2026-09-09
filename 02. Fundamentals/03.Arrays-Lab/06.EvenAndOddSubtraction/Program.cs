class Program
{
    static void Main()
    {

        int[] numbers = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        int evenSum = 0;
        int oddSum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNum = numbers[i];
            if (currentNum % 2 == 0)
            {
                evenSum += currentNum;
            }
            else
            {
                oddSum += currentNum;
            }
        }
        Console.WriteLine(evenSum - oddSum);
    }
}