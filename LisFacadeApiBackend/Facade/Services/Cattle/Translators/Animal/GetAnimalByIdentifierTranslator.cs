using LisFacadeApiBackend.Facade.LIS.Animal;
using LisFacadeApiBackend.Facade.LIS.Enums;
using LisFacadeApiBackend.Facade.Services.Cattle.EndpointServices;

namespace LisFacadeApiBackend.Facade.Services.Cattle.Translators.Animal;

public class GetAnimalByIdentifierTranslator(
    GetAnimalByIdentifierService animalService,
    ILogger<GetAnimalByIdentifierTranslator> logger)
    : ITranslator<string, AnimalRecordDetails?>
{
    public async Task<AnimalRecordDetails?> Translate(string inboundRequest, CancellationToken cancellationToken)
    {
        /* 
        TODO: Translate the request type
        Call the animal service with the translated request
        Translate response to response type and return
        */

        // Temporary hardcoded data until the cattle response mapping is implemented
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

        await animalService.GetAnimalByIdentifierAsync("UK12345678901", cancellationToken);

        logger.LogInformation("Returning placeholder response for cattle with identifier {CattleIdentifier}, " +
            "this will be replaced with actual data once the translation is completed", "UK12345678901");
        return placeholderResponse;
    }
}
