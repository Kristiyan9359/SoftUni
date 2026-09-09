internal class Program
{
    static void Main()
    {
        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());

        if (secondChar < firstChar)
        {
            char swap = firstChar;
            firstChar = secondChar;
            secondChar = swap;
        }

        PrintBetween(firstChar, secondChar);
    }

    static void PrintBetween(char firstChar, char secondChar)
    {
        for (int i = firstChar + 1; i < secondChar; i++)
        {
            Console.Write($"{(char)i} ");
        }
    }
}