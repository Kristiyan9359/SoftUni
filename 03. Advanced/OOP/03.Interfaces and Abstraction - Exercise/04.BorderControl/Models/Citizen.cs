namespace _04.BorderControl.Models;

public class Citizen : IIdentifiable
{
    private string name;
    private int age;
    private string id;

    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
}
