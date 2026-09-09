namespace Medicines.DataProcessor.ImportDtos;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Common.EntityRelations.Patient;

public class ImportPartientDto
{
    [Required]
    [JsonProperty("FullName")]
    [MinLength(PatientFullNameMinLength)]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;


    [Required]
    [JsonProperty("AgeGroup")]
    [Range(PatientAgeGroupMinValue, PatientAgeGroupMaxValue)]
    public int AgeGroup { get; set; }


    [Required]
    [JsonProperty("Gender")]
    [Range(PatientGenderMinValue, PatientGenderMaxValue)]
    public int Gender { get; set; }


    [Required]
    [JsonProperty("Medicines")]
    public int[] Medicines { get; set; }
}
