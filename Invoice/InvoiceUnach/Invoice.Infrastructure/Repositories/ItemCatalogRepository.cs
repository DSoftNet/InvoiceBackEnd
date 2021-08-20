using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class ItemCatalogRepository : IItemCatalogRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;
        
        public ItemCatalogRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemCatalog>> Gets()
        {
            return await _dbContext.ItemCatalogs.ToListAsync();
        }

        public async Task<ItemCatalog> Get(string Code)
        {
            return await _dbContext.ItemCatalogs.FirstOrDefaultAsync(x => x.Code == Code);
        }

        public ItemCatalog Add(ItemCatalog itemCatalog)
        {
            return _dbContext.ItemCatalogs.Add(itemCatalog).Entity;
        }

        public ItemCatalog Update(ItemCatalog itemCatalog)
        {
            return _dbContext.ItemCatalogs.Update(itemCatalog).Entity;
        }

    }
}