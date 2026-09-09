namespace NetPay.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations.Supplier;


public class Supplier
{
    [Key]
    public int Id { get; set; }


    [Required]
    [MaxLength(SupplierMaxLength)]
    public string SupplierName { get; set; } = null!;


    public ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();
}
