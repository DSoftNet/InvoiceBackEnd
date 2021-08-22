using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;


namespace Invoice.Domain.Interfaces.Repositories
{
    public interface ISubsidiaryRepository: IRepository<Subsidiary>
    {
        Task<List<Subsidiary>> Gets();
        Task<Subsidiary> Get(Guid id);
        Subsidiary Add(Subsidiary subsidiary);
        Subsidiary Update(Subsidiary subsidiary);
    }
}