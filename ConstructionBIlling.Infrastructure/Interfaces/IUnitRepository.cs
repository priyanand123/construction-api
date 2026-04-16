using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on units.
    /// </summary>
    public interface IUnitRepository
    { /// <summary>
      /// Retrieves units optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the unit to retrieve. If not provided, retrieves all units.</param>
      /// <returns>
      /// The task result contains a collection of units if successful, or null if no units match the provided identifier.
      /// </returns>
        Task<IEnumerable<Units>> GetUnitsDetails(int? id);
        /// <summary>
        /// Inserts a new unit.
        /// </summary>
        /// <param name="unit">The unit to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Units> InsertUnitDetails(Units unit);
        /// <summary>
        /// Updates an existing unit.
        /// </summary>
        /// <param name="unit">The unit to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateUnitDetails(Units unit);
        /// <summary>
        /// Deletes a unit by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the unit to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteUnitDetails(int id);
    }
}
