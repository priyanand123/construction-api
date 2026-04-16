using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class Units
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

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
