namespace Medicines.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityRelations.Pharmacy;

[XmlType("Pharmacy")]
public class ImportPharmacyDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(PharmacyNameMinLength)]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("PhoneNumber")]
    [RegularExpression(PharmacyPhoneNumberRegex)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [XmlAttribute("non-stop")]
    [RegularExpression(PharmacyBooleanRegex)]
    public string IsNonStop { get; set; } = null!;

    [Required]
    [XmlArray("Medicines")]
    [XmlArrayItem("Medicine")]
    public ImportMedicineDto[] Medicines { get; set; }= null!;
}
