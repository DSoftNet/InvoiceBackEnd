using System.Reflection;
using Autofac;
using FluentValidation;
using Invoice.Application.Commands;
using Invoice.Application.Validations;
using Invoice.Domain.Services.Validations;
using Invoice.Infrastructure.Behavior;
using MediatR;
using Module = Autofac.Module;

namespace Invoice.Api.Configuration
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateCatalogCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(ValidateUserService).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(CreateCatalogCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return componentContext.TryResolve(t, out o) ? o : null;
                };
            });

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}