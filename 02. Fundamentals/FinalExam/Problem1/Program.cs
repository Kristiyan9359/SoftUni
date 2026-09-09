internal class Program
{
    static void Main()
    {
        string decrypting = Console.ReadLine();


        string command;
        while ((command = Console.ReadLine()) != "Finish")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string action = tokens[0];

            switch (action)
            {
                case "Replace":
                    decrypting = decrypting.Replace(tokens[1], tokens[2]);
                    Console.WriteLine(decrypting);
                    break;

                case "Cut":
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex < decrypting.Length && endIndex >= 0 && endIndex < decrypting.Length)
                    {
                        decrypting = decrypting.Remove(startIndex, endIndex - startIndex + 1);

                        Console.WriteLine(decrypting);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    break;

                case "Make":
                    if (tokens[1] == "Upper")
                    {
                        decrypting = decrypting.ToUpper();
                    }
                    else
                    {
                        decrypting = decrypting.ToLower();
                    }
                    Console.WriteLine(decrypting);
                    break;

                case "Check":
                    if (decrypting.Contains(tokens[1]))
                    {
                        Console.WriteLine($"Message contains {tokens[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {tokens[1]}");
                    }
                    break;

                case "Sum":
                    startIndex = int.Parse(tokens[1]);
                    endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex < decrypting.Length && endIndex >= 0 && endIndex < decrypting.Length)
                    {
                        string substring = decrypting.Substring(startIndex, endIndex - startIndex + 1);
                        int sum = 0;

                        foreach (char c in substring)
                        {
                            sum += c;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                    break;
            }
        }
    }
}