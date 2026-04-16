using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class StockDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("lastUpdatedDate")]
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("materialId")]
        public int MaterialId { get; set; } = 0;
        [JsonPropertyName("currentStocks")]
        public int CurrentStocks { get; set; } = 0;
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; } = 0;

        [JsonPropertyName("manufacturingMaterialStatus")]
        public string ManufacturingMaterialStatus { get; set; } = string.Empty;
        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; } = string.Empty;
        [JsonPropertyName("isManufacturingMaterial")]
        public bool IsManufacturingMaterial { get; set; } = false;
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } // Nullable if it can be null

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
