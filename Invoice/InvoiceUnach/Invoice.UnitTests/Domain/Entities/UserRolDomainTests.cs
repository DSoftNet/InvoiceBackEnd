using System;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class UserRolDomainTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_firstNameIsInvalid_ThrowInvoiceDomainException(string rolName)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new UserRol(rolName, Guid.NewGuid()));
        }
        
    }
}