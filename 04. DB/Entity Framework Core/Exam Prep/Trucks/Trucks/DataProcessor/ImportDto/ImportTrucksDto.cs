namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.Validations;

[XmlType("Truck")]
public class ImportTrucksDto
{
    [Required]
    [XmlElement("RegistrationNumber")]
    [RegularExpression(TruckRegistrationNumberRegex)]
    public string RegistrationNumber { get; set; } = null!;

    [Required]
    [XmlElement("VinNumber")]
    [MaxLength(VinNumberMaxLength)]
     public string VinNumber { get; set; } = null!;

    [Required]
    [XmlElement("TankCapacity")]
    [Range(TankCapacityMinRange, TankCapacityMaxRange)]
    public int TankCapacity { get; set; }

    [Required]
    [XmlElement("CargoCapacity")]
    [Range(CargoCapacityMinRange, CargoCapacityMaxRange)]
    public int CargoCapacity { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    [Range(0,3)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement("MakeType")]
    [Range(0,4)]
    public int MakeType { get; set; }
}
