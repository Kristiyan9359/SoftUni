internal class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        string text = Console.ReadLine();

        int begin = nums[0];
        int ends = nums[1];

        Predicate<int> match;

        List<int> result = [];


        if (text == "even")
        {
            match = x => x % 2 == 0;
        }

        else if (text == "odd")
        {
            match = x => x % 2 != 0;
        }

        else
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        for (int i = begin; i <= ends; i++)
        {
            if (match(i))
            {
                result.Add(i);
            }
        }
        Console.WriteLine(string.Join(" ", result));
    }
}