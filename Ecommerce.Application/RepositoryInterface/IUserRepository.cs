using Ecommerce.Application.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.RepositoryInterface
{
    public interface IUserRepository
    {
        public Task<bool> EmailExistsAsync(string email);

        public Task<IdentityResult> CreateUserAsync(RegisterUserRequest registerUserRequest);
    }
}
