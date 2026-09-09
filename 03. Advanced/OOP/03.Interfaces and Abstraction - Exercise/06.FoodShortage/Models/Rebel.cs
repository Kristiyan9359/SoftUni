using _06.FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models;

public class Rebel : INameable, IBuyer
{
    private string name;
    private string age;
    private string group;
    private const int DefaultFood = 5;

    public Rebel(string name, string age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }

    public string Name { get; set; }

    public string Age { get; set; }

    public string Group { get; set; }

    public int Food { get; set; }

    public void AddFood()
    {
        Food += DefaultFood;
    }
}
