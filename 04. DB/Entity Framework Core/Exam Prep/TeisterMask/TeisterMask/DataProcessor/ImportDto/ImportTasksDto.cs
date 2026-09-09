namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityRelations;

[XmlType("Task")]
public class ImportTasksDto
{
    [XmlElement]
    [Required]
    [MinLength(TaskNameMinLength)]
    [MaxLength(TaskNameMaxLength)]
    public string Name { get; set; } = null!;


    [XmlElement]
    [Required]
    public string OpenDate { get; set; } = null!;


    [XmlElement]
    [Required]
    public string DueDate { get; set; } = null!;


    [XmlElement]
    [Range(0, 3)]
    public int ExecutionType { get; set; }


    [XmlElement]
    [Range(0, 4)]
    public int LabelType { get; set; }
}
