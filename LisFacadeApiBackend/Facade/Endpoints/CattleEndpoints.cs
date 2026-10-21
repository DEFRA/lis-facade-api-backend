using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using LisFacadeApiBackend.Facade.LIS.Animal;
using LisFacadeApiBackend.Facade.LIS.Error;
using LisFacadeApiBackend.Facade.Handlers.Cattle.Animal;

namespace LisFacadeApiBackend.Facade.Endpoints;

[ExcludeFromCodeCoverage]
public static class CattleEndpoints
{
    public static RouteGroupBuilder MapCattleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/animals")
            .WithTags("Animals");

        group.MapGet("/{identifier}", GetAnimalByIdentifier)
            .WithName("GetByIdentifier")
            .Produces<AnimalRecordDetails>(StatusCodes.Status200OK)
            .Produces<LisErrors>(StatusCodes.Status403Forbidden)
            .Produces<LisErrors>(StatusCodes.Status404NotFound)
            .Produces<LisErrors>(StatusCodes.Status500InternalServerError)
            .Produces<LisErrors>(StatusCodes.Status503ServiceUnavailable);

        return group;
    }

    private sealed class EndpointLogCategory;

    private static async Task<IResult> GetAnimalByIdentifier(
        [FromRoute] string identifier,
        [FromServices] GetAnimalByIdentifierHandler getAnimalHandler,
        ILogger<EndpointLogCategory> logger,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("GET /animals/{Identifier} received", identifier);
        var result = await getAnimalHandler.Handle(identifier, cancellationToken);
        if (result is null)
        {
            logger.LogWarning("Animal {Identifier} not found, returning 404", identifier);
            return TypedResults.Json
            (
                new LisProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.5",
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not found",
                    Detail = "The requested resource was not found"
                }, 
                statusCode: StatusCodes.Status404NotFound);
        }

        logger.LogInformation("Returning animal with identifier {Identifier}", identifier);
        return TypedResults.Ok(result);
    }
}