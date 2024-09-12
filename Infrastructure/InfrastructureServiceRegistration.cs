using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Contracts.Logging;
using Infrastructure.Logging;


namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
        return services;
    }
}
