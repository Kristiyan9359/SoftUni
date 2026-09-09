internal class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine()
          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
          .Select(int.Parse)
          .ToList();


        string input;
        while ((input = Console.ReadLine()) != "end")
        {

            if (input == "add")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] += 1;
                }
            }
            else if (input == "multiply")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] *= 2;
                }
            }
            else if (input == "subtract")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] -= 1;
                }
            }
            else if (input == "print")
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}