using BuildingBlocks.Common;

namespace Identity.API.Commands
{
    public class AuthenticateUserCommand : Command<bool>
    {
        public bool Authenticated { get; set; }
        public SignInResponseDTO User { get; set; }
    }
}