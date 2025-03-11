using Microsoft.Extensions.DependencyInjection;
using WritingApp.Application.Interfaces.Services;
using WritingApp.Application.Services.Auths;
using WritingApp.Application.Services.Writings;

namespace WritingApp.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWritingService, WritingService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
