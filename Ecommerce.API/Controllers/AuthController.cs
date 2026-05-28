using Azure;
using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest registerUserRequest)
        {
            var response =  await _authService.RegisterUserService(registerUserRequest);
            return StatusCode(response.StatusCode, response);
        }
    }
}
