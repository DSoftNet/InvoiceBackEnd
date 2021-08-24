﻿using Autofac;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infrastructure.Repositories;
using Module = Autofac.Module;

namespace Invoice.Api.Configuration
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CatalogRepository>()
                .As<ICatalogRepository>()
                .InstancePerLifetimeScope();
        }
    }
}