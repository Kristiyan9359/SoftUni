using _08.CarSalesman;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = parts[0];
            int power = int.Parse(parts[1]);

            Engine engine;

            if (parts.Length == 2)
            {
                engine = new Engine(model, power);
            }
            else if (parts.Length == 3)
            {
                if (int.TryParse(parts[2], out int displacement))
                    engine = new Engine(model, power, displacement);
                else
                    engine = new Engine(model, power, parts[2]);
            }
            else
            {
                int displacement = int.Parse(parts[2]);
                string efficiency = parts[3];
                engine = new Engine(model, power, displacement, efficiency);
            }

            engines.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < m; i++)
        {
            string[] parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string carModel = parts[0];
            string engineModel = parts[1];
            Engine engine = engines.First(e => e.Model == engineModel);

            Car car;

            if (parts.Length == 2)
            {
                car = new Car(carModel, engine);
            }
            else if (parts.Length == 3)
            {
                if (int.TryParse(parts[2], out int weight))
                    car = new Car(carModel, engine, weight);
                else
                    car = new Car(carModel, engine, parts[2]);
            }
            else
            {
                int weight = int.Parse(parts[2]);
                string color = parts[3];
                car = new Car(carModel, engine, weight, color);
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}