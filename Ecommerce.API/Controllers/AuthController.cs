using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("/register")]
        public async  Task<ApiResponse<string>> RegisterUser(RegisterUserRequest registerUserRequest)
        {
            return ApiResponse<string>.SuccessResponse("Hello");
        }
    }
}
