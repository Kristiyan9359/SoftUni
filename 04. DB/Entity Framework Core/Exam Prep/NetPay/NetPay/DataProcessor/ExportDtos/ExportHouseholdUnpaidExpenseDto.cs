namespace NetPay.DataProcessor.ExportDtos;

using System.Xml.Serialization;

[XmlType("Expense")]
public class ExportHouseholdUnpaidExpenseDto
{
    [XmlElement("ExpenseName")]
    public string ExpenseName { get; set; } = null!;

    [XmlElement("Amount")]
    public string Amount { get; set; } = null!;

    [XmlElement("PaymentDate")]
    public string PaymentDate { get; set; } = null!;

    [XmlElement("ServiceName")]
    public string ServiceName { get; set; } = null!;
}