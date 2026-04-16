using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Domain.Entities
{
    public class MachineLogDetail

    {

        /// <summary>
        /// Gets or sets the identifier for the machine log.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the date of the log entry.
        /// </summary>
        [JsonPropertyName("logDate")]
        public DateTime LogDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the start time of the working session.
        /// </summary>
        [JsonPropertyName("startTime")]
        public TimeSpan StartTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Gets or sets the stop time of the working session.
        /// </summary>
        [JsonPropertyName("stopTime")]
        public TimeSpan StopTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Gets or sets the total working time of the session.
        /// </summary>
        [JsonPropertyName("totalWorkingTime")]
        public TimeSpan TotalWorkingTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Gets or sets the electric meter reading.
        /// </summary>
        [JsonPropertyName("eBMeterStartReading")]
        public string EBMeterStartReading { get; set; } = string.Empty;

       
        /// <summary>
        /// Gets or sets the electric meter reading.
        /// </summary>
        [JsonPropertyName("eBMeterEndReading")]
        public string EBMeterEndReading { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total EB units used today.
        /// </summary>
        [JsonPropertyName("totalEBUnitsUsedToday")]
        public decimal TotalEBUnitsUsedToday { get; set; } = 0;

        /// <summary>
        /// Gets or sets the material data.
        /// </summary>
        [JsonPropertyName("materialData")]
        public string MaterialData { get; set; } = string.Empty;

       
        /// <summary>
        /// Gets or sets the number of bricks casted.
        /// </summary>
        [JsonPropertyName("pressingCount")]
        public int PressingCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the average weight of bricks.
        /// </summary>
        [JsonPropertyName("averageWeightOfBricks")]
        public decimal AverageWeightOfBricks { get; set; }

        /// <summary>

        /// Gets or sets the total number of bricks casted.

        /// Gets or sets the  number of mixture casted.

        /// </summary>
        [JsonPropertyName("noOfMixtures")]
        public int NoOfMixtures { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total number of bricks casted.
        /// </summary>
        [JsonPropertyName("totalBricksCount")]
        public int TotalBricksCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the number of damaged bricks.
        /// </summary>
        [JsonPropertyName("damagedBricksCount")]
        public int DamagedBricksCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the actual number of bricks casted.
        /// </summary>
        [JsonPropertyName("actualBricksCount")]
        public int ActualBricksCount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the reason for damage.
        /// </summary>
        [JsonPropertyName("reasonForDamage")]
        public string ReasonForDamage { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the reason for shutdown.
        /// </summary>
        [JsonPropertyName("reasonForShutdown")]
        public string ReasonForShutdown { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets who created the entry.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date the entry was created.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets who last modified the entry.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } = null;

        /// <summary>
        /// Gets or sets the date the entry was last modified.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; } = null;

    }

}

