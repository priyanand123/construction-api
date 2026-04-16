using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on trips.
    /// </summary>
    public interface ITripRepository
    { /// <summary>
      /// Retrieves trips optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the trip to retrieve. If not provided, retrieves all trips.</param>
      /// <returns>
      /// The task result contains a collection of trips if successful, or null if no trips match the provided identifier.
      /// </returns>
        Task<IEnumerable<Trip>> GetTripsDetails(int? id);
        /// <summary>
        /// Inserts a new trip.
        /// </summary>
        /// <param name="trip">The trip to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Trip> InsertTripDetails(Trip trip);
        /// <summary>
        /// Updates an existing trip.
        /// </summary>
        /// <param name="trip">The trip to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateTripDetails(Trip trip);
        /// <summary>
        /// Deletes a trip by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the trip to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteTripDetails(int id);
    }
}
