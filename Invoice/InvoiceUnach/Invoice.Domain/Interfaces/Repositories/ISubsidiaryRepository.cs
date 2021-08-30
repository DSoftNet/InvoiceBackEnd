using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface ISubsidiaryRepository : IRepository<Subsidiary>
    {
        Task<List<Subsidiary>> Get();
        Task<Subsidiary> Get(Guid id);
        Subsidiary Add(Subsidiary catalog);
        Subsidiary Update(Subsidiary subsidiary);
    }
}