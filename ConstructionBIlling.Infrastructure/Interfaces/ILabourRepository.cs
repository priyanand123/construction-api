using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on labours.
    /// </summary>
    public interface ILabourRepository
    { /// <summary>
      /// Retrieves labours optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the labour to retrieve. If not provided, retrieves all labours.</param>
      /// <returns>
      /// The task result contains a collection of labours if successful, or null if no labours match the provided identifier.
      /// </returns>
        Task<IEnumerable<Labour>> GetLaboursDetails(int? id);
        /// <summary>
        /// Inserts a new labour.
        /// </summary>
        /// <param name="labour">The labour to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Labour> InsertLabourDetails(Labour labour);
        /// <summary>
        /// Updates an existing labour.
        /// </summary>
        /// <param name="labour">The labour to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateLabourDetails(Labour labour);
        /// <summary>
        /// Deletes a labour by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the labour to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteLabourDetails(int id);
        /// <summary>
        /// reset a labour password.
        /// </summary>
        /// <param name="username">The username of the labour to update.</param>
        /// <param name="password">The password of the labour to update.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task  ResetPasswordAsync(int id,string username, string newPassword,string modifiedBy);
    }
}
