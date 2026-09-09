namespace Invoices.DataProcessor.ExportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.EntityRelations.Client;

[XmlType("Client")]
public class ExportClientsWithInvoicesDto
{
    [XmlElement("ClientName")]
    public string ClientName { get; set; } = null!;


    [XmlElement("VatNumber")]
    public string NumberVat { get; set; } = null!;


    [XmlAttribute("InvoicesCount")]
    public int InvoicesCount { get; set; }


    [XmlArray("Invoices")]
    public ExportInvoicesDto[] Invoices { get; set; } = null!;

}
