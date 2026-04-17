using Microsoft.AspNetCore.Mvc;
using Application.Features;
using Shared.Common;
using MediatR;

namespace API.Controllers
{
    [Route("api/v1/web/travel-tour")]
    public class TravelToursController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public TravelToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("view")]
        public async Task<IActionResult> GetById([FromQuery] GetTravelTourByIdRequestDTO model)
        {
            var query = new GetTourByIdQuery(model);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);

            return ProcessResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTravelTourRequestDTO model)
        {
            var command = new CreateTravelTourCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
    }
}