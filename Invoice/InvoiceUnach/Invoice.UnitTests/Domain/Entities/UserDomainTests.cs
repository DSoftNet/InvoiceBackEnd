using System;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class UserDomainTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_firstNameIsInvalid_ThrowInvoiceDomainException(string firstName)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new User(firstName, "secondName", "firstLastName", "secondLastName",
                    "identificationType", "identification", "example@exam.com", "address", "phone",
                    "cellphone", "userName", "password", "status", DateTime.Now, DateTime.Now));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_firstLastNameIsInvalid_ThrowInvoiceDomainException(string firstLastName)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new User("name", "secondName", firstLastName, "secondLastName",
                    "identificationType", "identification", "example@exam.com", "address", "phone",
                    "cellphone", "userName", "password", "status", DateTime.Now, DateTime.Now));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_identificationIsInvalid_ThrowInvoiceDomainException(string identification)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new User("name", "secondName", "firstLastName", "secondLastName",
                    "identificationType", identification, "example@exam.com", "address", "phone",
                    "cellphone", "userName", "password", "status", DateTime.UtcNow, DateTime.UtcNow));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_emailIsInvalid_ThrowInvoiceDomainException(string email)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new User("name", "secondName", "firstLastName", "secondLastName",
                    "identificationType", "identification", email, "address", "phone",
                    "cellphone", "userName", "password", "status", DateTime.UtcNow, DateTime.UtcNow));
        }
    }
}