namespace _04.WildFarm.IO.Interfaces;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
        => Console.WriteLine(obj);
}
