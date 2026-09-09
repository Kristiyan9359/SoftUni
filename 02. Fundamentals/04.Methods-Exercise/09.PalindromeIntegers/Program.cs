internal class Program
{
    static void Main()
    {
        string numberAsString = "";

        while ((numberAsString = Console.ReadLine()) != "END")
        {
            Console.WriteLine(IsPalindrome(numberAsString));
        }
    }

    static bool IsPalindrome(string numberAsString)
    {
        string reversedString = Reverse(numberAsString);

        if (reversedString == numberAsString)
        {
            return true;
        }
        return false;
    }

    static string Reverse(string stringToReverse)
    {
        char[] arr = stringToReverse.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}