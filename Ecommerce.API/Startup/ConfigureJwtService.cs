using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommerce.Application.DTO.Common;

namespace Ecommerce.API.Startup
{
    public static class ConfigureJwtService
    {
        public static IServiceCollection ConfigureProjectJwtService(this IServiceCollection service,IConfiguration configuration)
        {
            service.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
            JwtConfiguration jwtConfiguration = configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey))

                };
            });

            service.AddAuthorization();

            return service;

        }
    }
}
