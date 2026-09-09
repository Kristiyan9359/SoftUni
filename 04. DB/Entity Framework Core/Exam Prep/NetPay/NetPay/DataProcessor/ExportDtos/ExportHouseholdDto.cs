namespace NetPay.DataProcessor.ExportDtos;

using System.Xml.Serialization;

[XmlType("Household")]
public class ExportHouseholdDto
{
    [XmlElement("ContactPerson")]
    public string ContactPerson { get; set; } = null!;

    [XmlElement("Email")]
    public string? Email { get; set; }

    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray("Expenses")]
    public ExportHouseholdUnpaidExpenseDto[] Expenses { get; set; } = null!;
}