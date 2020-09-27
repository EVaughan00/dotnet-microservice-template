using BuildingBlocks.Common;

namespace Template.API.Commands
{
    public class AuthenticateUserCommand : Command<bool>
    {
        public bool Authenticated { get; set; }
        public SignInResponseDTO User { get; set; }
    }
}