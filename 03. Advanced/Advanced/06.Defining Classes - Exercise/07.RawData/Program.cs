namespace _07.RawData;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            int engineSpeed = int.Parse(data[1]);
            int enginePower = int.Parse(data[2]);
            int cargoWeight = int.Parse(data[3]);
            string cargoType = data[4];

            List<Tire> tires = new List<Tire>();

            for (int j = 5; j < data.Length; j += 2)
            {
                double pressure = double.Parse(data[j]);
                int age = int.Parse(data[j + 1]);

                Tire tire = new Tire(pressure, age);
                tires.Add(tire);
            }

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Car car = new Car(model, engine, cargo, tires);
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
        else if (command == "flammable")
        {
            foreach (var car in cars.Where(c => c.IsFlammable()))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}