namespace Medicines.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityRelations.Medicine;

[XmlType("Medicine")]
public class ImportMedicineDto
{
    [Required]
    [XmlAttribute("category")]
    [Range(MedicineCategoryMinValue, MedicineCategoryMaxValue)]
    public int Category { get; set; }


    [Required]
    [XmlElement("Name")]
    [MinLength(MedicineNameMinLength)]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("Price")]
    [Range(MedicinePriceMinValue, MedicinePriceMaxValue)]
    public double Price { get; set; }

    [Required]
    [XmlElement("ProductionDate")]
    public string ProductionDate { get; set; } =null!;

    [Required]
    [XmlElement("ExpiryDate")]
    public string ExpiryDate { get; set; } =null!;

    [Required]
    [XmlElement("Producer")]
    [MinLength(ProducerNameMinLength)]
    [MaxLength(ProducerNameMaxLength)]
    public string Producer {  get; set; } =null!;

}
