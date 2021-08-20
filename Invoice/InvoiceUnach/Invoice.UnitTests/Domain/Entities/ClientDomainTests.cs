using System;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class ClientDomainTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_firstNameIsInvalid_ThrowInvoiceDomainException(string firstName)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName, "secondName", "firstLastName",
                    "secondLastName", "identificationType",
                    "identification", "email", "address", "phone",
                    "Phone", status: true, Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_firstLastNameIsInvalid_ThrowInvoiceDomainException(string firstLastName)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName: "firstName", secondName: "secondName", firstLastName,
                    "secondLastName", "identificationType",
                    "identification", "email", "address", "phone",
                    "Phone", status: true,
                    Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_identificationType_ThrowInvoiceDomainException(string identificationType)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName: "firstName", secondName: "secondName", "firstLastName",
                    "secondLastName", identificationType,
                    "identification", "email", "address", "phone",
                    "Phone", status: true,
                    Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_identification_ThrowInvoiceDomainException(string identification)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName: "firstName", secondName: "secondName", "firstLastName",
                    "secondLastName", "identificationType",
                    identification, "email", "address", "phone",
                    "Phone", status: true,
                    Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_email_ThrowInvoiceDomainException(string email)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName: "firstName", secondName: "secondName", "firstLastName",
                    "secondLastName", "identificationType",
                    "identification", email, "address", "phone",
                    "Phone", status: true,
                    Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }

        [Fact]
        public void Constructor_userId_ThrowInvoiceDomainException()
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Client(firstName: "firstName", secondName: "secondName", "firstLastName",
                    "secondLastName", "identificationType",
                    "identification", email: "email", "address", "phone",
                    "Phone", status: true,
                    Guid.Empty));
        }
    }
}