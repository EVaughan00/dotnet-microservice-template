using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Identity.API.Utils;
using Identity.Domain;

namespace Identity.API.Commands
{
    public class LoginCommandHandler : CommandHandler<LoginCommand, SignInResponseDTO>
    {

        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly JwtGenerator _jwtGenerator;

        public LoginCommandHandler(ILogger<LoginCommandHandler> logger, JwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
            _logger = logger;
        }

        public override async Task<SignInResponseDTO> Handle(LoginCommand command, CancellationToken token)
        {
            _logger.LogInformation("Loggin in user: " + command.username);

            await Task.CompletedTask;

            var user = new User {
                username = command.username,
                password = command.password
            };                

            return new SignInResponseDTO()
            {
                username = user.username,
                uuid = "123",
                token = this._jwtGenerator.Generate(user.username, "User")
            };

        }
    }
}