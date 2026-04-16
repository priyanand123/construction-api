using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on roles.
    /// </summary>
    public interface IRoleService
    {/// <summary>
     /// Retrieves roles optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the roleDto to retrieve. If not provided, retrieves all roles.</param>
     /// <returns>
     /// The task result contains a collection of roleDto DTOs. if successful, or null if no roles match the provided identifier.
     /// </returns>
        Task<IEnumerable<RoleDto>> GetRolesDetails(int? id);
        /// <summary>
        /// Inserts a new roleDto.
        /// </summary>
        /// <param name="roleDto">The DTO representing the roleDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<RoleDto> InsertRoleDetails(RoleDto roleDto);
        /// <summary>
        /// Updates an existing roleDto.
        /// </summary>
        /// <param name="roleDto">The DTO representing the updated roleDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateRoleDetails(RoleDto roleDto);
        /// <summary>
        /// Deletes a roleDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the roleDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteRoleDetails(int id);
    }
}
