using Microsoft.AspNetCore.Mvc;
using Application.Features;
using Shared.Common;
using MediatR;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/web/vehicle")]
    public class VehicleController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("list-lookup")]
        public async Task<IActionResult> GetVehiclesLookup([FromQuery] GetVehiclesLookupRequestDTO model)
        {
            var query = new GetVehiclesLookupQuery(model);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);

            return Ok(result);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetVehicles([FromQuery] GetVehiclesRequestDTO model)
        {
            var query = new GetVehiclesQuery(model);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);

            return Ok(result);
        }
        [HttpGet("view")]
        public async Task<IActionResult> GetById([FromQuery] GetVehicleByIdRequestDTO model)
        {
            var query = new GetVehicleByIdQuery(model);
            var result = await _mediator.Send(query, HttpContext.RequestAborted);

            return ProcessResult(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequestDTO model)
        {
            BindRequestContext(model);
            var command = new CreateVehicleCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleRequestDTO model)
        {
            BindRequestContext(model);
            var command = new UpdateVehicleCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteVehicleRequestDTO model)
        {
            BindRequestContext(model);
            var command = new DeleteVehicleCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
    }
}