using System.Collections.Generic;
using BuildingBlocks.SeedWork;
using Template.Domain.Aggregates;
using MongoDB.Bson;

namespace Template.Infrastructure
{
    public interface ITemplateEntityRepository : IRepository<TemplateEntity>
    {
        void Create(TemplateEntity TemplateEntity);
        List<TemplateEntity> GetAll();
        TemplateEntity GetById(ObjectId id);
        void Update(TemplateEntity TemplateEntity);
    }    
}