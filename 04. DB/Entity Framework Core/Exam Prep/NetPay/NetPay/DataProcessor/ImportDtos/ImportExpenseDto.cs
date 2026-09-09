namespace NetPay.DataProcessor.ImportDtos;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations.Expense;

public class ImportExpenseDto
{
    [Required]
    [JsonProperty("ExpenseName")]
    [MinLength(ExpenseMinLength)]
    [MaxLength(ExpenseMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [Required]
    [JsonProperty("Amount")]
    [Range(typeof(decimal), AmountMinValue, AmountMaxValue)]
    public decimal? Amount { get; set; }

    [Required]
    [JsonProperty("DueDate")]
    public string DueDate { get; set; } = null!;


    [Required]
    [JsonProperty("PaymentStatus")]
    public string PaymentStatus { get; set; } = null!;

    [Required]
    [JsonProperty("HouseholdId")]
    public int? HouseholdId {  get; set; }

    [Required]
    [JsonProperty("ServiceId")]
    public int? ServiceId { get; set; }
}
