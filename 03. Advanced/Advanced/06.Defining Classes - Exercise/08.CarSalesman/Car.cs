namespace _08.CarSalesman;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int? Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = null;
        Color = "n/a";
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        Weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        Weight = weight;
        Color = color;
    }

    public override string ToString()
    {
        return $"{Model}:\n" +
               $"{Engine}\n" +
               $"  Weight: {(Weight.HasValue ? Weight.ToString() : "n/a")}\n" +
               $"  Color: {Color}";
    }
}