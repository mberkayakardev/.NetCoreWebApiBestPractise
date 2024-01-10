using AkarSoftware.ApiBestPractise.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoftware.ApiBestPractise.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumeBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CostumeResponseDto<T> Response) // response a göre ilgili dönüşler sağlanacaktır. 
        {
            if (Response.StatusCode == 204) // No Content (delete / Update)
            {
                return new ObjectResult(null) { StatusCode = Response.StatusCode }; // OK Bad request gibi dönmeme gerek yok Object result ta datayı null yaptık 
                // her seferinde tek tek dönmemize gerek kalmadı
            }
            return new ObjectResult(Response) { StatusCode = Response.StatusCode };
        }
    }
}
