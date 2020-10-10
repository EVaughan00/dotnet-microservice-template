using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Template.Infrastructure;
using Template.Domain;

namespace Template.API.Commands
{
    public class CreateTemplateAggregateCommandHandler : CommandHandler<CreateTemplateAggregateCommand, bool>
    {

        private readonly ILogger<CreateTemplateAggregateCommandHandler> _logger;
        private readonly ITemplateEntityRepository _entities;

        public CreateTemplateAggregateCommandHandler(ILogger<CreateTemplateAggregateCommandHandler> logger, ITemplateEntityRepository entities)
        {
            _entities = entities;
            _logger = logger;
        }

        public override async Task<bool> Handle(CreateTemplateAggregateCommand command, CancellationToken token)
        {
            _logger.LogInformation("Template aggregate created with name: " + command.templateID);

            _entities.Create(new TemplateEntity(command.templateID));

            if (_entities.GetById(command.templateID) == null) _logger.LogInformation("Could not create template entity: " +command.templateID); 

            await Task.CompletedTask;

            return true;
        }
    }
}