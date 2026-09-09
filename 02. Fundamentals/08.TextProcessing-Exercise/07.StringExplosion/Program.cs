using System.Text;

internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string result = ProcessExplosions(input);

        Console.WriteLine(result);
    }

    private static string ProcessExplosions(string input)
    {
        StringBuilder sb = new();

        int strength = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '>')
            {
                strength += int.Parse(input[i + 1].ToString());
                sb.Append(input[i]);
            }
            else if (strength == 0)
            {
                sb.Append(input[i]);
            }
            else
            {
                strength--;
            }
        }
        return sb.ToString();
    }
}