using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class CompanyDetailsDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the invoice.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;
        [JsonPropertyName("hsnsac")]
        public int HsnSac { get; set; } = 0;
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("manufacturersOf")]
        public string Manufacturersof { get; set; } = string.Empty;

        [JsonPropertyName("mobileNo1")]
        public string MobileNo1 { get; set; } = string.Empty;

        [JsonPropertyName("mobileNo2")]
        public string MobileNo2 { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("website")]
        public string Website { get; set; } = string.Empty;

        [JsonPropertyName("gstin")]
        public string GSTIN { get; set; } = string.Empty;

        [JsonPropertyName("bankName")]
        public string BankName { get; set; } = string.Empty;

        [JsonPropertyName("accountHolderName")]
        public string AccountHolderName { get; set; } = string.Empty;

        [JsonPropertyName("accountNo")]
        public string AccountNo { get; set; } = string.Empty;

        [JsonPropertyName("branch")]
        public string Branch { get; set; } = string.Empty;

        [JsonPropertyName("ifseCode")]
        public string IFSECode { get; set; } = string.Empty;

        [JsonPropertyName("upiId1")]
        public string UpiId1 { get; set; } = string.Empty;

        [JsonPropertyName("upiId2")]
        public string UpiId2 { get; set; } = string.Empty;

        [JsonPropertyName("cgstPercentage")]
        public decimal CGSTPercentage { get; set; } = 0;

        [JsonPropertyName("sgstOrUtgstPercentage")]
        public decimal SGSTorUTGSTPercentage { get; set; } = 0;

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the record creation date and time.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the record modification date and time.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = null;
    }
}
