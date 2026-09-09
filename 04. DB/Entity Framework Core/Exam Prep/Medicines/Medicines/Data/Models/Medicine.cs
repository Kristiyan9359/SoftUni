namespace Medicines.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.EntityRelations.Medicine;
using static Medicines.Data.Models.Enums.Enums;
public class Medicine
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    public decimal Price { get; set; }

    [Required]
    public Category Category { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(ProducerNameMaxLength)]
    public string Producer { get; set; } = null!;


    [Required]
    [ForeignKey(nameof(PharmacyId))]
    public int PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; } = null!;

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    = new HashSet<PatientMedicine>();
}
