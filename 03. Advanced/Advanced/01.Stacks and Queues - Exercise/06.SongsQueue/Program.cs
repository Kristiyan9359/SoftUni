internal class Program
{
    static void Main()
    {

        List<string> songs = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToList();

        Queue<string> queue = new Queue<string>(songs);

        while (queue.Count > 0)
        {
            string command = Console.ReadLine();
            if (command == "Play")
            {
                queue.Dequeue();
            }
            else if (command == "Show")
            {
                Console.WriteLine(string.Join(", ", queue));
            }
            else if (command.StartsWith("Add"))
            {
                string song = command.Substring(4);
                if (queue.Contains(song))
                {
                    Console.WriteLine($"{song} is already contained!");
                    continue;
                }
                queue.Enqueue(song);
            }
        }
        Console.WriteLine("No more songs!");
    }
}