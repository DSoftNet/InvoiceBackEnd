using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> Get();
        Task<User> GetByIdentification(string identification);
        Task<User> GetById(Guid id);
        User Add(User user);
        User Update(User user);
    }
}