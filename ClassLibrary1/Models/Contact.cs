using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models;

public class Contact
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(100)] public string FirstName { get; set; } = string.Empty;

    [Required] [MaxLength(100)] public string LastName { get; set; } = string.Empty;


    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}