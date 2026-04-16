using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class Labour
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0; // Default value is 0 for integers

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty; // Default to an empty string

        [JsonPropertyName("userId")]
        public int UserId { get; set; } = 0; // Default value is 0

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; } = 0; // Default value is 0 for RoleId (Foreign Key)

        [JsonPropertyName("roleName")]
        public string RoleName { get; set; } = string.Empty; // Default to an empty string

        [JsonPropertyName("qualification")]
        public string? Qualification { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("aadharNo")]
        public string? AadharNo { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("labourType")]
        public string? LabourType { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("mobileNo")]
        public string? MobileNo { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("panNo")]
        public string? PanNo { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("emergencyNo")]
        public string? EmergencyNo { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("address")]
        public string? Address { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty; // Default to an empty string

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty; // Default to an empty string

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty; // Default to an empty string

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Default to current UTC time

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } = string.Empty; // Nullable, default to string.Empty

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = DateTime.UtcNow; // Nullable, default to string.Empty
    }


}
