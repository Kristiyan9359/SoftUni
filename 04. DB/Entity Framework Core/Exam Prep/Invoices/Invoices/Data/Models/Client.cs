namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations.Client;

public class Client
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ClientNumberVatMaxLength)]
    public string NumberVat { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; }
           = new HashSet<Invoice>();
    public virtual ICollection<Address> Addresses { get; set; }
         = new HashSet<Address>();
    public virtual ICollection<ProductClient> ProductsClients { get; set; }
 = new HashSet<ProductClient>();
}
