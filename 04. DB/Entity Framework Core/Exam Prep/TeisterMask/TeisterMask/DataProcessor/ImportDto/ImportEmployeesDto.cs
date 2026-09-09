namespace TeisterMask.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations;
public class ImportEmployeesDto
{
    [Required]
    [MinLength(EmployeeUsernameMinLength)]
    [MaxLength(EmployeeUsernameMaxLength)]
    [RegularExpression(EmployeeUsernameRegex)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(EmployeePhoneRegex)]
    public string Phone { get; set; }

    public int[] Tasks { get; set; }
}
