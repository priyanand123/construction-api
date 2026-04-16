using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConstructionBilling.Application.Dtos
{
    public class BillingDto
    { /// <summary>
            /// Gets or sets the unique identifier for the invoice.
            /// </summary>
            [JsonPropertyName("id")]
            public int Id { get; set; } = 0;

            /// <summary>
            /// Gets or sets the consignee details.
            /// </summary>
            [JsonPropertyName("consigneeDetails")]
            public string ConsigneeDetails { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the invoice number.
            /// </summary>
            [JsonPropertyName("invoiceNo")]
            public string InvoiceNo { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the invoice date.
            /// </summary>
            [JsonPropertyName("dated")]
            public DateTime Dated { get; set; } = DateTime.MinValue;

            /// <summary>
            /// Gets or sets the delivery note.
            /// </summary>
            [JsonPropertyName("deliveryNote")]
            public string DeliveryNote { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the mode/terms of payment.
            /// </summary>
            [JsonPropertyName("modeTermsOfPayment")]
            public string ModeTermsOfPayment { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the reference number.
            /// </summary>
            [JsonPropertyName("referenceNo")]
            public string ReferenceNo { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the reference date.
            /// </summary>
            [JsonPropertyName("referenceDate")]
            public DateTime? ReferenceDate { get; set; } = null;

            /// <summary>
            /// Gets or sets the other references.
            /// </summary>
            [JsonPropertyName("otherReferences")]
            public string OtherReferences { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the buyer's order number.
            /// </summary>
            [JsonPropertyName("buyersOrderNo")]
            public string BuyersOrderNo { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the buyer's order date.
            /// </summary>
            [JsonPropertyName("buyersOrderNoDated")]
            public DateTime? BuyersOrderNoDated { get; set; } = null;

            /// <summary>
            /// Gets or sets the dispatch document number.
            /// </summary>
            [JsonPropertyName("dispatchDocNo")]
            public string DispatchDocNo { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the delivery note date.
            /// </summary>
            [JsonPropertyName("deliveryNoteDate")]
            public DateTime? DeliveryNoteDate { get; set; } = null;

            /// <summary>
            /// Gets or sets the dispatched through information.
            /// </summary>
            [JsonPropertyName("dispatchedThrough")]
            public string DispatchedThrough { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the destination.
            /// </summary>
            [JsonPropertyName("destination")]
            public string Destination { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the bill of lading or LR/RR number.
            /// </summary>
            [JsonPropertyName("billOfLadingLrRrNo")]
            public string BillOfLading_LRRRNo { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the GSTIN Number.
        /// </summary>
        [JsonPropertyName("companyGstNo")]
        public string companyGstNo { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the HSN or SAC code.
        /// </summary>
        [JsonPropertyName("hsnOrSac")]
            public string HSNorSAC { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the total quantity.
            /// </summary>
            [JsonPropertyName("totalQty")]
            public int TotalQty { get; set; } = 0;

            /// <summary>
            /// Gets or sets the total amount.
            /// </summary>
            [JsonPropertyName("totalAmount")]
            public decimal TotalAmount { get; set; } = 0.0m;

            /// <summary>
            /// Gets or sets the tax amount in words.
            /// </summary>
            [JsonPropertyName("taxAmountInWords")]
            public string TaxAmountInWords { get; set; } = string.Empty;
            /// <summary>
            /// Gets or sets the tax amount in words.
            /// </summary>
            [JsonPropertyName("totalTaxAmountInWords")]
            public string TotalTaxAmountInWords { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the total amount in words.
        /// </summary>
        [JsonPropertyName("totalAmountInWords")]
            public string TotalAmountInWords { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the CGST amount.
            /// </summary>
            [JsonPropertyName("cgstAmount")]
            public decimal CGSTAmount { get; set; } = 0.0m;

            /// <summary>
            /// Gets or sets the SGST amount.
            /// </summary>
            [JsonPropertyName("sgstAmount")]
            public decimal SGSTAmount { get; set; } = 0.0m;

            /// <summary>
            /// Gets or sets the taxable value.
            /// </summary>
            [JsonPropertyName("taxableValue")]
            public decimal TaxableValue { get; set; } = 0.0m;

            /// <summary>
            /// Gets or sets the total tax amount.
            /// </summary>
            [JsonPropertyName("totalTaxAmount")]
            public decimal TotalTaxAmount { get; set; } = 0.0m;

            /// <summary>
            /// Gets or sets the motor vehicle number.
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
        /// Gets or sets the name of the user who created the record.
        /// </summary>
        [JsonPropertyName("createdBy")]
            public string CreatedBy { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the record creation date and time.
            /// </summary>
            [JsonPropertyName("createdDate")]
            public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

            /// <summary>
            /// Gets or sets the name of the user who last modified the record.
            /// </summary>
            [JsonPropertyName("modifiedBy")]
            public string ModifiedBy { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the record modification date and time.
            /// </summary>
            [JsonPropertyName("modifiedDate")]
            public DateTime? ModifiedDate { get; set; } = null;
        
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

        [JsonPropertyName("cgst")]
        public decimal CGST { get; set; } = 0;

        [JsonPropertyName("sgst")]
        public decimal SGST { get; set; } = 0;

        [JsonPropertyName("isGSTInclude")]
        public int IsGSTInclude { get; set; }
    }
}
