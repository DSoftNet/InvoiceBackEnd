using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IItemCatalogRepository : IRepository<ItemCatalog>
    {
      
        Task<ItemCatalog> GetByCode(string code);
        ItemCatalog Add(ItemCatalog itemCatalog);
        ItemCatalog Update(ItemCatalog itemCatalog);

        
    }
}