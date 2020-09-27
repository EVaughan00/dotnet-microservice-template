using BuildingBlocks.Common;
using Identity.Domain;

namespace Identity.API.Commands
{
    public class LoginCommand : Command<SignInResponseDTO>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}