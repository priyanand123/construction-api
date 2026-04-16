
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class StockUpdateDto
    {
        [JsonPropertyName("bricksIdFrom")]
        public int BricksIdFrom { get; set; } = 0;
        [JsonPropertyName("bricksIdTo")]
        public int BricksIdTo { get; set; } = 0;
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; } = 0;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; } = 0;        

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } // Nullable if it can be null
    }
}
