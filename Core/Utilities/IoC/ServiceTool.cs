using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; set; }

    public static IServiceCollection CreateServiceCollection(IServiceCollection serviceCollection)
    {
        ServiceProvider = serviceCollection.BuildServiceProvider();
        return serviceCollection;
    }
}