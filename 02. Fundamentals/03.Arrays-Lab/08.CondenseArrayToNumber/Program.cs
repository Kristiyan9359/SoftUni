class Program
{
    static void Main()
    {

        int[] numbers = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .ToArray();

        while (numbers.Length > 1)
        {
            int[] condensedArray = new int[numbers.Length - 1];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                condensedArray[i] = numbers[i] + numbers[i + 1];
            }
            numbers = condensedArray;
        }
        Console.WriteLine(numbers[0]);
    }
}