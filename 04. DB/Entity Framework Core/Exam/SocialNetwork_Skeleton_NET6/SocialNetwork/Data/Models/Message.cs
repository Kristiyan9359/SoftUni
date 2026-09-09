using SocialNetwork.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class Message
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    [MinLength(1)]
    public string Content { get; set; }

    [Required]
    public DateTime SentAt { get; set; }

    [Required]
    public Status Status { get; set; }

    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }

    public int SenderId { get; set; }
    public User Sender { get; set; }
}
