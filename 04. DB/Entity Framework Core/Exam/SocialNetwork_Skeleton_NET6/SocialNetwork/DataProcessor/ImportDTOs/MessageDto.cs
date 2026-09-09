using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs;

[XmlType("Message")]
public class MessageDto
{
    [Required]
    [XmlElement("Content")]
    [MaxLength(200)]
    [MinLength(1)]
    public string Content { get; set; } = null!;

    [Required]
    [XmlElement("Status")]
    public string Status { get; set; } = null!;

    [Required]
    [XmlElement("ConversationId")]
    public int ConversationId { get; set; }

    [Required]
    [XmlElement("SenderId")]
    public int SenderId { get; set; }

    [Required]
    [XmlAttribute("SentAt")]
    public string SentAt { get; set;} = null!;
}
