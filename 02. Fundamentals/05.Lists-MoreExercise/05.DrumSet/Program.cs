class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());


        List<int> firstLine = new List<int>();

        List<int> secondLine = new List<int>();

        for (int i = 0; i < number; i++)
        {
            int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            if (i % 2 == 0)
            {
                firstLine.Add(numbers[0]);
                secondLine.Add(numbers[1]);
            }

            else if (i % 2 != 0)
            {
                firstLine.Add(numbers[1]);
                secondLine.Add(numbers[0]);
            }

        }

        Console.WriteLine(string.Join(" ", firstLine));
        Console.WriteLine(string.Join(" ", secondLine));
    }


}