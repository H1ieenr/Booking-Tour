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

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadImagesRequestDTO model)
        {
            var command = new UploadImagesCommand(model);
            var result = await _mediator.Send(command, HttpContext.RequestAborted);
            return ProcessResult(result);
        }
    }
}