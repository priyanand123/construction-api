using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on trips.
    /// </summary>
    public interface ITripService
    {/// <summary>
     /// Retrieves trips optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the tripDto to retrieve. If not provided, retrieves all trips.</param>
     /// <returns>
     /// The task result contains a collection of tripDto DTOs. if successful, or null if no trips match the provided identifier.
     /// </returns>
        Task<IEnumerable<TripDto>> GetTripsDetails(int? id);
        /// <summary>
        /// Inserts a new tripDto.
        /// </summary>
        /// <param name="tripDto">The DTO representing the tripDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<TripDto> InsertTripDetails(TripDto tripDto);
        /// <summary>
        /// Updates an existing tripDto.
        /// </summary>
        /// <param name="tripDto">The DTO representing the updated tripDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateTripDetails(TripDto tripDto);
        /// <summary>
        /// Deletes a tripDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tripDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteTripDetails(int id);
    }
}
