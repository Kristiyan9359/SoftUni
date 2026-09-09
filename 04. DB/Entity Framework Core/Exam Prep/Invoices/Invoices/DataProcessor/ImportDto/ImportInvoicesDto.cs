namespace Invoices.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Invoices.Data.Common.EntityRelations.Invoice;
using static Invoices.Data.Models.Enums.Enums;

public class ImportInvoicesDto
{
    [JsonProperty("Number")]
    [Range(NumberMinRange, NumberMaxRange)]
    public int Number { get; set; }

    [JsonProperty("IssueDate")]
    public DateTime IssueDate { get; set; }

    [JsonProperty("DueDate")]
    public DateTime DueDate { get; set; }

    [JsonProperty("Amount")]
    public decimal Amount { get; set; }

    [JsonProperty("CurrencyType")]
    [Range(0,2)]
    public CurrencyType CurrencyType { get; set; }

    [JsonProperty("ClientId")]
    public int ClientId { get; set; }
}
