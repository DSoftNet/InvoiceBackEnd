using System.Threading;
using System.Threading.Tasks;
using Invoice.Domain.Entities;
using Invoice.Domain.SeedWork;
using Invoice.Infrastructure.EntityConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infrastructure
{
    public class InvoiceDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options)
            : base(options)
        {
        }

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Subsidiary> Subsidiaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UsersRol { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<ItemCatalog> ItemCatalogs { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientEFConfig());
            modelBuilder.ApplyConfiguration(new SubsidiaryEFConfig());
            modelBuilder.ApplyConfiguration(new UserEFConfig());
            modelBuilder.ApplyConfiguration(new UserRolEFConfig());
            modelBuilder.ApplyConfiguration(new CatalogEFConfig());
            modelBuilder.ApplyConfiguration(new ItemCatalogEFConfig());
        }
    }
}