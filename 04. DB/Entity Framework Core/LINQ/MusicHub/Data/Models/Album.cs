using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Album
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(40)]
    public string Name { get; set; } = null!;


    [Required]
    public DateTime ReleaseDate { get; set; }


    public decimal Price
    => Songs.Sum(s => s.Price);


    public int? ProducerId { get; set; }
    public Producer? Producer { get; set; }


    public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
}
