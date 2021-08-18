using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class ItemCatalogDomainTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_NameIsInvalid_ThrowInvoiceDomainException(string name)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog(name, "code", "value", "description","codecatalog", true));
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_CodeIsInvalid_ThrowInvoiceDomainException(string code)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", code, "value", "description","codecatalog", true));
        }
        
         [Theory]
         [InlineData("")]
        [InlineData(null)]
        public void Constructor_NameIsInvalid_ThrowInvoiceDomainException(string value)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", "code", value, "description","codecatalog", true));
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_CodeIsInvalid_ThrowInvoiceDomainException(string codecatalog)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", "code", "value", "description",codecatalog, true));
        }
        
        
    }
}