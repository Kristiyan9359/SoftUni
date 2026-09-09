namespace _07.RawData;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public List<Tire> Tires { get; set; }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires = tires;
    }
    public bool IsFragile()
    {
        return this.Cargo.Type == "fragile" && this.Tires.Any(t => t.Pressure < 1);
    }

    public bool IsFlammable()
    {
        return this.Cargo.Type == "flammable" && this.Engine.Power > 250;
    }
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

public class Tire
{
    public double Pressure { get; set; }
    public int Age { get; set; }

    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}