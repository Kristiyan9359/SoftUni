namespace Footballers.Data.Models;

using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.Validations;

public class Footballer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public DateTime ContractStartDate { get; set; }

    [Required]
    public DateTime ContractEndDate { get; set; }

    [Required]
    public PositionType PositionType { get; set; }

    [Required]
    public BestSkillType BestSkillType { get; set; }

    [Required]
    [ForeignKey(nameof(CoachId))]
    public int CoachId { get; set; }
    public Coach Coach { get; set; } = null!;

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    = new List<TeamFootballer>();
}
