namespace TeisterMask.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.EntityRelations;
using static Enums.Enums;
public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TaskNameMaxLength)]
    public string Name { get; set; } =null!;

    [Required]
    public DateTime OpenDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public ExecutionType ExecutionType { get; set; }

    [Required]
    public LabelType LabelType { get; set; }

    [Required]
    [ForeignKey(nameof(ProjectId))]
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;

    public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }
        = new HashSet<EmployeeTask>();
}
