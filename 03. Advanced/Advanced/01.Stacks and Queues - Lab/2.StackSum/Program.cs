internal class Program
{
    static void Main()
    {

        int[] numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

        var stack = new Stack<int>(numbers);


        string command;
        while ((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];

            switch (action)
            {
                case "add":
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);
                    stack.Push(first);
                    stack.Push(second);


                    break;

                case "remove":
                    int count = int.Parse(tokens[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }

                    break;
            }
        }
        int sum = 0;
        while (stack.Count > 0)
        {
            sum += stack.Pop();
        }
        Console.WriteLine($"Sum: {sum}");
    }
}