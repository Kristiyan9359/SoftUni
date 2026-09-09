using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(50)]
    [Unicode(true)]
    public string Name { get; set; } = null!;


    [Required]
    public decimal Quantity { get; set; }


    [Required]
    public decimal Price { get; set; }

    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}
