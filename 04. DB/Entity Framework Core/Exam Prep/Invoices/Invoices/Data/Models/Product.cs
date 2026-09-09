namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Invoices.Data.Models.Enums.Enums;
using static Common.EntityRelations.Product;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; }
     = new HashSet<ProductClient>();
}
