internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Queue<string> queue = new Queue<string>();

        int counter = 0;


        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            if (command == "green")
            {
                for (int i = 0; i < n && queue.Count > 0; i++)
                {
                    Console.WriteLine($"{queue.Dequeue()} passed!");
                    counter++;
                }
            }
            else
            {
                queue.Enqueue(command);
            }
        }
        Console.WriteLine($"{counter} cars passed the crossroads.");
    }
}