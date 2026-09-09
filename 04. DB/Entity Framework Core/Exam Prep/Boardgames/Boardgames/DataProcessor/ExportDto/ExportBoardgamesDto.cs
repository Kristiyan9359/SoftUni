namespace Boardgames.DataProcessor.ExportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.ValidationConstants;

[XmlType("Boardgame")]
public class ExportBoardgamesDto
{
    [XmlElement("BoardgameName")]
    [MinLength(GameNameMinLength)]
    [MaxLength(GameNameMaxLength)]
    public string Name { get; set; } = null!;


    [XmlElement("BoardgameYearPublished")]
    [Range(YearPublishedMinRange, YearPublishedMaxRange)]
    public int YearPublished { get; set; }
}

