using BuildingBlocks.SeedWork;

namespace Template.Domain
{
    public class User : IAggregateRoot
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}