using Microsoft.AspNetCore.Mvc;
using Application.Features;
using Shared.Common;
using MediatR;

namespace Tour.API.Controllers
{
    [Route("api/v1/web/image")]
    public class ImageController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("updates")]
        public async Task<IActionResult> Uploads([FromForm] UpdateImagesRequestDTO model)
        {
            var command = new UpdateImagesCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }

        [HttpPost("set-main")]
        public async Task<IActionResult> SetMain([FromBody] SetMainImageRequestDTO model)
        {
            var command = new SetMainImageCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
    }
}