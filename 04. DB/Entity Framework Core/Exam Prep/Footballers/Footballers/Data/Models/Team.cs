namespace Footballers.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.Validations;

public class Team
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public int Trophies { get; set; }

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    = new List<TeamFootballer>();
}
