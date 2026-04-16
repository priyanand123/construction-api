using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using ConstructionBilling.Infrastructure.Repositories;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on billingDetailsWithoutGSTDetails.
    /// </summary>
    public class BillingDetailsWithoutGSTService : IBillingDetailsWithoutGSTService
    {
        private readonly IBillingDetailsWithoutGSTRepository _billingDetailsWithoutGSTRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="billingDetailsWithoutGSTService"/> class.
        /// </summary>
        /// <param name="billingDetailsWithoutGSTDetailRepository">The repository for accessing billingDetailsWithoutGSTDetailDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public BillingDetailsWithoutGSTService(IBillingDetailsWithoutGSTRepository billingDetailsWithoutGSTRepository, IMapper mapper)
        {
            _billingDetailsWithoutGSTRepository = billingDetailsWithoutGSTRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<BillingDetailsWithoutGSTDto>> GetBillingDetailsWithoutGSTDetails(int? id)
        {

            var billingDetailsWithoutGSTDetails = await _billingDetailsWithoutGSTRepository.GetBillingDetailsWithoutGSTDetails(id);

            var billingDetailsWithoutGSTDetailDetails = _mapper.Map<IEnumerable<BillingDetailsWithoutGSTDto>>(billingDetailsWithoutGSTDetails);
            return billingDetailsWithoutGSTDetailDetails;
        }
        public string DownloadInvoice(int id)
        {
            return _billingDetailsWithoutGSTRepository.DownloadInvoice(id);
        }
    }
}
