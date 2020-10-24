using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Template.Infrastructure;
using Template.Domain.Aggregates;
using Template.API.DTO;
using System.Collections.Generic;

namespace Template.API.Queries
{
    public class GetTemplateAggregateQueryHandler : QueryHandler<GetTemplateAggregateQuery, List<TemplateAggregateResponseDTO>>
    {

        private readonly ILogger<GetTemplateAggregateQueryHandler> _logger;
        private readonly ITemplateEntityRepository _entities;

        public GetTemplateAggregateQueryHandler(ILogger<GetTemplateAggregateQueryHandler> logger, ITemplateEntityRepository entities)
        {
            _entities = entities;
            _logger = logger;
        }

        public override async Task<List<TemplateAggregateResponseDTO>> Handle(GetTemplateAggregateQuery query, CancellationToken token)
        {
            var entitiesDTO = new List<TemplateAggregateResponseDTO>();
            
            foreach (TemplateEntity entity in _entities.GetAll())
                entitiesDTO.Add(new TemplateAggregateResponseDTO(){templateID = entity.TemplateID});
        
            _logger.LogInformation("Getting entities from database");

            await Task.CompletedTask;

            return entitiesDTO;

        }
    }
}