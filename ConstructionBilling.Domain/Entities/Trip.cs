using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class Trip
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("startMeterReading")]
        public double StartMeterReading { get; set; } 

        [JsonPropertyName("endMeterReading")]
        public double EndMeterReading { get; set; } 

        [JsonPropertyName("totalUsedMeterReading")]
        public double TotalUsedMeterReading { get; set; } 

        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("personName")]
        public string PersonName { get; set; } = string.Empty;

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
