using System.Collections.Generic;
using BuildingBlocks.SeedWork;
using Template.Domain;

namespace Template.Infrastructure
{
    public interface ITemplateEntityRepository : IRepository<TemplateEntity>
    {
        void Create(TemplateEntity TemplateEntity);
        List<TemplateEntity> GetAll();
        TemplateEntity GetById(string id);
        // void Update(TemplateEntity TemplateEntity);
        // void Delete(string email);        
    }    
}