namespace Trucks.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Validations;

public class Despatcher
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DespatcherNameMaxLength)]
    public string Name { get; set; }=null!;


    [Required]
    public string Position { get; set; } = null!;

    public virtual ICollection<Truck> Trucks { get; set; }
    = new HashSet<Truck>();
}
