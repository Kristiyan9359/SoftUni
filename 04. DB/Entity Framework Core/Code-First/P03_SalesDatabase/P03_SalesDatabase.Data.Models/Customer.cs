using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(100)]
    [Unicode(true)]
    public string Name { get; set; } = null!;


    [Required]
    [MaxLength(80)]
    [Unicode(false)]
    public string Email { get; set; } = null!;


    [Required]
    public string CreditCardNumber { get; set; } = null!;

    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}
