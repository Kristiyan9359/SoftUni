using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

[XmlType("Post")]
public class PostExportDto
{
    [XmlElement("Content")]
    public string Content { get; set; } = null!;

    [XmlElement("CreatedAt")]
    public DateTime CreatedAt { get; set; }
}