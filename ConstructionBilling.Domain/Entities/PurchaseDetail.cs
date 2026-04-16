using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class PurchaseDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("materialId")]
        public int MaterialId { get; set; } 


        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; } = string.Empty;

        [JsonPropertyName("purchaseDate")]
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("billNo")]
        public string BillNo { get; set; } = string.Empty;

        [JsonPropertyName("billDate")]
        public DateTime BillDate { get; set; }

        [JsonPropertyName("brandName")]
        public string BrandName { get; set; } = string.Empty;

        [JsonPropertyName("gstPercentage")]
        public string GstPercentage { get; set; } = string.Empty;

        [JsonPropertyName("gstAmount")]
        public decimal GstAmount { get; set; }


        [JsonPropertyName("purchaseCompany")]
        public string PurchaseCompany { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("gstNo")]
        public string GstNo { get; set; } = string.Empty;

        [JsonPropertyName("website")]
        public string Website { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; } = string.Empty;
        [JsonPropertyName("vehicleNo")]
        public string VehicleNo { get; set; } = string.Empty;

        [JsonPropertyName("vehiclephoneNo")]
        public string VehiclePhoneNo { get; set; } = string.Empty;

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;

        [JsonPropertyName("transportDetails")]
        public string TransportDetails { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unitId")]
        public int UnitId { get; set; } // Foreign Key (UnitId)

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("loadingAndUnloadingCost")]
        public decimal LoadingAndUnloadingCost { get; set; }

        [JsonPropertyName("totalCost")]
        public decimal TotalCost { get; set; }

        [JsonPropertyName("paymentDetails")]
        public string PaymentDetails { get; set; } = string.Empty;

        [JsonPropertyName("fileName")]
        public string FileName { get; set; } = string.Empty;

        [JsonPropertyName("filePath")]
        public string FilePath { get; set; } = string.Empty;

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
