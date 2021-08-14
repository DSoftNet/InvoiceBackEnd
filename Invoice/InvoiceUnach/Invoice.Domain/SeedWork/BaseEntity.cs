using System;

namespace Invoice.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
    }
}