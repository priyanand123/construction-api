using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on billings.
    /// </summary>
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="billingService"/> class.
        /// </summary>
        /// <param name="billingRepository">The repository for accessing billingDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public BillingService(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<BillingDto>> GetBillingsDetails(int? id)
        {
            var billings = await _billingRepository.GetBillingsDetails(id);

            var billingDetails = _mapper.Map<IEnumerable<BillingDto>>(billings);
            return billingDetails;
        }
        /// <inheritdoc/>
        public async Task<BillingDto> InsertBillingDetails(BillingDto billingDto)
        {
            
                var billing = _mapper.Map<Billings>(billingDto);
                var insertedData = await _billingRepository.InsertBillingDetails(billing);
                if (insertedData == null)
                {
                    // Handle the case where the insertion was not successful
                    throw new Exception("Billing insertion failed.");
                }
            return _mapper.Map<BillingDto>(insertedData);
            
        }
        /// <inheritdoc/>
        public async Task UpdateBillingDetails(BillingDto billingDto)
        {
            var billing = _mapper.Map<Billings>(billingDto);
            await _billingRepository.UpdateBillingDetails(billing);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteBillingDetails(int id)
        {
            return await _billingRepository.DeleteBillingDetails(id);
        }
        /// <inheritdoc/>
        public string DownloadInvoice(int id)
        {
            return  _billingRepository.DownloadInvoice(id);
        }
        public string DownloadPaymentVoucher(int id)
        {
            return _billingRepository.DownloadPaymentVoucher(id);
        }
        public string DownloadDeliveryChallen(int id)
        {
            return _billingRepository.DownloadDeliveryChallen(id);
        }

        public async Task<IEnumerable<BillingDto>> GetConsigneeList(string consigneeList)
        {
            var billings = await _billingRepository.GetConsigneeList(consigneeList);

            var billingDetails = _mapper.Map<IEnumerable<BillingDto>>(billings);
            return billingDetails;
        }
    }
}
