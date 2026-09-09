using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ImportDTOs;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var messages = new List<Message>();

            var messagesDto = XmlSerializerWrapper.Deserialize<List<MessageDto>>(xmlString, "Messages");

            foreach (var messageDto in messagesDto)
            {
                if (!IsValid(messageDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(messageDto.SentAt, "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime sentAt))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse<Status>(messageDto.Status, out Status status))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!dbContext.Conversations.Any(c => c.Id == messageDto.ConversationId) ||
                    !dbContext.Users.Any(u => u.Id == messageDto.SenderId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool duplicate = dbContext.Messages.Any(m =>
                m.Content == messageDto.Content &&
                m.SentAt == sentAt &&
                m.Status == status &&
                m.SenderId == messageDto.SenderId &&
                m.ConversationId == messageDto.ConversationId)
                || messages.Any(m =>
                m.Content == messageDto.Content &&
                m.SentAt == sentAt &&
                m.Status == status &&
                m.SenderId == messageDto.SenderId &&
                m.ConversationId == messageDto.ConversationId);

                if (duplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                var message = new Message
                {
                    Content = messageDto.Content,
                    SentAt = sentAt,
                    Status = status,
                    ConversationId = messageDto.ConversationId,
                    SenderId = messageDto.SenderId
                };

                messages.Add(message);
                sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity,
                    message.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"), message.Status));
            }

            dbContext.Messages.AddRange(messages);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var posts = new List<Post>();

            var postsDto = JsonConvert.DeserializeObject<List<PostDto>>(jsonString);

            foreach (var postDto in postsDto)
            {
                if (!IsValid(postDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(postDto.CreatedAt, "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdAt))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = dbContext.Users.FirstOrDefault(u => u.Id == postDto.CreatorId);
                if (creator == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool duplicate = dbContext.Posts.Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAt &&
                        p.CreatorId == postDto.CreatorId)
                        || posts.Any(p =>
                        p.Content == postDto.Content &&
                        p.CreatedAt == createdAt &&
                        p.CreatorId == postDto.CreatorId);

                if (duplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                var post = new Post
                {
                    Content = postDto.Content,
                    CreatedAt = createdAt,
                    CreatorId = postDto.CreatorId,
                    Creator = creator
                };

                posts.Add(post);
                sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username, createdAt.ToString("yyyy-MM-ddTHH:mm:ss")));
            }

            dbContext.Posts.AddRange(posts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
