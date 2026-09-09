public class Warrior : BaseHero
{
    public Warrior(string name) : base(name)
    {
        Power = 100;
    }

    public override string CastAbility()
    {
        return $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
