using ConstructionBilling.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for retrieving materialHistorys.
    /// </summary>
    public interface IMaterialHistoryService
    {
        /// <summary>
        /// Retrieves materialHistorys optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the materialHistory to retrieve. If not provided, retrieves all materialHistorys.</param>
        /// <returns>
        /// The task result contains a collection of MaterialHistoryDto DTOs if successful, or an empty collection if no materialHistorys match the provided identifier.
        /// </returns>
        Task<IEnumerable<MaterialHistoryDto>> GetMaterialHistory(int? id);
    }
}
