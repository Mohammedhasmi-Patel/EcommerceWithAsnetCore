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
        private readonly IJwtService _jwtService;



        public AuthService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
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

        public async Task<ApiResponse<SignInUserResponse>> SignInUserService(SignInUserRequest signInUserRequest)
        {
            bool isEmailExist = await _userRepository.EmailExistsAsync(signInUserRequest.Email);

            if (!isEmailExist)
            {
                return ApiResponse<SignInUserResponse>.UnauthorizedResponse("User not found with this email");
            }

            ApplicationUser applicationUser = await _userRepository.GetByEmailAsync(signInUserRequest.Email);

            bool isPasswordMatch = await _userRepository.CheckPasswordAsync(applicationUser,signInUserRequest.Password);

            if (!isPasswordMatch)
            {
                return ApiResponse<SignInUserResponse>.UnauthorizedResponse("Invalid credentials");
            }

            JwtTokenResponse jwtTokenResponse = _jwtService.GenerateJwtToken(applicationUser);

            SignInUserResponse response = new SignInUserResponse() { 
                Token = jwtTokenResponse.Token,
                ExpirationToken = jwtTokenResponse.TokenExpiration,
                Avatar = applicationUser.ProfileUrl ?? null,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName
            };

            return ApiResponse<SignInUserResponse>.SuccessResponse(response,"User login successfully.");
        }
    }
}
