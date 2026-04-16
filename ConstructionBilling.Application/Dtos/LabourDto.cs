using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class LabourDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; } = string.Empty;

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; } = 0; // Foreign Key (RoleId)

        [JsonPropertyName("userId")]
        public int UserId { get; set; } = 0; // Foreign Key (RoleId)

        [JsonPropertyName("qualification")]
        public string? Qualification { get; set; } = string.Empty; // Nullable if it can be string.Empty

        [JsonPropertyName("aadharNo")]
        public string? AadharNo { get; set; } = string.Empty; // Nullable if it can be string.Empty

        [JsonPropertyName("labourType")]
        public string? LabourType { get; set; } = string.Empty; // Nullable if it can be string.Empty

        [JsonPropertyName("mobileNo")]
        public string? MobileNo { get; set; } = string.Empty;

        [JsonPropertyName("panNo")]
        public string? PanNo { get; set; } = string.Empty;

        [JsonPropertyName("emergencyNo")]
        public string? EmergencyNo { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string? Address { get; set; } = string.Empty;

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } = string.Empty; // Nullable if it can be string.Empty

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }

}
