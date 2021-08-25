using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<List<Client>> Gets();
        Task<Client> Get(Guid id);
        Task<Client> Get(string email);
        Client Add(Client client);
        Client Update(Client client);
    }
}