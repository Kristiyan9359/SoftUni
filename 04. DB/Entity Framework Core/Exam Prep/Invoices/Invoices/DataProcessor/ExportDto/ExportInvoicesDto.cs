namespace Invoices.DataProcessor.ExportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.EntityRelations.Invoice;
using Invoices.Data.Models.Enums;

[XmlType("Invoice")]
public class ExportInvoicesDto
{
    [XmlElement("InvoiceNumber")]
    [Range(NumberMinRange, NumberMaxRange)]
    public int InvoiceNumber { get; set; }


    [XmlElement("InvoiceAmount")]
    public decimal InvoiceAmount { get; set; }


    [XmlElement("DueDate")]
    public string DueDate { get; set; }

    [XmlElement("Currency")]
    public string Currency { get; set; } = null!;
}
