using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on billings.
    /// </summary>
    public interface IBillingRepository
    { /// <summary>
      /// Retrieves billings optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the billing to retrieve. If not provided, retrieves all billings.</param>
      /// <returns>
      /// The task result contains a collection of billings if successful, or null if no billings match the provided identifier.
      /// </returns>
        Task<IEnumerable<Billings>> GetBillingsDetails(int? id);
        /// <summary>
        /// Inserts a new billing.
        /// </summary>
        /// <param name="billing">The billing to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Billings> InsertBillingDetails(Billings billing);
        /// <summary>
        /// Updates an existing billing.
        /// </summary>
        /// <param name="billing">The billing to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateBillingDetails(Billings billing);
        /// <summary>
        /// Deletes a billing by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billing to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteBillingDetails(int id);

        public string DownloadInvoice(int id);
        public string DownloadPaymentVoucher(int id); 

        public string DownloadDeliveryChallen(int id);

        Task<IEnumerable<Billings>> GetConsigneeList(string consigneeList);
    }
}
