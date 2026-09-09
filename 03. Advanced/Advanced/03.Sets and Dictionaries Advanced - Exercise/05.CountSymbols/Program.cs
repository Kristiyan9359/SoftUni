internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        Dictionary<char, int> symbolCounter = new();

        foreach (var symbol in text)
        {
            if (!symbolCounter.ContainsKey(symbol))
            {
                symbolCounter[symbol] = 0;
            }
            symbolCounter[symbol]++;
        }

        foreach (var (symbol, count) in symbolCounter.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{symbol}: {count} time/s");
        }
    }
}