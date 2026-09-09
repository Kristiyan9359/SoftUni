using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Footballers.Data.Models;

public class TeamFootballer
{
    [Required]
    [ForeignKey(nameof(TeamId))]
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(FootballerId))]
    public int FootballerId { get; set; }

    public Footballer Footballer { get; set; } = null!;
}
