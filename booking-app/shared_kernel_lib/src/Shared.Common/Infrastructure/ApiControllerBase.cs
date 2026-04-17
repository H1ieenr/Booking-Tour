using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using MediaR;

namespace Shared.Common
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        //private ISender? _sender;
        //protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected int user_id
        {
            get
            {
                var identifier = User.FindFirstValue(ClaimTypes.NameIdentifier) 
                                 ?? User.FindFirstValue("id")
                                 ?? User.FindFirstValue(ClaimTypes.Sid);

                if (int.TryParse(identifier, out var id))
                {
                    return id;
                }

                return 0;
            }
        }

        protected string? email => User.FindFirst(ClaimTypes.Email)?.Value;
        protected string? user_name => User.Identity?.Name;
        protected IActionResult ProcessResult<T>(OperationResult<T> result)
        {
            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}