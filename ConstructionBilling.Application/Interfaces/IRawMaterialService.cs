using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on RawMaterials.
    /// </summary>
    public interface IRawMaterialService
    {/// <summary>
     /// Retrieves RawMaterials optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the RawMaterialDto to retrieve. If not provided, retrieves all RawMaterials.</param>
     /// <returns>
     /// The task result contains a collection of RawMaterialDto DTOs. if successful, or null if no RawMaterials match the provided identifier.
     /// </returns>
        Task<IEnumerable<RawMaterialDto>> GetRawMaterialsDetails(int? id);
        /// <summary>
        /// Inserts a new RawMaterialDto.
        /// </summary>
        /// <param name="RawMaterialDto">The DTO representing the RawMaterialDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<RawMaterialDto> InsertRawMaterialDetails(RawMaterialDto rawMaterialDto);
        /// <summary>
        /// Updates an existing RawMaterialDto.
        /// </summary>
        /// <param name="RawMaterialDto">The DTO representing the updated RawMaterialDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateRawMaterialDetails(RawMaterialDto rawMaterialDto);
        /// <summary>
        /// Deletes a RawMaterialDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the RawMaterialDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteRawMaterialDetails(int id);
    }
}
