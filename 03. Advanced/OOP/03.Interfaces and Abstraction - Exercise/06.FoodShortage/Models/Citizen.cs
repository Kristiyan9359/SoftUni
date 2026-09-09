using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models;
public class Citizen : INameable, IBuyer
{
    private string name;
    private string age;
    private string id;
    private string birthdate;
    private const int DefaultFood = 10;
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
    public int Food { get; set; }

    public void AddFood()
    {
        Food += DefaultFood;
    }
}
