public class Program
{
    static void Main()
    {
        string town = "";

        string input = Console.ReadLine();

        string[] tokens = input.Split();

        string fullName = tokens[0] + " " + tokens[1];

        string address = tokens[2];

        if (tokens.Length == 5)
        {
            town = tokens[3] + " " + tokens[4];
        }
        else
        {
            town = tokens[3];
        }

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);

        Console.WriteLine(firstThreeuple);




        input = Console.ReadLine();

        tokens = input.Split();

        string name = tokens[0];
        int amountOfBeer = int.Parse(tokens[1]);
        bool isDrunk = false;

        if (tokens[2] == "drunk")
        {
            isDrunk = true;
        }

        Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, amountOfBeer, isDrunk);

        Console.WriteLine(secondThreeuple);




        input = Console.ReadLine();

        tokens = input.Split();

        name = tokens[0];
        double balance = double.Parse(tokens[1]);
        string bankName = tokens[2];

        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(name, balance, bankName);

        Console.WriteLine(thirdThreeuple);
    }

    public class Threeuple<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }

        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}