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

        // public Template GetByEmail(string email) 
        // {
        //     email = email.ToLower();
        //     var result = _Templates.FindOne(u => u.Email.Equals(email));

        //     if (result == null) 
        //     {
        //         _logger.LogInformation($"Non-existant Template [{email}] retrieval attempted");
        //         var ex = new ApiException($"That Templatename and / or password are incorrect");
        //         ex.AddError("password", ex.Message);

        //         throw ex;
        //     }

        //     _logger.LogInformation($"Template [{email}] retrieved from database");
        //     return result;
        // }

        // public void Update(Template Template)
        // {
        //     var existing = _Templates.FindOne(u => u.Id == Template.Id);
        //     var duplicate = _Templates.FindOne(u => u.Email.Equals(Template.Email.Address));

        //     if (existing == null)
        //     {
        //         throw new IdentityInfrastructureException($"No Template exists to update");
        //     }

        //     if (duplicate != null && !existing.Equals(duplicate))  
        //     {                
        //         var ex = new ApiException($"That email is already taken");
        //         ex.AddError("email", ex.Message);

        //         throw ex;
        //     }

        //     _Templates.UpdateOne(Template);
        // }

        // public void Delete(string email)
        // {
        //     try {
        //         GetByEmail(email);

        //         _logger.LogInformation($"Template [{email}] removed from database");
        //         _Templates.DeleteOne(u => u.Email.Address == email);
        //     } catch {
        //         _logger.LogInformation($"Non-existant Template [{email}] deletion attempted");
        //         throw new IdentityInfrastructureException($"No Template with an email: \"{email}\" exists to delete");
        //     }
        // }
    }
}