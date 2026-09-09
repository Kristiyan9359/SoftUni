namespace _01.Vehicles.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }

    double FuelConsumption { get; }

    string Drive(double distance);

    void Refuel(double amount);
}
