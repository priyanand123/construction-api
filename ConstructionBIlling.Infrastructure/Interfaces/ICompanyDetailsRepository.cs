using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for retrieving purchase details.
    /// </summary>
    public interface ICompanyDetailsRepository
    {
        /// <summary>
        /// Retrieves purchase details optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the purchase detail to retrieve. If not provided, retrieves all purchase details.</param>
        /// <returns>
        /// The task result contains a collection of purchase details if successful, or an empty collection if no matching records are found.
        /// </returns>
        Task<IEnumerable<CompanyDetails>> GetCompanyDetails(int? id);
        /// <summary>
        /// Updates an existing labour.
        /// </summary>
        /// <param name="labour">The labour to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateCompanyDetails(CompanyDetails companyDetails);

    }
}
