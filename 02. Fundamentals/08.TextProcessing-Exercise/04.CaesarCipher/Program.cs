using System.Text;

internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        StringBuilder sb = new();

        for (int i = 0; i < text.Length; i++)
        {
            char copyChar = text[i];
            copyChar = (char)(copyChar + 3);

            sb.Append(copyChar);
        }

        Console.WriteLine(sb);
    }
}