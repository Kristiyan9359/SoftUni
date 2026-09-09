namespace Boardgames.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using static Boardgames.Data.Models.Enums.Enums;
using static System.Net.Mime.MediaTypeNames;
using static Boardgames.Common.ValidationConstants;

public class Boardgame
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GameNameMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    [Range(GameRatingMinRange, GameRatingMaxRange)]
    public double Rating { get; set; }


    [Required]
    [Range(YearPublishedMinRange, YearPublishedMaxRange)]
    public int YearPublished { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public string Mechanics { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(CreatorId))]
    public int CreatorId { get; set; }
    public Creator Creator { get; set; } = null!;


    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    = new HashSet<BoardgameSeller>();
}
