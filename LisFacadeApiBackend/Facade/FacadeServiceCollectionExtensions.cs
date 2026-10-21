using LisFacadeApiBackend.Facade.Cattle.Response.Cattle;
using LisFacadeApiBackend.Facade.Handlers.Cattle.Animal;
using LisFacadeApiBackend.Facade.LIS.Animal;
using LisFacadeApiBackend.Facade.Services.Cattle.EndpointServices;
using LisFacadeApiBackend.Facade.Services.Cattle.Translators;

namespace LisFacadeApiBackend.Facade;

public static class FacadeServiceCollectionExtensions
{
    public static IServiceCollection AddFacadeServicesAndHandlers(this IServiceCollection services)
    {
        services.AddTranslators();
        services.AddServices();
        services.AddHandlers();

        return services;
    }

    public static IServiceCollection AddTranslators(this IServiceCollection services)
    {
        services.AddSingleton<
            ITranslator<string, string, CattleDetailsResponse, AnimalRecordDetails>,
            GetAnimalByIdentifierTranslator>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<GetAnimalByIdentifierService>();

        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<GetAnimalByIdentifierHandler>();

        return services;
    }
}
