using Invoice.Domain.Entities;
using Invoice.Domain.Exceptions;
using Xunit;

namespace Invoice.UnitTests.Domain.Entities
{
    public class CatalogDomainTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_NameIsInvalid_ThrowInvoiceDomainException(string name)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new Catalog(name, "code", "value", "description", true));
        }
    }
}