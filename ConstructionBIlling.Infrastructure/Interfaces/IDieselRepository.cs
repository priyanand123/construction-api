using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on diesels.
    /// </summary>
    public interface IDieselRepository
    { /// <summary>
      /// Retrieves diesels optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the diesel to retrieve. If not provided, retrieves all diesels.</param>
      /// <returns>
      /// The task result contains a collection of diesels if successful, or null if no diesels match the provided identifier.
      /// </returns>
        Task<IEnumerable<Diesel>> GetDieselsDetails(int? id);
        /// <summary>
        /// Inserts a new diesel.
        /// </summary>
        /// <param name="diesel">The diesel to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Diesel> InsertDieselDetails(Diesel diesel);
        /// <summary>
        /// Updates an existing diesel.
        /// </summary>
        /// <param name="diesel">The diesel to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateDieselDetails(Diesel diesel);
        /// <summary>
        /// Deletes a diesel by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the diesel to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteDieselDetails(int id);
    }
}
