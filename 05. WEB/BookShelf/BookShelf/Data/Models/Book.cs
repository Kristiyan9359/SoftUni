namespace BookShelf.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int Year { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}
