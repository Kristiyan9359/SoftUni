internal class Program
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());
        int count = int.Parse(Console.ReadLine());

        string message = "";

        for (int i = 0; i < count; i++)
        {
            char symbol = char.Parse(Console.ReadLine());
            char newSymbol = (char)(symbol + key);
            message += newSymbol;

        }
        Console.WriteLine(message);
    }
}