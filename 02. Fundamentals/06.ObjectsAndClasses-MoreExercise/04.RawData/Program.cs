namespace _04.RawData;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }

    public Car(string model, Engine engine, Cargo cargo)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
    }

    public bool IsFragile() => Cargo.Type == "fragile" && Cargo.Weight < 1000;
    public bool IsFlammable() => Cargo.Type == "flamable" && Engine.Power > 250;
}


public class Engine
{
    public int Speed { get; set; }
    public int Power { get; set; }
    public Engine(int speed, int power)
    {
        Speed = speed;
        Power = power;
    }
}
public class Cargo
{
    public int Weight { get; set; }
    public string Type { get; set; }
    public Cargo(int weight, string type)
    {
        Weight = weight;
        Type = type;
    }
}

public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            int speed = int.Parse(data[1]);
            int power = int.Parse(data[2]);
            int weight = int.Parse(data[3]);
            string type = data[4];

            Engine engine = new Engine(speed, power);
            Cargo cargo = new Cargo(weight, type);
            Car car = new Car(model, engine, cargo);
            cars.Add(car);
        }
        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars.Where(c => c.IsFragile()))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in cars.Where(c => c.IsFlammable()))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
