using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;

namespace Invoice.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> Get(Guid userId);
        Task<Product> GetById(Guid id);
        Product Add(Product product);
        Product Update(Product product);
        Task<Product> GetByCode(string code);
        void Delete(Product product);
    }
}