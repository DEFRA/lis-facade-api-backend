using System.Text.Json.Serialization;
using LisFacadeApiBackend.Facade.LIS.Enums;

namespace LisFacadeApiBackend.Facade.LIS.Common;

public sealed class MovementBatch
{
    [JsonPropertyName("species")]
    public required Species Species { get; init; }

    [JsonPropertyName("animals")]
    public List<BatchAnimal>? Animals { get; init; }
}

public abstract class BatchAnimal
{
}

public sealed class IdentifiedBatchAnimal : BatchAnimal
{
    [JsonPropertyName("animalIdentifier")]
    public required string AnimalIdentifier { get; init; }
}

public sealed class MarkedBatchAnimal : BatchAnimal
{
    [JsonPropertyName("mark")]
    public string? Mark { get; init; }

    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }
}