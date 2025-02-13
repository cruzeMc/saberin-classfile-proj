using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.DTOs;

public class ContactDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [MaxLength(100, ErrorMessage = "First Name cannot exceed 100 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    [MaxLength(100, ErrorMessage = "Last Name cannot exceed 100 characters.")]
    public string LastName { get; set; } = string.Empty;

    public List<AddressDTO> Addresses { get; set; } = new();
}