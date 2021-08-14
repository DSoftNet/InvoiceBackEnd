using System;
using System.Net;

namespace Invoice.Domain.Exceptions
{
    public class InvoiceDomainException : DomainException
    {
        public InvoiceDomainException()
        {

        }

        public InvoiceDomainException(string message)
            : base(message)
        {
        }

        public InvoiceDomainException(string message, HttpStatusCode? httpStatusCode)
            : base(message, httpStatusCode)
        {

        }

        public InvoiceDomainException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public InvoiceDomainException(string message, HttpStatusCode? httpStatusCode, Exception exception)
            : base(message, httpStatusCode, exception)
        {
        }
    }
}