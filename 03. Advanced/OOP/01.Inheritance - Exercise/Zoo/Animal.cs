namespace Zoo;

public class Animal
{
    public string name;

    public Animal(string name)
    {
        Name = name;
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
}
