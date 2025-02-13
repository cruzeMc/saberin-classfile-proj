using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.DTOs;

public class AddressDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Street is required.")]
    [MaxLength(100, ErrorMessage = "Street cannot exceed 100 characters.")]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required.")]
    [MaxLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "State is required.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "State must be exactly 2 characters.")]
    public string State { get; set; } = string.Empty;

    [Required(ErrorMessage = "ZIP Code is required.")]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "ZIP Code must be 5 digits or in '12345-6789' format.")]
    [MaxLength(10, ErrorMessage = "ZIP Code cannot exceed 10 characters.")]
    public string ZipCode { get; set; } = string.Empty;
}