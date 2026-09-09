using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using System.Globalization;
using System.Text.Json;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            var usersData = dbContext.Users
            .OrderBy(u => u.Username)
            .Select(u => new UserExportDto
            {
                Username = u.Username,
                Friendships = dbContext.Friendships.Count(f => f.UserOneId == u.Id
                || f.UserTwoId == u.Id),
                Posts = u.Posts
                   .OrderBy(p => p.Id)
                   .Select(p => new PostExportDto
                   {
                       Content = p.Content,
                       CreatedAt = p.CreatedAt
                   })
                   .ToList()
            })
           .ToList();

            return XmlSerializerWrapper.Serialize(usersData, "Users");
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversations = dbContext.Conversations
                .OrderBy(c => c.StartedAt)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new
                        {
                            m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                            m.Status,
                            SenderUsername = m.Sender.Username
                        })
                        .ToList()
                })
                .ToList();


            return JsonConvert.SerializeObject(conversations, Formatting.Indented);
        }
    }
}
