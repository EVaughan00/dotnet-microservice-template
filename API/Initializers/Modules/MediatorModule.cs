using Autofac;
using MediatR;
using System.Reflection;
using Template.API.Commands;
using Template.API.Queries;
using BuildingBlocks.Common;

namespace Template.API.Initializers
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {  
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
            
            builder.RegisterAssemblyTypes(typeof(ReferenceCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequest<>));

            builder.RegisterAssemblyTypes(typeof(ReferenceCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(ReferenceQuery).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequest<>));

            builder.RegisterAssemblyTypes(typeof(ReferenceQueryHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.Register<ServiceFactory>(context => {
                var componentContext = context.Resolve<IComponentContext>();
                
                return systemType => { 
                    object defaultObject; 
                    var canResolveType = componentContext.TryResolve(systemType, out defaultObject);

                    return canResolveType ? defaultObject : null; 
                };                
            }); 
        }        
    }

}