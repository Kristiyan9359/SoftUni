using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

[XmlType("User")]
public class UserExportDto
{
    [XmlAttribute("Friendships")]
    public int Friendships { get; set; }

    [XmlElement("Username")]
    public string Username { get; set; } = null!;

    [XmlArray("Posts")]
    [XmlArrayItem("Post")]
    public List<PostExportDto> Posts { get; set; } = new List<PostExportDto>();
}
