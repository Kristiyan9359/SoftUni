internal class Program
{
    static void Main()
    {
        int pumpsCount = int.Parse(Console.ReadLine());

        Queue<int[]> station = new Queue<int[]>();

        for (int i = 0; i < pumpsCount; i++)
        {
            int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            station.Enqueue(data);
        }

        int ans = -1;

        for (int i = 0; i < pumpsCount; i++)
        {
            bool canFinishRoute = true;
            int fuel = 0;

            foreach (var pump in station)
            {
                int petrol = pump[0];
                int distance = pump[1];
                fuel += petrol - distance;
                if (fuel < 0)
                {
                    canFinishRoute = false;
                    break;
                }
            }

            if (canFinishRoute)
            {
                ans = i;
                break;
            }
            int[] firstPump = station.Dequeue();
            station.Enqueue(firstPump);
        }
        Console.WriteLine(ans);
    }
}