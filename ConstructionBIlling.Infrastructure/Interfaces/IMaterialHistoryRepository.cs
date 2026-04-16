using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for retrieving material history details.
    /// </summary>
    public interface IMaterialHistoryRepository
    {
        /// <summary>
        /// Retrieves material histories optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the material history to retrieve. If not provided, retrieves all.</param>
        /// <returns>
        /// The task result contains a collection of material histories if successful, or null if no matches found.
        /// </returns>
        Task<IEnumerable<MaterialHistory>> GetMaterialHistory(int? id);
    }
}
