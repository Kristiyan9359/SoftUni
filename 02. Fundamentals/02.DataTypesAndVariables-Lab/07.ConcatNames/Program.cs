class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        string lastName = Console.ReadLine();
        string delimiter = (Console.ReadLine());

        Console.WriteLine($"{name}{delimiter}{lastName}");
    }
}