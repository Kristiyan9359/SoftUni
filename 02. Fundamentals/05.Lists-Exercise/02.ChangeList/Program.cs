internal class Program
{
    static void Main()
    {

        List<int> numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();


        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();

            if (arguments[0] == "Delete")
            {
                numbers.Remove(int.Parse(arguments[1]));
            }
            else if (arguments[0] == "Insert")
            {
                int numberToInsert = int.Parse(arguments[1]);
                int indexToInsert = int.Parse(arguments[2]);
                numbers.Insert(indexToInsert, numberToInsert);
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}