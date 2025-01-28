using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static IServiceCollection CreateServiceCollection(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}