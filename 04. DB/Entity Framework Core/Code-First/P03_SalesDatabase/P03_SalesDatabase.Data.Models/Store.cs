using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models;

public class Store
{
    [Key]
    public int StoreId { get; set; }


    [Required]
    [MaxLength(80)]
    [Unicode(true)]
    public string Name { get; set; } = null!;


    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}
