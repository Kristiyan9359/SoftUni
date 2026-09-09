using _04.BorderControl.Models;
public class Program
{
    static void Main()
    {
        List<IIdentifiable> sociaty = new();

        while (true)
        {
            string[] tokens = Console.ReadLine().Split();

            if (tokens[0] == "End")
                break;

            if (tokens.Length > 2)
            {
                Citizen citizen = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                sociaty.Add(citizen);
            }
            else
            {
                Robot robot = new(tokens[0], tokens[1]);
                sociaty.Add(robot);
            }
        }

        string lastDigits = Console.ReadLine();

        foreach (var element in sociaty)
        {
            if (element.Id.EndsWith(lastDigits))
            {
                Console.WriteLine(element.Id);
            }
        }
    }
}
