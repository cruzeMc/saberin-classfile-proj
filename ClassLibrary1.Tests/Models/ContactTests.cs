using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClassLibrary1.Models;
using JetBrains.Annotations;
using Xunit;

namespace ClassLibrary1.Tests.Models;

[TestSubject(typeof(Contact))]
public class ContactTests
{
    // Helper method to validate a model and collect validation results.
    private IList<ValidationResult> ValidateModel(Contact contact)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(contact, serviceProvider: null, items: null);
        Validator.TryValidateObject(contact, context, results, validateAllProperties: true);
        return results;
    }

    [Fact]
    public void ValidContact_ShouldPassValidation()
    {
        // Arrange: Create a valid Contact with required fields and an address.
        var contact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Addresses = new List<Address>
            {
                new Address
                {
                    Street = "123 Main Street",
                    City = "Springfield",
                    State = "IL",
                    ZipCode = "12345",
                    ContactId = 1
                }
            }
        };

        // Act
        var results = ValidateModel(contact);

        // Assert: No validation errors should be present.
        Assert.Empty(results);
    }

    [Fact]
    public void MissingRequiredFields_ShouldFailValidation()
    {
        // Arrange: Create a Contact with missing FirstName and LastName.
        var contact = new Contact
        {
            FirstName = null,
            LastName = null
        };

        // Act
        var results = ValidateModel(contact);

        // Assert: Validation errors should include FirstName and LastName.
        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Contact.FirstName)));
        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Contact.LastName)));
    }

    [Fact]
    public void FirstNameExceedsMaxLength_ShouldFailValidation()
    {
        // Arrange: Create a Contact with a FirstName exceeding 100 characters.
        var contact = new Contact
        {
            FirstName = new string('A', 101),
            LastName = "Doe"
        };

        // Act
        var results = ValidateModel(contact);

        // Assert: There should be an error related to FirstName.
        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Contact.FirstName)));
    }

    [Fact]
    public void LastNameExceedsMaxLength_ShouldFailValidation()
    {
        // Arrange: Create a Contact with a LastName exceeding 100 characters.
        var contact = new Contact
        {
            FirstName = "John",
            LastName = new string('B', 101)
        };

        // Act
        var results = ValidateModel(contact);

        // Assert: There should be an error related to LastName.
        Assert.Contains(results, r => r.MemberNames.Contains(nameof(Contact.LastName)));
    }
}