using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on machineLogDetails.
    /// </summary>
    public interface IMachineLogDetailService
    {/// <summary>
     /// Retrieves machineLogDetails optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the machineLogDetailDto to retrieve. If not provided, retrieves all machineLogDetails.</param>
     /// <returns>
     /// The task result contains a collection of machineLogDetailDto DTOs. if successful, or null if no machineLogDetails match the provided identifier.
     /// </returns>
        Task<IEnumerable<MachineLogDetailDto>> GetMachineLogDetailDetails(int? id);
        /// <summary>
        /// Inserts a new machineLogDetailDto.
        /// </summary>
        /// <param name="machineLogDetailDto">The DTO representing the machineLogDetailDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<MachineLogDetailDto> InsertMachineLogDetailDetails(MachineLogDetailDto machineLogDetailDto);
        /// <summary>
        /// Updates an existing machineLogDetailDto.
        /// </summary>
        /// <param name="machineLogDetailDto">The DTO representing the updated machineLogDetailDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateMachineLogDetailDetails(MachineLogDetailDto machineLogDetailDto);
        /// <summary>
        /// Deletes a machineLogDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the machineLogDetailDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteMachineLogDetailDetails(int id);
    }
}
