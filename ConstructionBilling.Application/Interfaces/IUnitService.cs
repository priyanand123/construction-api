using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on units.
    /// </summary>
    public interface IUnitService
    {/// <summary>
     /// Retrieves units optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the unitDto to retrieve. If not provided, retrieves all units.</param>
     /// <returns>
     /// The task result contains a collection of unitDto DTOs. if successful, or null if no units match the provided identifier.
     /// </returns>
        Task<IEnumerable<UnitDto>> GetUnitsDetails(int? id);
        /// <summary>
        /// Inserts a new unitDto.
        /// </summary>
        /// <param name="unitDto">The DTO representing the unitDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<UnitDto> InsertUnitDetails(UnitDto unitDto);
        /// <summary>
        /// Updates an existing unitDto.
        /// </summary>
        /// <param name="unitDto">The DTO representing the updated unitDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateUnitDetails(UnitDto unitDto);
        /// <summary>
        /// Deletes a unitDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the unitDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteUnitDetails(int id);
    }
}
