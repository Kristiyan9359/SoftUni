namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;

    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public string Birthdate
    {
        get { return birthdate; }
        private set { birthdate = value; }
    }
}
