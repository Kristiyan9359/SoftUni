namespace BookShelf.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public virtual ICollection<Book> Books { get; set; } 
        = new HashSet<Book>();
}
