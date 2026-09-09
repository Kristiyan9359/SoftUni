using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static MusicHub.Data.Models.Enums.Genre;

namespace MusicHub.Data.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }
        public Album? Album { get; set; }

        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; } = new HashSet<SongPerformer>();
    }
}
