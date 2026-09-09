namespace Trucks.Common;

public static class Validations
{
    //Truck
    public const string TruckRegistrationNumberRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}$";
    public const int VinNumberMaxLength = 17;
    public const int TankCapacityMinRange = 950;
    public const int TankCapacityMaxRange = 1420;
    public const int CargoCapacityMinRange = 5000;
    public const int CargoCapacityMaxRange = 29000;


    //Client
    public const int ClientNameMinLength = 3;
    public const int ClientNameMaxLength = 40;
    public const int NationalityNameMinLength = 2;
    public const int NationalityNameMaxLength = 40;


    //Despatcher
    public const int DespatcherNameMinLength = 2;
    public const int DespatcherNameMaxLength = 40;
}
