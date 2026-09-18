public class Program
{
    static void Main()
    {

        string input = Console.ReadLine();

        string[] tokens = input.Split();

        string fullName = tokens[0] + " " + tokens[1];

        string address = tokens[2];

        Tuple<string, string> tuple = new Tuple<string, string>(fullName, address);

        Console.WriteLine(tuple);


        

        input = Console.ReadLine();

        tokens = input.Split();

        fullName = tokens[0];
        int amountOfBeer = int.Parse(tokens[1]);

        Tuple<string, int> secondTuple = new Tuple<string, int>(fullName, amountOfBeer);

        Console.WriteLine(secondTuple);




        input = Console.ReadLine();

        tokens = input.Split();

        int integer = int.Parse(tokens[0]);
        double doublee = double.Parse(tokens[1]);

        Tuple<int, double> thirdTuple = new Tuple<int, double>(integer, doublee);

        Console.WriteLine(thirdTuple);
    }
}

public class Tuple<T1, T2>
{
    public T1 Item1 { get; set; }
    public T2 Item2 { get; set; }

    public Tuple(T1 item1, T2 item2)
    {
        Item1 = item1;
        Item2 = item2;
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}