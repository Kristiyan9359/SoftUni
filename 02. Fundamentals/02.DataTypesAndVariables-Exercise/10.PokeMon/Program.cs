class Program
{
    static void Main()
    {

        int power = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        int exhaustion = int.Parse(Console.ReadLine());

        double halfPower = power / 2.0;
        int pokedTargets = 0;

        while (power >= distance)
        {
            power -= distance;
            pokedTargets++;
            if (power == halfPower && exhaustion != 0)
            {
                power /= exhaustion;
            }
        }

        Console.WriteLine(power);
        Console.WriteLine(pokedTargets);
    }
}