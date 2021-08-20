﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public ClientRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> Gets()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> Get(Guid id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Client Add(Client client)
        {
            return _dbContext.Clients.Add(client).Entity;
        }

        public Client Update(Client client)
        {
            return _dbContext.Clients.Update(client).Entity;
        }

    }    

}
