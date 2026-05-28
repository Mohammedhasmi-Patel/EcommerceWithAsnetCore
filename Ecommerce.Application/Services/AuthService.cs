using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.ServicesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class AuthService : IAuthService
    {
        public async Task<ApiResponse<string>> RegisterUserService(RegisterUserRequest registerUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
