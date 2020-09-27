using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;

namespace Template.API.Commands
{
    public class AuthenticateUserCommandHandler : CommandHandler<AuthenticateUserCommand, bool>
    {

        private readonly ILogger<AuthenticateUserCommandHandler> _logger;

        public AuthenticateUserCommandHandler(ILogger<AuthenticateUserCommandHandler> logger)
        {
            _logger = logger;
        }

        public override async Task<bool> Handle(AuthenticateUserCommand command, CancellationToken token)
        {
            _logger.LogInformation("Authenticating User");

            await Task.CompletedTask;

            return true;
        }
    }
}