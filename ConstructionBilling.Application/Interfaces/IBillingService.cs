using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on billings.
    /// </summary>
    public interface IBillingService
    {/// <summary>
     /// Retrieves billings optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the billingDto to retrieve. If not provided, retrieves all billings.</param>
     /// <returns>
     /// The task result contains a collection of billingDto DTOs. if successful, or null if no billings match the provided identifier.
     /// </returns>
        Task<IEnumerable<BillingDto>> GetBillingsDetails(int? id);
        /// <summary>
        /// Inserts a new billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the billingDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<BillingDto> InsertBillingDetails(BillingDto billingDto);

        /// <summary>
        /// Updates an existing billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the updated billingDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateBillingDetails(BillingDto billingDto);
        /// <summary>
        /// Deletes a billingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteBillingDetails(int id);
        public string DownloadInvoice(int id);
        public string DownloadPaymentVoucher(int id);
        public string DownloadDeliveryChallen(int id);
        Task<IEnumerable<BillingDto>> GetConsigneeList(string consigneeList);

    }
}
