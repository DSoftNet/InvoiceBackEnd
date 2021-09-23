using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<List<Client>> Get(Guid userId);
        Task<Client> GetById(Guid id);
        Task<Client> GetByEmail(string email);
        Client Add(Client client);
        Client Update(Client client);
        void Delete(Client client);
        Task<Client> GetByIdAndUserId(Guid id, Guid userId);
    }
}