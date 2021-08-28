using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public UserRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> Get()
        {
            return await _dbContext.Users.Include(x=>x.Clients).ToListAsync();
        }

        public async Task<User> GetByIdentification(string identification)
        {
           
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Identification == identification );
        }
        
        public async Task<User> GetByIdentificationOrId(string identification,Guid? id)
        {
           
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Identification == identification|| x.Id == id);
        }
        
        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public User Add(User user)
        {
            return _dbContext.Users.Add(user).Entity;
        }

        public User Update(User user)
        {
            return _dbContext.Users.Update(user).Entity;
        }
            
    }
}