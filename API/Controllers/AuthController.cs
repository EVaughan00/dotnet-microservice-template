using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Template.API.Commands;
using Template.API.Queries;
using Template.Domain;
using System.Collections.Generic;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<TemplateController> _logger;

        public TemplateController(IMediator mediator, ILogger<TemplateController> logger)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTemplateAggregateCommand command)
        {
            try {
                await _mediator.Send(command);

                return Ok();
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("templates")]
        public async Task<ActionResult<List<TemplateEntity>>> Get(GetTemplateAggregateQuery query)
        {
            try {
                var result = await _mediator.Send(query);

                return Ok(result);
            } catch (Exception e) {
                return BadRequest(e.Message);
            };
        }
    }
}