using Microsoft.Extensions.DependencyInjection;
using WritingApp.Application.Interactor;
using WritingApp.Application.Interfaces.Services;
using WritingApp.Application.Services;

namespace WritingApp.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWritingInteractor, WritingInteractor>();
            services.AddScoped<IAuthInteractor, AuthInteractor>();
            services.AddScoped<IWritingService, WritingService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
