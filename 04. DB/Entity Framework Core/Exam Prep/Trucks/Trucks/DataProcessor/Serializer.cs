namespace Trucks.DataProcessor;

using Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
    {
        var clients = context
                 .Clients
                 .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                 .ToArray()
                 .Select(c => new
                 {
                     c.Name,
                     Trucks = c.ClientsTrucks
                         .Where(ct => ct.Truck.TankCapacity >= capacity)
                         .ToArray()
                         .OrderBy(ct => ct.Truck.MakeType.ToString())
                         .ThenByDescending(ct => ct.Truck.CargoCapacity)
                         .Select(ct => new
                         {
                             TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                             VinNumber = ct.Truck.VinNumber,
                             TankCapacity = ct.Truck.TankCapacity,
                             CargoCapacity = ct.Truck.CargoCapacity,
                             CategoryType = ct.Truck.CategoryType.ToString(),
                             MakeType = ct.Truck.MakeType.ToString()
                         })
                         .ToArray()
                 })
                 .OrderByDescending(c => c.Trucks.Length)
                 .ThenBy(c => c.Name)
                 .Take(10)
                 .ToArray();

        return JsonConvert.SerializeObject(clients, Formatting.Indented);
    }

    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        var despatchers = context
            .Despatchers
            .Include(d => d.Trucks)
            .Where(d => d.Trucks.Count > 0)
            .AsNoTracking()
            .OrderByDescending(d => d.Trucks.Count)
            .ThenBy(d => d.Name)
            .ToArray()
            .Select(d => new ExportDespatchersDto()
            {
                DespatcherName = d.Name,
                TrucksCount = d.Trucks.Count,
                Trucks = d.Trucks
                   .OrderBy(dt => dt.RegistrationNumber)
                   .Select(dt => new ExportTrucksDto()
                   {
                       RegistrationNumber = dt.RegistrationNumber,
                       Make = dt.MakeType.ToString()
                   })
                   .ToArray()

            })
            .ToArray();

        var result = XmlSerializerWrapper.Serialize(despatchers, "Despatchers");
        return result;
    }
}
