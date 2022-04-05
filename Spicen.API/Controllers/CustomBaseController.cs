using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spicen.Core.DTOs;

namespace Spicen.API.Controllers
{
    /// <summary>
    /// This class is used for dynamic return of response
    /// </summary>
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if(response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
