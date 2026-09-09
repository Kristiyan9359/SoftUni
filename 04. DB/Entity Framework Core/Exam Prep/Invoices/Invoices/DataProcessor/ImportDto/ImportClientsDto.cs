namespace Invoices.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.EntityRelations.Client;


[XmlType("Client")]
public class ImportClientsDto
{
    [XmlElement("Name")]
    [MinLength(ClientNameMinLength)]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;


    [XmlElement("NumberVat")]
    [MinLength(ClientNumberVatMinLength)]
    [MaxLength(ClientNumberVatMaxLength)]
    public string NumberVat { get; set; } = null!;


    [XmlArray("Addresses")]
    public ImportAddressesDto[] Addresses { get; set; } = null!;
}
