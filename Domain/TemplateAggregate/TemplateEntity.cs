using BuildingBlocks.SeedWork;

namespace Template.Domain
{
    public class TemplateEntity : Entity, IAggregateRoot
    {
        public string templateID { get; set; }

    }
}