internal class Program
{
    static void Main()
    {

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string reversed = string.Empty;

            for (int i = command.Length - 1; i >= 0; i--)
            {
                reversed += command[i];
            }

            Console.WriteLine($"{command} = {reversed}");
        }
    }
}