public class UserConversation
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int ConversationId { get; set; }
    public Conversation Conversation { get; set; }
}
