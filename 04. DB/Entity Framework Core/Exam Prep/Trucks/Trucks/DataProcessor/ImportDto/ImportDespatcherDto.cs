namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models;
using static Common.Validations;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [XmlElement("Name")]
    [MinLength(DespatcherNameMinLength)]
    [MaxLength(DespatcherNameMaxLength)]
    public string Name { get; set; } = null!;

    [XmlElement("Position")]
    public string Position { get; set; } = null!;

    [XmlArray("Trucks")]
    public ImportTrucksDto[] Trucks { get; set; } = null!;
}
