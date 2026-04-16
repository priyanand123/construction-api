using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on purchaseDetails.
    /// </summary>
    public class PurchaseDetailService : IPurchaseDetailService
    {
        private readonly IPurchaseDetailRepository _purchaseDetailRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="purchaseDetailService"/> class.
        /// </summary>
        /// <param name="purchaseDetailRepository">The repository for accessing purchaseDetailDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public PurchaseDetailService(IPurchaseDetailRepository purchaseDetailRepository, IMapper mapper)
        {
            _purchaseDetailRepository = purchaseDetailRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<PurchaseDetailDto>> GetPurchaseDetailsDetails(int? id)
        {
            var purchaseDetails = await _purchaseDetailRepository.GetPurchaseDetailsDetails(id);

            var purchaseDetailDetails = _mapper.Map<IEnumerable<PurchaseDetailDto>>(purchaseDetails);
            return purchaseDetailDetails;
        }
        /// <inheritdoc/>
        public async Task<PurchaseDetailDto> InsertPurchaseDetailDetails(PurchaseDetailDto purchaseDetailDto)
        {

            var purchaseDetail = _mapper.Map<PurchaseDetail>(purchaseDetailDto);
            var insertedData = await _purchaseDetailRepository.InsertPurchaseDetailDetails(purchaseDetail);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("PurchaseDetail insertion failed.");
            }
            return _mapper.Map<PurchaseDetailDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdatePurchaseDetailDetails(PurchaseDetailDto purchaseDetailDto)
        {
            var purchaseDetail = _mapper.Map<PurchaseDetail>(purchaseDetailDto);
            await _purchaseDetailRepository.UpdatePurchaseDetailDetails(purchaseDetail);
        }
        /// <inheritdoc/>
        public async Task<bool> DeletePurchaseDetailDetails(int id)
        {
            return await _purchaseDetailRepository.DeletePurchaseDetailDetails(id);
        }
        public async Task<IEnumerable<PurchaseDetailDto>> GetPurchaseCompanList(string purchaseCompany)
        {
            var purchaseDetails = await _purchaseDetailRepository.GetPurchaseCompanList(purchaseCompany);

            var purchaseDetailDetails = _mapper.Map<IEnumerable<PurchaseDetailDto>>(purchaseDetails);
            return purchaseDetailDetails;
        }
    }
}
