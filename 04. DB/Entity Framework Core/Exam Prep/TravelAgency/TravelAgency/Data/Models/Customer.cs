namespace TravelAgency.Data.Models;

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.EntityRelations;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CustomerFullNameMaxLength)]
    public string FullName { get; set; } = null!;


    [Required]
    [MaxLength(CustomerEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    ICollection <Booking> Bookings { get; set; } = new HashSet<Booking>();
}
