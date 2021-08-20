using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class UserRolRepository: IUserRolRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public UserRolRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserRol>> Gets()
        {
            return await _dbContext.UsersRol.ToListAsync();
        }

        public async Task<UserRol> Get(Guid id)
        {
            return await _dbContext.UsersRol.FirstOrDefaultAsync(x => x.Id == id);
        }

        public UserRol Add(UserRol userRol)
        {
            return _dbContext.UsersRol.Add(userRol).Entity;
        }
        
        public UserRol Update(UserRol userRol)
        {
            return _dbContext.UsersRol.Update(userRol).Entity;
        }
    }
}