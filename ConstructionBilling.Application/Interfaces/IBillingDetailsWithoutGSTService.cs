using ConstructionBilling.Application.Dtos;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for retrieving machineLogDetails.
    /// </summary>
    public interface IBillingDetailsWithoutGSTService
    {
        /// <summary>
        /// Retrieves machineLogDetails optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the machineLogDetailDto to retrieve. If not provided, retrieves all machineLogDetails.</param>
        /// <returns>
        /// The task result contains a collection of machineLogDetailDto DTOs, if successful, or null if no machineLogDetails match the provided identifier.
        /// </returns>
        Task<IEnumerable<BillingDetailsWithoutGSTDto>> GetBillingDetailsWithoutGSTDetails(int? id);
        public string DownloadInvoice(int id);
    }
}
