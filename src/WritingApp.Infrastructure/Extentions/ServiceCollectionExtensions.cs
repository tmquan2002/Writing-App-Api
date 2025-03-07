using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WritingApp.Domain.Entities;
using WritingApp.Domain.Repositories;
using WritingApp.Infrastructure.Persistence;
using WritingApp.Infrastructure.Repositories;

namespace WritingApp.Infrastructure.Extentions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WritingDb");
        services.AddDbContext<WritingsDbContext>(options =>
            options.UseOracle(connectionString)
                .EnableSensitiveDataLogging()
        );

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WritingsDbContext>();

        services.AddScoped<IWritingsRepository, WritingsRepository>();
    }
}
