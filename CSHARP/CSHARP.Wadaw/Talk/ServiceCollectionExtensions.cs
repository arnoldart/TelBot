using Microsoft.Extensions.DependencyInjection;

namespace CSHARP.Wadaw.Talk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTalk(this IServiceCollection services)
        {
            services.AddTransient<TestingTalk>();

            return services;
        }
    }
}