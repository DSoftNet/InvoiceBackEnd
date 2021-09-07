using Autofac;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infrastructure.Repositories;
using Module = Autofac.Module;

namespace Invoice.Admin.Configuration
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogRepository>()
                .As<ICatalogRepository>()
                .InstancePerLifetimeScope();
                
            builder.RegisterType<ItemCatalogRepository>()
                .As<IItemCatalogRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SubsidiaryRepository>()
                .As<ISubsidiaryRepository>()
                .InstancePerLifetimeScope();
        }
 
    }
}