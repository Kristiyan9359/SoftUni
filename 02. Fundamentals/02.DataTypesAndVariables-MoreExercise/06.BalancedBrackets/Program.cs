internal class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool isBalanced = true;

        bool hasOpenBracket = false;

        for (int i = 0; i < n; i++)
        {
            string s = Console.ReadLine();

            if (s == "(")
            {
                if (hasOpenBracket)
                {
                    isBalanced = false;
                    break;
                }
                hasOpenBracket = true;
            }
            else if (s == ")")
            {
                if (!hasOpenBracket)
                {
                    isBalanced = false;
                    break;
                }
                hasOpenBracket = false;
            }
        }
        if (hasOpenBracket)
        {
            isBalanced = false;
        }

        Console.WriteLine(isBalanced ? "BALANCED" : "UNBALANCED");
    }
}