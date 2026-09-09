internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine(GetMiddleIndex(input));
    }

    static string GetMiddleIndex(string input)
    {
        int middleIndex = input.Length / 2;

        string result = $"{input[middleIndex]}";

        if (input.Length % 2 == 0)
        {
            result = $"{input[middleIndex - 1] + result}";
        }
        return result;
    }
}
