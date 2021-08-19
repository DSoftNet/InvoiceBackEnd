﻿using Invoice.Domain.Entities;
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
                new ItemCatalog(name, "code", "value", "description", true, "codeCatalog"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_CodeIsInvalid_ThrowInvoiceDomainException(string code)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", code, "value", "description", true, "codeCatalog"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_ValueIsInvalid_ThrowInvoiceDomainException(string value)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", "code", value, "description", true, "codeCatalog"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Constructor_CodeCatalogIsInvalid_ThrowInvoiceDomainException(string codeCatalog)
        {
            Assert.Throws<InvoiceDomainException>(() =>
                new ItemCatalog("name", "code", "value", "description", true, codeCatalog));
        }
    }
}