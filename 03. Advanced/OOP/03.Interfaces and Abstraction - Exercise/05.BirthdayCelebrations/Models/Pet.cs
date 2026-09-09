using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models;

public class Pet : IBirthable
{
    private string name;
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }

    public string Name { get; private set; }

    public string Birthdate { get; private set; }
}
