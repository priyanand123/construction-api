using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on materials.
    /// </summary>
    public interface IRawMaterialRepository
    { /// <summary>
      /// Retrieves materials optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the material to retrieve. If not provided, retrieves all materials.</param>
      /// <returns>
      /// The task result contains a collection of materials if successful, or null if no materials match the provided identifier.
      /// </returns>
        Task<IEnumerable<RawMaterial>> GetRawMaterialsDetails(int? id);
        /// <summary>
        /// Inserts a new material.
        /// </summary>
        /// <param name="material">The material to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<IEnumerable<RawMaterial>> InsertRawMaterialDetails(RawMaterial material);
        /// <summary>
        /// Updates an existing material.
        /// </summary>
        /// <param name="material">The material to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateRawMaterialDetails(RawMaterial material);
        /// <summary>
        /// Deletes a material by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the material to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteRawMaterialDetails(int id);
    }
}
