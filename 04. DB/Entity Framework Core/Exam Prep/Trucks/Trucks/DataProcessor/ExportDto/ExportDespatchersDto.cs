using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto;

[XmlType("Despatcher")]
public class ExportDespatchersDto
{
    [XmlAttribute("TrucksCount")]
    public int TrucksCount { get; set; }

    [XmlElement("DespatcherName")]
    public string DespatcherName { get; set; } = null!;


    [XmlArray("Trucks")]
    public ExportTrucksDto[] Trucks { get; set; } = null!;
}
