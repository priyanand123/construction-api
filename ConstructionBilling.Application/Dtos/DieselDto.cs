using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class DieselDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("day")]
        public string Day { get; set; } = string.Empty;

        [JsonPropertyName("dieselAmount")]
        public decimal DieselAmount { get; set; }

        [JsonPropertyName("liters")]
        public decimal Liters { get; set; } = 0;

        [JsonPropertyName("personName")]
        public string PersonName { get; set; } = string.Empty;

        [JsonPropertyName("maintenanceCost")]
        public decimal? MaintenanceCost { get; set; } // Nullable as it is optional

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
