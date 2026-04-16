using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on machineLogDetails.
    /// </summary>
    public interface IMachineLogDetailRepository
    { /// <summary>
      /// Retrieves machineLogDetails optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the machineLogDetail to retrieve. If not provided, retrieves all machineLogDetails.</param>
      /// <returns>
      /// The task result contains a collection of machineLogDetails if successful, or null if no machineLogDetails match the provided identifier.
      /// </returns>
        Task<IEnumerable<MachineLogDetail>> GetMachineLogDetailDetails(int? id);
        /// <summary>
        /// Inserts a new machineLogDetail.
        /// </summary>
        /// <param name="machineLogDetail">The machineLogDetail to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<MachineLogDetail> InsertMachineLogDetailDetails(MachineLogDetail machineLogDetail);
        /// <summary>
        /// Updates an existing machineLogDetail.
        /// </summary>
        /// <param name="machineLogDetail">The machineLogDetail to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateMachineLogDetailDetails(MachineLogDetail machineLogDetail);
        /// <summary>
        /// Deletes a machineLogDetail by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the machineLogDetail to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteMachineLogDetailDetails(int id);
    }
}
