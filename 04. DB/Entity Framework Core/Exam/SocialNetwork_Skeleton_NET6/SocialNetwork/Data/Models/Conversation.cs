using SocialNetwork.Data.Models;
using System.ComponentModel.DataAnnotations;

public class Conversation
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Title { get; set; }

    [Required]
    public DateTime StartedAt { get; set; }

    public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    public ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();
}
