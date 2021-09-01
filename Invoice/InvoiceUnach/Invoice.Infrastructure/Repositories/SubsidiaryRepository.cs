﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class SubsidiaryRepository : ISubsidiaryRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public SubsidiaryRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Subsidiary>> Get(Guid userId)
        {
            return await _dbContext.Subsidiaries.Where(x=>x.UserId == userId).ToListAsync();
        }

        public async Task<Subsidiary> GetById(Guid id)
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

        public async Task<Subsidiary> GetByIdAndUserId(Guid id, Guid userId)
        {
            return await _dbContext.Subsidiaries.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }
    }
}