using _06.SpeedRacing;

internal class Program
{
    static void Main()
    {
        int carCount = int.Parse(Console.ReadLine());

        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < carCount; i++)
        {
            string[] data = Console.ReadLine().Split();
            Car currentCar = new Car(data[0], double.Parse(data[1]), double.Parse(data[2]));
            cars[currentCar.Model] = currentCar;
        }


        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] data = command.Split();
            if (data[0] == "Drive")
            {
                string model = data[1];
                double distance = double.Parse(data[2]);

                Car carToDrive = cars[model];
                if (!carToDrive.Drive(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }

        foreach (Car car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}