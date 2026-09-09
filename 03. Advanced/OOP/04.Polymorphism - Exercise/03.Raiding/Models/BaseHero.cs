public abstract class BaseHero
{
    public string Name { get; set; }
    public int Power { get; protected set; }

    protected BaseHero(string name)
    {
        Name = name;
    }

    public abstract string CastAbility();
}
