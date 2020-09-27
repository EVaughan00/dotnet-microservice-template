using BuildingBlocks.Common;

namespace Template.API.Commands
{
    public class CreateTemplateAggregateCommand : Command<bool>
    {
        public string templateID { get; set; }
    }
}