using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos;

public class RawMaterialDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; } = 0;

    [JsonPropertyName("unitId")]
    public long UnitId { get; set; } = 0;

    [JsonPropertyName("unit")]
    public string Unit { get; set; } = string.Empty;

    [JsonPropertyName("materialName")]
    public string MaterialName { get; set; } = string.Empty;

    [JsonPropertyName("isManufacturingMaterial")]
    public bool? IsManufacturingMaterial { get; set; }

    [JsonPropertyName("createdBy")]
    public string CreatedBy { get; set; } = string.Empty;

    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("modifiedDate")]
    public DateTime? ModifiedDate { get; set; } // Nullable if it can be null
}
