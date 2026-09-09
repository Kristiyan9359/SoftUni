class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string reversed = "";

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        Console.WriteLine(reversed);
    }
}