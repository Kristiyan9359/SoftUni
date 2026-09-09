internal class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();
            string operation = tokens[0];

            if (operation == "Add")
            {
                int number = int.Parse(tokens[1]);
                numbers.Add(number);
            }
            else if (operation == "Insert")
            {
                int number = int.Parse(tokens[1]);
                int index = int.Parse(tokens[2]);
                if (index >= 0 && index < numbers.Count)
                {
                    numbers.Insert(index, number);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (operation == "Remove")
            {
                int index = int.Parse(tokens[1]);
                if (index >= 0 && index < numbers.Count)
                {
                    numbers.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (operation == "Shift")
            {
                int count = int.Parse(tokens[2]);
                if (tokens[1] == "left")
                {
                    for (int i = 0; i < count; i++)
                    {
                        int first = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(first);
                    }
                }
                else if (tokens[1] == "right")
                {
                    for (int i = 0; i < count; i++)
                    {
                        int last = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, last);
                    }
                }
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
