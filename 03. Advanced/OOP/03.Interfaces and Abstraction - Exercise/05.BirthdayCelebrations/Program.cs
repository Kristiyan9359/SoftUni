using _04.BorderControl.Models;
using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interfaces;

public class Program
{
    static void Main()
    {
        List<IBirthable> birthdates = new();

        while (true)
        {
            string[] tokens = Console.ReadLine().Split();

            if (tokens[0] == "End")
                break;

            if (tokens[0] == "Citizen")
            {
                Citizen citizen = new(tokens[1], tokens[2], tokens[3], tokens[4]);
                birthdates.Add(citizen);
            }
            else if (tokens[0] == "Pet")
            {
                Pet pet = new(tokens[1], tokens[2]);
                birthdates.Add(pet);
            }
            else continue;
        }

        string birthYear = Console.ReadLine();

        foreach (var element in birthdates)
        {
            if (element.Birthdate.EndsWith(birthYear))
                Console.WriteLine(element.Birthdate);
        }
    }
}