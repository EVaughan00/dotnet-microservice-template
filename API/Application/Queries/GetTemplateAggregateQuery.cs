using BuildingBlocks.Common;
using Template.Domain;
using Template.API.DTO;
using System.Collections.Generic;

namespace Template.API.Queries
{
    public class GetTemplateAggregateQuery : Query<List<TemplateAggregateResponseDTO>>
    {
        public string templateID { get; set; }
    }
}