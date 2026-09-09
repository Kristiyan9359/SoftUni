namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations.Patient;
using static Medicines.Data.Models.Enums.Enums;
public class Patient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public AgeGroup AgeGroup { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    = new HashSet<PatientMedicine>();
}
