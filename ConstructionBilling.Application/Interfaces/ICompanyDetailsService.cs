using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on companyDetailss.
    /// </summary>
    public interface ICompanyDetailsService
    {/// <summary>
     /// Retrieves companyDetailss optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the companyDetailsDto to retrieve. If not provided, retrieves all companyDetailss.</param>
     /// <returns>
     /// The task result contains a collection of companyDetailsDto DTOs. if successful, or null if no companyDetailss match the provided identifier.
     /// </returns>
        Task<IEnumerable<CompanyDetailsDto>> GetCompanyDetails(int? id);
        /// <summary>
        /// Inserts a new companyDetailsDto.
        /// </summary>
        /// <param name="companyDetailsDto">The DTO representing the companyDetailsDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task UpdateCompanyDetails(CompanyDetailsDto companyDetailsDto);

        /// <summary>
        /// Deletes a companyDetails by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the companyDetails to delete.</param>
        /// <returns>
        /// The task result indicating whether the deletion was successful.
        /// </returns>
    }
}