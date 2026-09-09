internal class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string fileName = string.Empty;

        string extension = string.Empty;

        int lastSeparator = input.LastIndexOf('\\');

        int lastExtension = input.LastIndexOf('.');

        if (lastSeparator != -1 && lastExtension != 1 && lastExtension > lastSeparator)
        {
            fileName = input.Substring(lastSeparator + 1, lastExtension - lastSeparator - 1);
            extension = input.Substring(lastExtension + 1);
        }

        Console.WriteLine($"File name: {fileName}");
        Console.WriteLine($"File extension: {extension}");

    }
}