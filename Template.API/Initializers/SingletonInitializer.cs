
using Template.API.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuildingBlocks.SeedWork;
using BuildingBlocks.Common.Events;
using Template.Domain.Events;
using Template.Api.EventHandlers;
using Template.Infrastructure.IntegrationEvents;

namespace Template.API.Initializers
{

    /**
     * Class that initializes singletons neccesary for DI
     */
    public class SingletonInitializer : IInitializer {

        public void InitializeServices(IServiceCollection services, IConfiguration configuration) {

            services.AddTransient<JwtGenerator>();
            services.AddTransient<IDatabaseContext, MongoDbContext>();

            // Events and event handlers
            services.AddTransient<TemplateCreatedIntegrationEventHandler>();
            services.AddTransient<IEventHandler<TemplateCreatedIntegrationEvent>, TemplateCreatedIntegrationEventHandler>();

        }
    }
}
