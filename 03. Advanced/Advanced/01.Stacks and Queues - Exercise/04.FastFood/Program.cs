internal class Program
{
    static void Main()
    {
        int foodQuantity = int.Parse(Console.ReadLine());

        int[] foodOrders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Queue<int> queue = new Queue<int>(foodOrders);

        for (int i = 0; i < foodOrders.Length; i++)
        {
            if (foodQuantity >= queue.Peek())
            {
                foodQuantity -= queue.Dequeue();
            }
            else
            {
                Console.WriteLine($"{foodOrders.Max()}");
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                return;
            }

        }
        Console.WriteLine($"{foodOrders.Max()}");
        Console.WriteLine("Orders complete");
    }
}