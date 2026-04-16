using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on labours.
    /// </summary>
    public interface IPurchaseDetailRepository
    { /// <summary>
      /// Retrieves labours optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the labour to retrieve. If not provided, retrieves all labours.</param>
      /// <returns>
      /// The task result contains a collection of labours if successful, or null if no labours match the provided identifier.
      /// </returns>
        Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsDetails(int? id);
        /// <summary>
        /// Inserts a new labour.
        /// </summary>
        /// <param name="labour">The labour to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<PurchaseDetail> InsertPurchaseDetailDetails(PurchaseDetail labour);
        /// <summary>
        /// Updates an existing labour.
        /// </summary>
        /// <param name="labour">The labour to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdatePurchaseDetailDetails(PurchaseDetail labour);
        /// <summary>
        /// Deletes a labour by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the labour to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeletePurchaseDetailDetails(int id);
        Task<IEnumerable<PurchaseDetail>> GetPurchaseCompanList(string purchaseCompany);
    }
}
