using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Template.Domain
{
    public class TemplateEntity : Entity, IAggregateRoot
    {

        [BsonElement("TemplateID")]
        public string TemplateID { get; set; }

        public TemplateEntity(string templateID)
        {
            TemplateID = templateID;
        }
        
    }
}