namespace TeisterMask.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(EmployeeUsernameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Phone { get; set; } = null!;

   public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; } 
        = new HashSet<EmployeeTask>();
}
