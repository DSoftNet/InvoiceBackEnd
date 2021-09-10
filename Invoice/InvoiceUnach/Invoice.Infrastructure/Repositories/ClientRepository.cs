using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Client>> Get(Guid userId)
        {
            return await _dbContext.Clients.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Client Add(Client client)
        {
            return _dbContext.Clients.Add(client).Entity;
        }

        public Client Update(Client client)
        {
            return _dbContext.Clients.Update(client).Entity;
        }

        public async Task<Client> GetByIdAndUserId(Guid id, Guid userId)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }
        public void Delete(Client client)
        {
            _dbContext.Clients.Remove(client);
        }
    }
}