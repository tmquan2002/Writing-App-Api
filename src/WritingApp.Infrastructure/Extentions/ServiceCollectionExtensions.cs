﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WritingApp.Application.ApplicationEntities;
using WritingApp.Application.Interfaces.Repository;
using WritingApp.Domain.Entities;
using WritingApp.Infrastructure.Persistence;
using WritingApp.Infrastructure.Repositories;

namespace WritingApp.Infrastructure.Extentions;

public static class InfrastructureServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WritingDb");
        services.AddDbContext<WritingsDbContext>(options =>
            options.UseOracle(connectionString)
                .EnableSensitiveDataLogging()
        );

        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WritingsDbContext>();

        services.AddScoped<IWritingsRepository, WritingsRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
    }
}
