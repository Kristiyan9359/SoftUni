using _05.BirthdayCelebrations.Models.Interfaces;

namespace _04.BorderControl.Models;

public class Citizen : IBirthable
{
    private string name;
    private string age;
    private string id;
    private string birthdate;
    public Citizen(string name, string age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }
    public string Name { get; set; }
    public string Age { get; set; }
    public string Id { get; set; }
    public string Birthdate { get; set; }
}
