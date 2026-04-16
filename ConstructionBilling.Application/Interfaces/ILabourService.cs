using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on labours.
    /// </summary>
    public interface ILabourService
    {/// <summary>
     /// Retrieves labours optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the labourDto to retrieve. If not provided, retrieves all labours.</param>
     /// <returns>
     /// The task result contains a collection of labourDto DTOs. if successful, or null if no labours match the provided identifier.
     /// </returns>
        Task<IEnumerable<LabourDto>> GetLaboursDetails(int? id);
        /// <summary>
        /// Inserts a new labourDto.
        /// </summary>
        /// <param name="labourDto">The DTO representing the labourDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<LabourDto> InsertLabourDetails(LabourDto labourDto);
        /// <summary>
        /// Updates an existing labourDto.
        /// </summary>
        /// <param name="labourDto">The DTO representing the updated labourDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateLabourDetails(LabourDto labourDto);
        /// <summary>
        /// Deletes a labourDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the labourDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteLabourDetails(int id);
    }
}
