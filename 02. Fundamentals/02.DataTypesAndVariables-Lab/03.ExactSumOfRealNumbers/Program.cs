class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        decimal sum = 0
            ;
        for (int i = 0; i < count; i++)
        {
            sum += decimal.Parse(Console.ReadLine());
        }

        Console.WriteLine(sum);

    }
}