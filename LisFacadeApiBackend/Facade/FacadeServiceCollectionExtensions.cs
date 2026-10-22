using LisFacadeApiBackend.Facade.Services.Cattle.EndpointServices;
using LisFacadeApiBackend.Facade.Services.Cattle.Translators.Animal;

namespace LisFacadeApiBackend.Facade;

public static class FacadeServiceCollectionExtensions
{
    public static IServiceCollection AddFacadeServices(this IServiceCollection services)
    {
        services.AddTranslators();
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddTranslators(this IServiceCollection services)
    {
        services.AddTransient<GetAnimalByIdentifierTranslator>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<GetAnimalByIdentifierService>();

        return services;
    }
}
