using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BuildingBlocks.Common;
using Template.API.Utils;
using Template.Domain;
using Template.API.DTO;
using System.Collections.Generic;

namespace Template.API.Queries
{
    public class GetTemplateAggregateQueryHandler : QueryHandler<GetTemplateAggregateQuery, List<TemplateAggregateResponseDTO>>
    {

        private readonly ILogger<GetTemplateAggregateQueryHandler> _logger;
        private readonly JwtGenerator _jwtGenerator;

        public GetTemplateAggregateQueryHandler(ILogger<GetTemplateAggregateQueryHandler> logger, JwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
            _logger = logger;
        }

        public override async Task<List<TemplateAggregateResponseDTO>> Handle(GetTemplateAggregateQuery query, CancellationToken token)
        {
            var entities = new List<TemplateAggregateResponseDTO>(); 
            
            entities.Add(new TemplateAggregateResponseDTO(){ templateID = "Template1" });

            _logger.LogInformation("Getting entities");

            await Task.CompletedTask;          

            return entities;

        }
    }
}