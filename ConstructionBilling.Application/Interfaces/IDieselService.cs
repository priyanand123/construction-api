using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on diesels.
    /// </summary>
    public interface IDieselService
    {/// <summary>
     /// Retrieves diesels optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the dieselDto to retrieve. If not provided, retrieves all diesels.</param>
     /// <returns>
     /// The task result contains a collection of dieselDto DTOs. if successful, or null if no diesels match the provided identifier.
     /// </returns>
        Task<IEnumerable<DieselDto>> GetDieselsDetails(int? id);
        /// <summary>
        /// Inserts a new dieselDto.
        /// </summary>
        /// <param name="dieselDto">The DTO representing the dieselDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<DieselDto> InsertDieselDetails(DieselDto dieselDto);
        /// <summary>
        /// Updates an existing dieselDto.
        /// </summary>
        /// <param name="dieselDto">The DTO representing the updated dieselDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateDieselDetails(DieselDto dieselDto);
        /// <summary>
        /// Deletes a dieselDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the dieselDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteDieselDetails(int id);
    }
}
