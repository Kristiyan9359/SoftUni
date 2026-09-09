
internal class Program
{
    static void Main()
    {
        Catalog catalog = new();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] tokens = command.Split("/");

            string type = tokens[0];

            switch (type)
            {
                case "Car":
                    Car car = new()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        HorsePower = int.Parse(tokens[3])

                    };
                    catalog.Cars.Add(car);
                    break;

                case "Truck":
                    Truck truck = new()
                    {
                        Brand = tokens[1],
                        Model = tokens[2],
                        Weight = int.Parse(tokens[3])
                    };
                    catalog.Trucks.Add(truck);
                    break;
            }
        }
        if (catalog.Cars.Count > 0)
        {
            List<Car> orderedCars = catalog.Cars.OrderBy(c => c.Brand).ToList();

            Console.WriteLine("Cars:");

            foreach (var car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
        }
        if (catalog.Trucks.Count > 0)
        {
            List<Truck> orderedTrucks = catalog.Trucks.OrderBy(c => c.Brand).ToList();

            Console.WriteLine("Trucks:");

            foreach (var truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}