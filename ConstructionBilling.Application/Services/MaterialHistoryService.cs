using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for retrieving materialHistorys.
    /// </summary>
    public class MaterialHistoryService : IMaterialHistoryService
    {
        private readonly IMaterialHistoryRepository _materialHistoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialHistoryService"/> class.
        /// </summary>
        /// <param name="materialHistoryRepository">The repository for accessing materialHistory data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public MaterialHistoryService(IMaterialHistoryRepository materialHistoryRepository, IMapper mapper)
        {
            _materialHistoryRepository = materialHistoryRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaterialHistoryDto>> GetMaterialHistory(int? id)
        {
            var materialHistorys = await _materialHistoryRepository.GetMaterialHistory(id);
            var materialHistory = _mapper.Map<IEnumerable<MaterialHistoryDto>>(materialHistorys);
            return materialHistory;
        }
    }
}
