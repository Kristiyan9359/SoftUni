namespace _06.SpeedRacing;

public class Car
{
    List<Car> cars;
    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double FuelConsumptionPerKm { get; set; }

    public double TravelledDistance { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public bool Drive(double kilometers)
    {
        double necessarryFuel = this.FuelConsumptionPerKm * kilometers;
        if (necessarryFuel > this.FuelAmount) { return false; }

        this.FuelAmount -= necessarryFuel;
        this.TravelledDistance += kilometers;
        return true;
    }

}
