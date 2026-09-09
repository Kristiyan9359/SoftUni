namespace Raiding;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var heroes = new List<BaseHero>();
        var factory = new HeroFactory();

        while (heroes.Count < n)
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            var hero = factory.CreateHero(type, name);

            if (hero == null)
            {
                Console.WriteLine("Invalid hero!");
                continue;
            }

            heroes.Add(hero);
        }

        int bossPower = int.Parse(Console.ReadLine());
        int totalPower = 0;

        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());
            totalPower += hero.Power;
        }

        Console.WriteLine(totalPower >= bossPower ? "Victory!" : "Defeat...");
    }
}
