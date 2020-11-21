using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Template.Infrastructure;
using Template.Domain.Aggregates;
using Template.Domain.Events;

namespace Template.API.Commands
{
    public class CreateTemplateAggregateCommandHandler : CommandHandler<CreateTemplateAggregateCommand, bool>
    {

        private readonly ILogger<CreateTemplateAggregateCommandHandler> _logger;
        private readonly ITemplateEntityRepository _templates;

        public CreateTemplateAggregateCommandHandler(ILogger<CreateTemplateAggregateCommandHandler> logger, ITemplateEntityRepository entities)
        {
            _templates = entities;
            _logger = logger;
        }

        public override async Task<bool> Handle(CreateTemplateAggregateCommand command, CancellationToken token)
        {
            _logger.LogInformation("Template aggregate created with name: " + command.templateID);

            _templates.Create(new TemplateEntity(command.templateID));

            if (_templates.GetById(command.templateID) == null) _logger.LogInformation("Could not create template entity: " + command.templateID); 

            var template = _templates.GetById(command.templateID);

            template.AddDomainEvent(new TestCreatedDomainEvent() { TemplateID = command.templateID });

            _templates.Update(template);

            await Task.CompletedTask;

            return true;
        }
    }
}