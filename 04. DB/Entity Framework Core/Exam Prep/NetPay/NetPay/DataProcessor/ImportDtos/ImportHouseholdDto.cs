namespace NetPay.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.EntityRelations.Household;

[XmlType("Household")]
public class ImportHouseholdDto
{
    [XmlElement("ContactPerson")]
    [Required]
    [MinLength(ContactPersonMinLength)]
    [MaxLength(ContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;


    [XmlElement("Email")]
    [MinLength(EmailMinLength)]
    [MaxLength(EmailMaxLength)]
    public string? Email { get; set; }

    [XmlAttribute("phone")]
    [Required]
    [MinLength(PhoneNumLength)]
    [RegularExpression(PhoneNumRegex)]
    public string PhoneNumber { get; set; } = null!;
}
