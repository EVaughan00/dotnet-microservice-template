using System.Threading;
using System.Threading.Tasks;
using Template.Domain.Events;
using BuildingBlocks.Common.Events;
using Microsoft.Extensions.Logging;

namespace Template.API.Application.DomainEventHandlers
{
    public class TemplateCreatedDomainEventHandler : DomainEventHandler<TemplateCreatedDomainEvent>
    {
        private readonly ILogger<TemplateCreatedDomainEventHandler> _logger;
        public TemplateCreatedDomainEventHandler(ILogger<TemplateCreatedDomainEventHandler> logger)
        {
            _logger = logger;

        }
        public override async Task Handle(TemplateCreatedDomainEvent request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            _logger.LogInformation("Template created domain event");

        }
    }
}