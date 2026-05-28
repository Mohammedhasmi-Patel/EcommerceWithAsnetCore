using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.API.Startup
{
    public static class ConfigureDatabaseService
    {
        //ConfigureProjectDatabaseService
        public static IServiceCollection ConfigureProjectDatabaseService(this IServiceCollection service,IConfiguration configuration)
        {
            string databseUrl = configuration.GetConnectionString("Default");
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(databseUrl);
            });

            service.AddIdentity<ApplicationUser,IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return service;
        }

    }
}
