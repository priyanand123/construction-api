using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on companyDetailss.
    /// </summary>
    public class CompanyDetailsService : ICompanyDetailsService
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="companyDetailsService"/> class.
        /// </summary>
        /// <param name="companyDetailsRepository">The repository for accessing companyDetailsDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public CompanyDetailsService(ICompanyDetailsRepository companyDetailsRepository, IMapper mapper)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<CompanyDetailsDto>> GetCompanyDetails(int? id)
        {
            var companyDetailss = await _companyDetailsRepository.GetCompanyDetails(id);

            var companyDetailsDetails = _mapper.Map<IEnumerable<CompanyDetailsDto>>(companyDetailss);
            return companyDetailsDetails;
        }
        /// <inheritdoc/>
        public async Task UpdateCompanyDetails(CompanyDetailsDto companyDetailsDto)
        {
            var companyDetails = _mapper.Map<CompanyDetails>(companyDetailsDto);
            await _companyDetailsRepository.UpdateCompanyDetails(companyDetails);
        }
    }
}