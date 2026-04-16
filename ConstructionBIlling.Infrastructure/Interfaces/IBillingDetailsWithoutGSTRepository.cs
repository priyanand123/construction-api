using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing operations on billingDetailsWithoutGSTDetails.
    /// </summary>
    public interface IBillingDetailsWithoutGSTRepository
    {
        /// <summary>
        /// Retrieves billingDetailsWithoutGSTDetails optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the billingDetailsWithoutGSTDetail to retrieve. If not provided, retrieves all billingDetailsWithoutGSTDetails.</param>
        /// <returns>
        /// The task result contains a collection of billingDetailsWithoutGSTDetails if successful, or null if no billingDetailsWithoutGSTDetails match the provided identifier.
        /// </returns>
        Task<IEnumerable<BillingDetailsWithoutGST>> GetBillingDetailsWithoutGSTDetails(int? id);
        Task GetBillingDetailsWithoutGST(int? id);
        public string DownloadInvoice(int id);
    }
}
