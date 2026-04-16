using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on roles.
    /// </summary>
    public interface IRoleRepository
    { /// <summary>
      /// Retrieves roles optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the role to retrieve. If not provided, retrieves all roles.</param>
      /// <returns>
      /// The task result contains a collection of roles if successful, or null if no roles match the provided identifier.
      /// </returns>
        Task<IEnumerable<Roles>> GetRolesDetails(int? id);
        /// <summary>
        /// Inserts a new role.
        /// </summary>
        /// <param name="role">The role to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<Roles> InsertRoleDetails(Roles role);
        /// <summary>
        /// Updates an existing role.
        /// </summary>
        /// <param name="role">The role to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateRoleDetails(Roles role);
        /// <summary>
        /// Deletes a role by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the role to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteRoleDetails(int id);
    }
}
