using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on purchaseDetails.
    /// </summary>
    public interface IPurchaseDetailService
    {/// <summary>
     /// Retrieves purchaseDetails optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the purchaseDetailDto to retrieve. If not provided, retrieves all purchaseDetails.</param>
     /// <returns>
     /// The task result contains a collection of purchaseDetailDto DTOs. if successful, or null if no purchaseDetails match the provided identifier.
     /// </returns>
        Task<IEnumerable<PurchaseDetailDto>> GetPurchaseDetailsDetails(int? id);
        /// <summary>
        /// Inserts a new purchaseDetailDto.
        /// </summary>
        /// <param name="purchaseDetailDto">The DTO representing the purchaseDetailDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<PurchaseDetailDto> InsertPurchaseDetailDetails(PurchaseDetailDto purchaseDetailDto);
        /// <summary>
        /// Updates an existing purchaseDetailDto.
        /// </summary>
        /// <param name="purchaseDetailDto">The DTO representing the updated purchaseDetailDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdatePurchaseDetailDetails(PurchaseDetailDto purchaseDetailDto);
        /// <summary>
        /// Deletes a purchaseDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the purchaseDetailDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeletePurchaseDetailDetails(int id);
        Task<IEnumerable<PurchaseDetailDto>> GetPurchaseCompanList(string purchaseCompany);
    }
}
