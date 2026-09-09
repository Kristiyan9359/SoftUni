using System.ComponentModel.DataAnnotations;

public class Post
{
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    [MinLength(5)]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public int CreatorId { get; set; }
    public User Creator { get; set; }
}
