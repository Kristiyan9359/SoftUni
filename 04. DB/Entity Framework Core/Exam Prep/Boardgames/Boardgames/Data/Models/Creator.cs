namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.ValidationConstants;

public class Creator
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Boardgame> Boardgames { get; set; }
      = new HashSet<Boardgame>();
}
