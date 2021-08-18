using System;
using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class ProductDomainTests
    {
        [Theory]
        [InlineData("")] 
        [InlineData(null)]
        public void Constructor_NameIsInvalid_ThrowInvoiceDomainException(string name)
        { 
            Assert.Throws<InvoiceDomainException>(() =>
                new Product(name,"lola","aa1",23,true,24,true,DateTime.Now, true,DateTime.Now,DateTime.Now, Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_CodeIsInvalid_ThrowInvoiceDomainException(string code)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Product("lola","lola",code,23,true,24,true,DateTime.Now, true,DateTime.Now,DateTime.Now, Guid.Parse("5C60F693-BEF5-E011-A485-80EE7300C695")));
        }
    }
}