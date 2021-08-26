using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly InvoiceDbContext _dbContext;

        public ProductRepository(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Get()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Product Add(Product product)
        {
            return _dbContext.Products.Add(product).Entity;
        }

        public Product Update(Product product)
        {
            return _dbContext.Products.Update(product).Entity;
        }

        public async Task<Product> GetByCode(string code)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Code == code);
        }
    }
}