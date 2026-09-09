using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext dbContext = new CarDealerContext();
        //dbContext.Database.EnsureDeleted();
        //dbContext.Database.EnsureCreated();

        string jsonFileDirPath = Path
     .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
        string jsonFileName = "sales.json";
        string jsonFileText = File
            .ReadAllText(jsonFileDirPath + jsonFileName);

        string result = ImportSales(dbContext, jsonFileText);
        Console.WriteLine(result);
    }


    // IMPORT METHODS

    // Problem 9

    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var suppliersToImport = new List<Supplier>();

        var suppliersDto = JsonConvert.DeserializeObject<SuppliersImportDto[]>(inputJson);

        if (suppliersDto != null)
        {
            foreach (var supplierDto in suppliersDto)
            {
                bool isImporterValidVal = bool
                     .TryParse(supplierDto.IsImporter, out bool isImporter);

                if (!isImporterValidVal)
                {
                    continue;
                }

                Supplier newSupplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = isImporter
                };
                suppliersToImport.Add(newSupplier);
            }
            context.AddRange(suppliersToImport);
            context.SaveChanges();
        }
        return $"Successfully imported {suppliersToImport.Count}.";
    }


    // Problem 10


    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var existingSuppliers = context.Suppliers
            .AsNoTracking()
            .Select(s => s.Id)
            .ToList();

        var partsToImport = new List<Part>();

        var partsDto = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);

        if (partsDto != null)
        {
            foreach (var partDto in partsDto)
            {
                var isSupplierIdValid = int
                    .TryParse(partDto.SuplierId, out int supplierId);

                if (!isSupplierIdValid ||
                    !existingSuppliers.Contains(supplierId))
                {
                    continue;
                }

                Part newPart = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = supplierId
                };
                partsToImport.Add(newPart);
            }
            context.AddRange(partsToImport);
            context.SaveChanges();
        }
        return $"Successfully imported {partsToImport.Count}.";
    }


    // Problem 11


    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var carsToImport = new List<Car>();

        var partsCarsToImport = new List<PartCar>();

        var carsDto = JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson);


        if (carsDto != null)
        {
            foreach (var carDto in carsDto)
            {
                Car newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                carsToImport.Add(newCar);

                foreach (int partId in carDto.PartsId.Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    PartCar newPartCar = new PartCar()
                    {
                        PartId = partId,
                        Car = newCar
                    };
                    partsCarsToImport.Add(newPartCar);
                }
            }
            context.PartsCars.AddRange(partsCarsToImport);
            context.SaveChanges();
        }
        return $"Successfully imported {carsToImport.Count}.";
    }



    // Problem 12

    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var customersToImport = new List<Customer>();

        var customersDto = JsonConvert.DeserializeObject<ImportCustomersDto[]>(inputJson);

        if (customersDto != null)
        {
            foreach (var customerDto in customersDto)
            {

                var isBirthdayValid = DateTime
                    .TryParseExact(customerDto.BirthDay, "yyyy-MM-dd'T'HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDay);
                var isYoungDriverValid = bool
                    .TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                if (!isBirthdayValid ||
                    !isYoungDriverValid)
                {
                    continue;
                }

                var newCustomer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = birthDay,
                    IsYoungDriver = isYoungDriver,
                };
                customersToImport.Add(newCustomer);
            }

            context.AddRange(customersToImport);
            context.SaveChanges();

        }

        return $"Successfully imported {customersToImport.Count}.";
    }



    // Problem 13


    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var salesToImport = new List<Sale>();

        var salesDto = JsonConvert.DeserializeObject<ImportSalesDto[]>(inputJson);

        if (salesDto != null)
        {
            foreach (var saleDto in salesDto)
            {
                var isCarIdExist = context
                    .Cars
                    .Any(c => c.Id == saleDto.CarId);

                if (!isCarIdExist)
                    continue;

                var isCustomerIdExist = context
                    .Customers
                    .Any(cu => cu.Id == saleDto.CustomerId);

                if (!isCustomerIdExist)
                    continue;

                Sale newSale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };
                salesToImport.Add(newSale);
            }

            context.AddRange(salesToImport);
            context.SaveChanges();
        }


        return $"Successfully imported {salesToImport.Count}.";
    }



    // EXPORT METHODS


    // Problem 14

    public static string GetOrderedCustomers(CarDealerContext context)
    {
        throw new NotImplementedException();
    }



    // Problem 15

    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        throw new NotImplementedException();
    }



    // Problem 16

    public static string GetLocalSuppliers(CarDealerContext context)
    {
        throw new NotImplementedException();
    }


    // Problem 17

    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        throw new NotImplementedException();
    }


    // Problem 18

    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        throw new NotImplementedException();
    }


    // Problem 19


    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        throw new NotImplementedException();
    }
}