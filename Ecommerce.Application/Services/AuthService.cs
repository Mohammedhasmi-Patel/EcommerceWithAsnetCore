using Ecommerce.Application.DTO.Auth;
using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.RepositoryInterface;
using Ecommerce.Application.ServicesInterface;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<string>> RegisterUserService(RegisterUserRequest registerUserRequest)
        {
            bool isEmailExist = await _userRepository.EmailExistsAsync(registerUserRequest.Email);
            if (isEmailExist)
            {
                return ApiResponse<string>.ConflictResponse("Email already exist.");
            }


            var result = await _userRepository.CreateUserAsync(registerUserRequest);

            if (!result.Succeeded)
            {
                string firstMessage = result.Errors.FirstOrDefault()?.Description ?? "Something went wrong";
                return ApiResponse<string>.BadRequestResponse(firstMessage);
            }


            return ApiResponse<string>.CreatedResponse(null,"User created successfully.");
        }
    }
}
