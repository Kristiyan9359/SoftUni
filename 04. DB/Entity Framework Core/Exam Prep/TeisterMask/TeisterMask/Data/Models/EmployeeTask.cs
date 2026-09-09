using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.Data.Models;

public class EmployeeTask
{
    [ForeignKey(nameof(EmployeeId))]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;


    [ForeignKey(nameof(TaskId))]
    public int TaskId { get; set; }
    public Task Task { get; set; } = null!;
}
