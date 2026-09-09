namespace _04.WildFarm.IO.Interfaces;

public class ConsoleReader : IReader
{
    public string ReadLine()
        => Console.ReadLine();
}