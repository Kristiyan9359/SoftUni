namespace NetPay.Data.Models;

using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NetPay.Common.EntityRelations.Expense;

public class Expense
{
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(ExpenseMaxLength)]
    public string ExpenseName { get; set; } = null!;


    [Required]
    public decimal Amount { get; set; }


    [Required]
    public DateTime DueDate { get; set; }


    [Required]
    public PaymentStatus PaymentStatus { get; set; }


    [Required]
    [ForeignKey(nameof(Household))]
    public int HouseholdId { get; set; }
    public Household Household { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }
    public Service Service  { get; set; } = null!;
}
