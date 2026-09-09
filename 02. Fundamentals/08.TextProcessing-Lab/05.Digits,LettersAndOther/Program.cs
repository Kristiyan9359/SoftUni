using System.Text;

internal class Program
{
    static void Main()
    {

        string input = Console.ReadLine();

        StringBuilder digits = new();
        StringBuilder letters = new();
        StringBuilder others = new();

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
            {
                digits.Append(ch);
            }
            else if (char.IsLetter(ch))
            {
                letters.Append(ch);
            }
            else
            {
                others.Append(ch);
            }
        }
        Console.WriteLine(digits);
        Console.WriteLine(letters);
        Console.WriteLine(others);
    }
}