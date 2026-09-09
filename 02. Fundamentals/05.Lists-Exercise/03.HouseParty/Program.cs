internal class Program
{
    static void Main()
    {
        int commands = int.Parse(Console.ReadLine());

        List<string> guests = new List<string>();

        for (int i = 0; i < commands; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string name = tokens[0];

            if (tokens[2] == "going!")
            {
                if (guests.Contains(name))
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }
            else if (tokens[2] == "not")
            {
                if (guests.Contains(name))
                {
                    guests.Remove(name);
                }
                else
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
            }
        }

        Console.WriteLine(string.Join("\n", guests));
    }
}