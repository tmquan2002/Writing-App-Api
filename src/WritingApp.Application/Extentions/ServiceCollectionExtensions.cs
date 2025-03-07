using Microsoft.Extensions.DependencyInjection;
using WritingApp.Application.Writings.Services;

namespace WritingApp.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWritingService, WritingService>();
        }
    }
}
