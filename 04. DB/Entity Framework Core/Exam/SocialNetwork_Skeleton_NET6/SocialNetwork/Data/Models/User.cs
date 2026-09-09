using SocialNetwork.Data.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    [MinLength(4)]
    public string Username { get; set; }

    [Required]
    [MaxLength(60)]
    [MinLength(8)]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
    public ICollection<UserConversation> UsersConversations { get; set; } = new HashSet<UserConversation>();

    public ICollection<Friendship> FriendsOne { get; set; } = new HashSet<Friendship>();
    public ICollection<Friendship> FriendsTwo { get; set; } = new HashSet<Friendship>();
}
