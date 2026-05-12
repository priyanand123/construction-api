using System;
using System.Text.Json.Serialization;

namespace ConstructionBilling.Application.Dtos
{
    public class BillingDetailsWithoutGSTDto
    {
        /// <summary>
        /// Gets or sets the identifier for the billing details.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the consignee details.
        /// </summary>
        [JsonPropertyName("consigneeDetails")]
        public string ConsigneeDetails { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the GSTIN Number.
        /// </summary>
        [JsonPropertyName("buyer")]
        public string Buyer { get; set; } = string.Empty;

        [JsonPropertyName("companyGstNo")]
        public string companyGstNo { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the GST data ID.
        /// </summary>
        [JsonPropertyName("withGstDataId")]
        public int WithGstDataId { get; set; }

        /// <summary>
        /// Gets or sets the dispatch document number.
        /// </summary>
        [JsonPropertyName("dispatchDocNo")]
        public string DispatchDocNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery note date.
        /// </summary>
        [JsonPropertyName("deliveryNoteDate")]
        public DateTime DeliveryNoteDate { get; set; }

        /// <summary>
        /// Gets or sets the dispatched through details.
        /// </summary>
        [JsonPropertyName("dispatchedThrough")]
        public string DispatchedThrough { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the destination of the goods.
        /// </summary>
        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Bill of Lading or LRRR number.
        /// </summary>
        [JsonPropertyName("billOfLadingLrrrNo")]
        public string BillOfLading_LRRRNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HSN or SAC code.
        /// </summary>
        [JsonPropertyName("hsnOrSac")]
        public int HSNorSAC { get; set; } = 0;

        /// <summary>
        /// Gets or sets the total quantity of goods.
        /// </summary>
        [JsonPropertyName("totalQty")]
        public decimal TotalQty { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the billing.
        /// </summary>
        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount in words.
        /// </summary>
        [JsonPropertyName("totalAmountInWords")]
        public string TotalAmountInWords { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the motor vehicle number used for transportation.
        /// </summary>
        [JsonPropertyName("motorVehicleNo")]
        public string MotorVehicleNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the terms of delivery.
        /// </summary>
        [JsonPropertyName("termsOfDelivery")]
        public string TermsOfDelivery { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the goods information.
        /// </summary>
        [JsonPropertyName("goodsInformation")]
        public string GoodsInformation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery man's name.
        /// </summary>
        [JsonPropertyName("deliveryManName")]
        public string DeliveryManName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the delivery man's phone number.
        /// </summary>
        [JsonPropertyName("deliveryManPhoneNo")]
        public string DeliveryManPhoneNo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the created by user.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the modified by user.
        /// </summary>
        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; } // Nullable if it can be null

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }
    }
}
