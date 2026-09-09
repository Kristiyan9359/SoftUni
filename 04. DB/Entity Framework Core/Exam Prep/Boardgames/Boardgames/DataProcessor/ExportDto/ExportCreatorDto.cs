namespace Boardgames.DataProcessor.ExportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;


[XmlType("Creator")]
public class ExportCreatorDto
{
    [XmlElement("CreatorName")]
    public string Name { get; set; } = null!;

    [XmlAttribute("BoardgamesCount")]
    public int BoardgamesCount { get; set; }

    [XmlArray("Boardgames")]
    public ExportBoardgamesDto[] Boardgames { get; set; } = null!;
}
