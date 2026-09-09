class Program
{
    static void Main()
    {
        char ch = char.Parse(Console.ReadLine());

        bool isUpper = char.IsUpper(ch);

        if (isUpper)
        {
            Console.WriteLine("upper-case");
        }
        else
        {
            Console.WriteLine("lower-case");
        }
    }
}