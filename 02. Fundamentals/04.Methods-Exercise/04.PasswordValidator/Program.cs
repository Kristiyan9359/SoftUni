internal class Program
{
    static void Main()
    {
        string password = Console.ReadLine();

        bool lengthCheckPassed = CheckLength(password);

        bool symbolCheckPassed = CheckForSpecialSymbols(password);

        bool twoDigitsCheckPassed = CheckForTwoDigits(password);

        if (!lengthCheckPassed)
        {
            Console.WriteLine("Password must be between 6 and 10 characters");
        }
        if (!symbolCheckPassed)
        {
            Console.WriteLine("Password must consist only of letters and digits");
        }
        if (!twoDigitsCheckPassed)
        {
            Console.WriteLine("Password must have at least 2 digits");
        }
        if (lengthCheckPassed && symbolCheckPassed && twoDigitsCheckPassed)
        {
            Console.WriteLine("Password is valid");
        }
    }
    static bool CheckForTwoDigits(string password)
    {
        int counter = 0;
        foreach (char symbol in password)
        {
            if (symbol >= 48 && symbol <= 57)
            {
                counter++;
            }
        }
        if (counter < 2)
        {
            return false;
        }
        return true;
    }
    static bool CheckForSpecialSymbols(string password)
    {
        for (int i = 0; i < password.Length; i++)
        {
            char symbol = password[i];

            if (symbol >= 65 && symbol <= 90 ||
                symbol >= 97 && symbol <= 122 ||
                symbol >= 48 && symbol <= 57)
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    static bool CheckLength(string password)
    {
        if (password.Length < 6 || password.Length > 10)
        {
            return false;
        }
        return true;
    }
}