namespace _03.SpeedRacing;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double TravelledDistance { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption, double travelledDistance)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.TravelledDistance = travelledDistance;
    }

    public void Drive(double distance)
    {
        double neededFuel = distance * FuelConsumption;

        if (FuelAmount >= neededFuel)
        {
            FuelAmount -= neededFuel;
            TravelledDistance += distance;
        }

        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {TravelledDistance}";
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
            double fuelAmount = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double travelledDistance = 0;

            Car car = new Car(model, fuelAmount, fuelConsumption, travelledDistance);
            cars.Add(car);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split();
            string model = tokens[1];
            double distance = double.Parse(tokens[2]);

            Car carToDrive = cars.FirstOrDefault(c => c.Model == model);

            carToDrive.Drive(distance);
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}