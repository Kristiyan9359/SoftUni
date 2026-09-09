internal class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        Dictionary<int, int> keyValuePairs = new();

        for (int i = 0; i < count; i++)
        {
            int n = int.Parse(Console.ReadLine());

            if (!keyValuePairs.ContainsKey(n))
            {
                keyValuePairs[n] = 0;
            }

            keyValuePairs[n]++;
        }

        Console.WriteLine(keyValuePairs.Single(x => x.Value % 2 == 0).Key);
    }
}