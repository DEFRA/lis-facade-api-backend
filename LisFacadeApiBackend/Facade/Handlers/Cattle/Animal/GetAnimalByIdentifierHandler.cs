namespace LisFacadeApiBackend.Facade.Handlers.Cattle.Animal;

using LisFacadeApiBackend.Facade.Cattle.Response.Cattle;
using LisFacadeApiBackend.Facade.LIS.Animal;
using LisFacadeApiBackend.Facade.LIS.Enums;
using LisFacadeApiBackend.Facade.Services.Cattle.EndpointServices;
using LisFacadeApiBackend.Facade.Services.Cattle.Translators;

public class GetAnimalByIdentifierHandler(
    GetAnimalByIdentifierService animalService,
    ITranslator<string, string, CattleDetailsResponse, AnimalRecordDetails> translator,
    ILogger<GetAnimalByIdentifierHandler> logger)
    : IHandler<string, AnimalRecordDetails?>
{
    public async Task<AnimalRecordDetails?> Handle(string identifier, CancellationToken cancellationToken)
    {
        /** This implementation will be used once the translator is completed
        var cattleIdentifier = translator.ToCattleApi(identifier);
        var cattleResponse = await animalService.GetAnimalByIdentifierAsync(cattleIdentifier, cancellationToken);
        return translator.ToLisApi(cattleResponse);
        */

        // Temporary hardcoded response for testing purposes
        var placeholderResponse = new AnimalRecordDetails
        {
            Identifier = "UK12345678901",
            Species = Species.Cattle,
            Name = "Test Animal",
            Sex = Sex.Female,
            Genotype = "Holstein Friesian",
            OriginalIdentifier = "UK12345678901",
            ProductionType = ProductionType.Dairy,
            State = AnimalState.Registered
        };
        
        var cattleResponse = await animalService.GetAnimalByIdentifierAsync("UK12345678901", cancellationToken);

        logger.LogInformation("Returning placeholder response for cattle with identifier {CattleIdentifier}, " +
            "this will be replaced with actual data once the translator is completed", "UK12345678901");
        return await Task.FromResult(placeholderResponse);
    }
}