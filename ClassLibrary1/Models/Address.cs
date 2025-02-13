using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Models;

public class Address
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string Street { get; set; } = string.Empty;

    [Required] [MaxLength(50)] public string City { get; set; } = string.Empty;

    [Required] [MaxLength(2)] public string State { get; set; } = string.Empty;

    [Required] [MaxLength(10)] public string ZipCode { get; set; } = string.Empty;

    [ForeignKey("Contact")] public int ContactId { get; set; }

    public Contact Contact { get; set; }
}