using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ServicesInterface
{
    public interface IAuthService
    {
        public Task<ApiResponse<string>> RegisterUserService(RegisterUserRequest registerUserRequest);
        public Task<ApiResponse<SignInUserResponse>> SignInUserService(SignInUserRequest signInUserRequest);
    }
}
