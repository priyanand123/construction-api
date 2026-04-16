using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class MaterialHistory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("materialId")]
        public int MaterialId { get; set; } = 0; 

        [JsonPropertyName("stockAddedOrUtilized")]
        public string StockAddedOrUtilized { get; set; } = string.Empty; 

        [JsonPropertyName("stockAddedOrUtilizedCount")]
        public int StockAddedOrUtilizedCount { get; set; } = 0; 

        [JsonPropertyName("unitId")]
        public int UnitId { get; set; } = 0; 

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } // Nullable if it can be null

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; } = string.Empty; 

        [JsonPropertyName("isManufacturingMaterial")]
        public bool IsManufacturingMaterial { get; set; } = false; 

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;
    }
}
