namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityRelations;

[XmlType("Project")]
public class ImportProjectsDto
{
    [XmlElement]
    [Required]
    [MinLength(ProjectNameMinLength)]
    [MaxLength(ProjectNameMaxLength)]
    public string Name { get; set; }

    [XmlElement]
    [Required]
    public string OpenDate { get; set; }


    [XmlElement]
    [Required]
    public string DueDate { get; set; }

    [XmlArray]
    public ImportTasksDto[] Tasks { get; set; }
}
