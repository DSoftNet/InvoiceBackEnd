using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public CatalogRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Catalog>> Get()
        {
            return await _dbContext.Catalogs.ToListAsync();
        }

        public async Task<Catalog> GetById(Guid id)
        {
            return await _dbContext.Catalogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Catalog Add(Catalog catalog)
        {
            return _dbContext.Catalogs.Add(catalog).Entity;
        }

        public Catalog Update(Catalog catalog)
        {
            return _dbContext.Catalogs.Update(catalog).Entity;
        }

        public async Task<Catalog> GetByCode(string code)
        {
            return await _dbContext.Catalogs.FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}