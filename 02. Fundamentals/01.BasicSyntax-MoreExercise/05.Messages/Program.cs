class Program
{
    static void Main()
    {
        int messageCount = int.Parse(Console.ReadLine());
        string message = "";

        for (int i = 0; i < messageCount; i++)
        {
            string input = Console.ReadLine();

            if (input == "0")
            {
                message += " ";
                continue;
            }

            int mainDigit = int.Parse(input[0].ToString());
            int digitLength = input.Length;

            int offset = (mainDigit - 2) * 3;

            if (mainDigit == 8 || mainDigit == 9)
            {
                offset += 1;
            }

            int letterIndex = offset + digitLength - 1;

            char letter = (char)(97 + letterIndex);
            message += letter;
        }

        Console.WriteLine(message);
    }
}