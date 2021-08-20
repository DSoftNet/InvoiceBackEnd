using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface ICatalogRepository : IRepository<Catalog>
    {
        Task<List<Catalog>> Gets();
        Task<Catalog> Get(Guid id);
        Catalog Add(Catalog catalog);
        Catalog Update(Catalog catalog);
    }
}