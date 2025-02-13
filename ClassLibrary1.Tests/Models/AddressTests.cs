using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClassLibrary1.Models;
using JetBrains.Annotations;
using Xunit;

namespace ClassLibrary1.Tests.Models;

[TestSubject(typeof(Address))]
public class AddressTests
{

    // Helper method to validate a model and collect validation results.
        private IList<ValidationResult> ValidateModel(Address address)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(address, serviceProvider: null, items: null);
            Validator.TryValidateObject(address, context, results, validateAllProperties: true);
            return results;
        }

        [Fact]
        public void ValidAddress_ShouldPassValidation()
        {
            // Arrange: create a valid address.
            var address = new Address
            {
                Street = "123 Main Street",
                City = "Springfield",
                State = "IL",
                ZipCode = "12345",
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: no validation errors.
            Assert.Empty(results);
        }

        [Fact]
        public void MissingRequiredFields_ShouldFailValidation()
        {
            // Arrange: create an address with missing required fields.
            var address = new Address
            {
                Street = null,  // Missing required street.
                City = null,    // Missing required city.
                State = null,   // Missing required state.
                ZipCode = null, // Missing required zip code.
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: errors should be reported for each required field.
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.Street)));
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.City)));
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.State)));
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.ZipCode)));
        }

        [Fact]
        public void StreetExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange: Street has a maximum length of 100.
            var address = new Address
            {
                Street = new string('a', 101),
                City = "City",
                State = "IL",
                ZipCode = "12345",
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: validation error should mention the Street field.
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.Street)));
        }

        [Fact]
        public void CityExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange: City has a maximum length of 50.
            var address = new Address
            {
                Street = "123 Main Street",
                City = new string('b', 51),
                State = "IL",
                ZipCode = "12345",
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: validation error should mention the City field.
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.City)));
        }

        [Fact]
        public void StateExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange: State has a maximum length of 2.
            var address = new Address
            {
                Street = "123 Main Street",
                City = "City",
                State = "ILL", // 3 characters, exceeding the maximum.
                ZipCode = "12345",
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: validation error should mention the State field.
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.State)));
        }

        [Fact]
        public void ZipCodeExceedsMaxLength_ShouldFailValidation()
        {
            // Arrange: ZipCode has a maximum length of 10.
            var address = new Address
            {
                Street = "123 Main Street",
                City = "City",
                State = "IL",
                ZipCode = "12345678901", // 11 characters.
                ContactId = 1
            };

            // Act
            var results = ValidateModel(address);

            // Assert: validation error should mention the ZipCode field.
            Assert.Contains(results, r => r.MemberNames.Contains(nameof(Address.ZipCode)));
        }
}