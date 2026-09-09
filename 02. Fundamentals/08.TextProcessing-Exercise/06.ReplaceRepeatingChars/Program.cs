using System.Text;

internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder sb = new();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine(sb.ToString());
            return;
        }

        sb.Append(input[0]);

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                sb.Append(input[i]);
            }
        }

        Console.WriteLine(sb.ToString());
    }
}