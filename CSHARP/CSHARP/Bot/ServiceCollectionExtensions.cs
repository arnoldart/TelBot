using Microsoft.Extensions.DependencyInjection;

namespace CSHARP.Bot;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, string botToken)
    {
        services.AddSingleton<UpdateHandler>();

        return services;
    }
}