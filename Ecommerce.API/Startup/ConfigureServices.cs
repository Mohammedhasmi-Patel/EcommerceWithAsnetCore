using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.RepositoryInterface;
using Ecommerce.Application.Services;
using Ecommerce.Application.ServicesInterface;
using Ecommerce.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Startup
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureProjectService(this IServiceCollection service)
        {
            service.AddControllers();
            service.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    string firstError = actionContext.ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .FirstOrDefault() ?? "Invalid request data";

                    var apiResponse = ApiResponse<object>.BadRequestResponse(firstError);
                    return new BadRequestObjectResult(apiResponse);
                };
            });
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IJwtService, JwtService>();


            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            return service;
        }
    }
}
