namespace Trucks.DataProcessor;

using Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        var despatchers = new List<Despatcher>();

        var despatchersDto = XmlSerializerWrapper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

        foreach (var despatcherDto in despatchersDto)
        {
            if (!IsValid(despatcherDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            string position = despatcherDto.Position;
            bool isPositionInvalid = string.IsNullOrEmpty(position);

            if (isPositionInvalid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Despatcher despatcher = new Despatcher()
            {
                Name = despatcherDto.Name,
                Position = position
            };

            foreach (var truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Truck truck = new Truck()
                {
                    RegistrationNumber = truckDto.RegistrationNumber,
                    VinNumber = truckDto.VinNumber,
                    TankCapacity = truckDto.TankCapacity,
                    CargoCapacity = truckDto.CargoCapacity,
                    CategoryType = (CategoryType)truckDto.CategoryType,
                    MakeType = (MakeType)truckDto.MakeType
                };
                despatcher.Trucks.Add(truck);
            }
            despatchers.Add(despatcher);
            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
        }
        context.Despatchers.AddRange(despatchers);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }


    public static string ImportClient(TrucksContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        var clients = new List<Client>();

        var clientsDto = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

        foreach (var clientDto in clientsDto)
        {
            if (!IsValid(clientDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }


            Client client = new Client()
            {
                Name = clientDto.Name,
                Nationality = clientDto.Nationality,
                Type = clientDto.Type
            };

            if (clientDto.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            foreach (var truckId in clientDto.Trucks.Distinct())
            {
                Truck truck = context.Trucks.Find(truckId);
                if (truck == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                client.ClientsTrucks.Add(new ClientTruck()
                {
                    Truck = truck
                });
            }
            clients.Add(client);
            sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
        }
        context.Clients.AddRange(clients);
        context.SaveChanges();
        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}