using Microsoft.Extensions.Logging;
using Template.Domain.Aggregates;
using BuildingBlocks.SeedWork;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Template.Infrastructure
{
    public class TemplateEntityRepository : ITemplateEntityRepository
    {
        private ILogger<TemplateEntityRepository> _logger;
        private IDbCollection<TemplateEntity> _Templates;
        public static string CollectionName = "TemplateEntities";

        public TemplateEntityRepository(ILoggerFactory logger, IDatabaseContext context)
        {
            _logger = logger.CreateLogger<TemplateEntityRepository>();
            _Templates = context.GetCollection<TemplateEntity>(CollectionName);
        }

        public void Create(TemplateEntity entity)
        {
            _Templates.InsertOne(entity);
            _logger.LogInformation($"Template {entity.TemplateID} inserted in database"); 
        }

        public List<TemplateEntity> GetAll() 
        {
            var result = _Templates.FindAll();

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant Template retrieval attempted");
            }

            _logger.LogInformation($"Templates retrieved from database");
            return result;
        }

        public TemplateEntity GetById(string id) 
        {
            var result = _Templates.FindOne(e => e.TemplateID.Equals(id));

            if (result == null) 
            {
                _logger.LogInformation($"Non-existant Template retrieval attempted");
                throw new System.Exception("Could not retreive entity");
            }

            _logger.LogInformation($"Template [{id}] retrieved from database");
            return result;
        }
        public void Update(TemplateEntity Template)
        {
            var existing = _Templates.FindOne(u => u.Id == Template.Id);

            if (existing == null)
            {
                throw new System.Exception("No template found to update");
            }

            _Templates.UpdateOne(Template);
        }
    }
}