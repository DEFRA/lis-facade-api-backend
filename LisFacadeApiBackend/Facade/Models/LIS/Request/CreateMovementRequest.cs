using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LisMovementModel = LisFacadeApiBackend.Facade.LIS.Movement.Movement;

namespace LisFacadeApiBackend.Facade.LIS.Request;

public sealed class CreateMovementRequest
{
    [JsonPropertyName("movementData")]
    public required LisMovementModel MovementData { get; init; }

    [JsonPropertyName("document")]
    public DocumentRequest? Document { get; init; }
}

public sealed class DocumentRequest
{
    [JsonPropertyName("fileName")]
    public string? FileName { get; init; }

    [JsonPropertyName("documentContent")]
    [MaxLength(5_242_880)]
    public byte[]? DocumentContent { get; init; }
}