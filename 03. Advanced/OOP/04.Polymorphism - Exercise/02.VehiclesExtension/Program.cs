using _01.Vehicles.Models;
using _02.VehiclesExtension.Models;

public class Program
{
    static void Main()
    {
        string[] carInput = Console.ReadLine().Split();
        string[] truckInput = Console.ReadLine().Split();
        string[] busInput = Console.ReadLine().Split();

        Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
        Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));

        Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            try
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                string vehicleType = commandArgs[1];
                double value = double.Parse(commandArgs[2]);
                if (vehicleType == "Car")
                {
                    if (command == "Drive")
                    {
                        Console.WriteLine(car.Drive(value));
                    }
                    else if (command == "Refuel")
                    {
                        car.Refuel(value);
                    }
                }
                else if (vehicleType == "Truck")
                {
                    if (command == "Drive")
                    {
                        Console.WriteLine(truck.Drive(value));
                    }
                    else if (command == "Refuel")
                    {
                        truck.Refuel(value);
                    }
                }
                else if (vehicleType == "Bus")
                {
                    if (command == "Drive")
                    {
                        Console.WriteLine(bus.Drive(value));
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.Drive(value, false));
                    }
                    else if (command == "Refuel")
                    {
                        bus.Refuel(value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
    }
}