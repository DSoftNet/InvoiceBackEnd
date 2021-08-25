using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class SubsidiaryRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public SubsidiaryRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subsidiary>> Gets()
        {
            return await _dbContext.Subsidiaries.ToListAsync();
        }

        public async Task<Subsidiary> Get(Guid id)
        {
            return await _dbContext.Subsidiaries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Subsidiary Add(Subsidiary subsidiary)
        {
            return _dbContext.Subsidiaries.Add(subsidiary).Entity;
        }

        public Subsidiary Update(Subsidiary subsidiary)
        {
            return _dbContext.Subsidiaries.Update(subsidiary).Entity;
        }
    }
}