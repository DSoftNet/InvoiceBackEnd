using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface ISubsidiaryRepository : IRepository<Subsidiary>
    {
        Task<List<Subsidiary>> Get(Guid userId);
        Task<Subsidiary> GetById(Guid id);
        Subsidiary Add(Subsidiary catalog);
        Subsidiary Update(Subsidiary subsidiary);
        Task<Subsidiary> GetByIdAndUserId(Guid id, Guid userId);
    }
}