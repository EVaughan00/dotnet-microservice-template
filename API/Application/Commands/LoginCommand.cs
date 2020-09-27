using BuildingBlocks.Common;
using Template.Domain;

namespace Template.API.Commands
{
    public class LoginCommand : Command<SignInResponseDTO>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}