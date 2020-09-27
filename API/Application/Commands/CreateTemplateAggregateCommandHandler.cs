using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;

namespace Template.API.Commands
{
    public class CreateTemplateAggregateCommandHandler : CommandHandler<CreateTemplateAggregateCommand, bool>
    {

        private readonly ILogger<CreateTemplateAggregateCommandHandler> _logger;

        public CreateTemplateAggregateCommandHandler(ILogger<CreateTemplateAggregateCommandHandler> logger)
        {
            _logger = logger;
        }

        public override async Task<bool> Handle(CreateTemplateAggregateCommand command, CancellationToken token)
        {
            _logger.LogInformation("Template aggregate created with name: " + command.templateID);

            await Task.CompletedTask;

            return true;
        }
    }
}