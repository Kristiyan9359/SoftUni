internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        int vowelsCount = GetVowelsCount(input);

        Console.WriteLine(vowelsCount);
    }

    static int GetVowelsCount(string input)
    {
        int count = 0;
        input = input.ToLower();

        foreach (var symbol in input)
        {
            if (symbol == 'a' ||
                symbol == 'e' ||
                symbol == 'o' ||
                symbol == 'i' ||
                symbol == 'u')
            {
                count++;
            }
        }
        return count;
    }
}