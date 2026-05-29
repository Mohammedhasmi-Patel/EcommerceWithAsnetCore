using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.RepositoryInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser applicationUser, string password)
        {
            return await _userManager.CheckPasswordAsync(applicationUser,password);
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterUserRequest registerUserRequest)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = registerUserRequest.FirstName,
                LastName = registerUserRequest.LastName,
                IsActive = true,
                UserName = registerUserRequest.Email,
                Email = registerUserRequest.Email,
                Role = nameof(UserRole.Customer)
            };

            return await _userManager.CreateAsync(applicationUser,registerUserRequest.Password);

        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
