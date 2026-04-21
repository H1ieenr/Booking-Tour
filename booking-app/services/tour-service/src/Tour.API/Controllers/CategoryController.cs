using Microsoft.AspNetCore.Mvc;
using Application.Features;
using Shared.Common;
using MediatR;

namespace Tour.API.Controllers
{
    [Route("api/v1/web/category")]
    public class CategoryController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [HttpGet("view")]
        // public async Task<IActionResult> GetById([FromQuery] GetTravelTourByIdRequestDTO model)
        // {
        //     var query = new GetTourByIdQuery(model);
        //     var result = await _mediator.Send(query, HttpContext.RequestAborted);

        //     return ProcessResult(result);
        // }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateCategoryRequestDTO model)
        {
            var command = new CreateCategoryCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryRequestDTO model)
        {
            var command = new UpdateCategoryCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
    }
}