internal class Program
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();

        while (secondLine.Contains(firstLine))
        {
            int startIndex = secondLine.IndexOf(firstLine);

            secondLine = secondLine.Remove(startIndex, firstLine.Length);
        }

        Console.WriteLine(secondLine);
    }
}