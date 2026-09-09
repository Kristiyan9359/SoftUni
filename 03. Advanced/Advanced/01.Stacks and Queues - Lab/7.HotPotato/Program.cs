internal class Program
{
    static void Main()
    {
        string[] players = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(Console.ReadLine());

        Queue<string> queue = new Queue<string>(players);

        while (queue.Count > 1)
        {
            int iterations = (n - 1) % queue.Count;

            for (int i = 0; i < iterations; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            Console.WriteLine($"Removed {queue.Dequeue()}");
        }
        Console.WriteLine($"Last is {queue.Dequeue()}");
    }
}