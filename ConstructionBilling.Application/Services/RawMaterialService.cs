using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on rawMaterials.
    /// </summary>
    public class RawMaterialService : IRawMaterialService
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="rawMaterialService"/> class.
        /// </summary>
        /// <param name="rawMaterialRepository">The repository for accessing rawMaterialDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public RawMaterialService(IRawMaterialRepository rawMaterialRepository, IMapper mapper)
        {
            _rawMaterialRepository = rawMaterialRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<RawMaterialDto>> GetRawMaterialsDetails(int? id)
        {
            var rawMaterials = await _rawMaterialRepository.GetRawMaterialsDetails(id);
            var rawMaterialDetails = _mapper.Map<IEnumerable<RawMaterialDto>>(rawMaterials);
            return rawMaterialDetails;
        }
        /// <inheritdoc/>
        public async Task<RawMaterialDto> InsertRawMaterialDetails(RawMaterialDto rawMaterialDto)
        {
            var rawMaterial = _mapper.Map<RawMaterial>(rawMaterialDto);
            var insertedData = await _rawMaterialRepository.InsertRawMaterialDetails(rawMaterial);
            var insertedMaterials = _mapper.Map<IEnumerable<RawMaterialDto>>(insertedData);
            return insertedMaterials.FirstOrDefault();
        }
        /// <inheritdoc/>
        public async Task UpdateRawMaterialDetails(RawMaterialDto rawMaterialDto)
        {
            var rawMaterial = _mapper.Map<RawMaterial>(rawMaterialDto);
            await _rawMaterialRepository.UpdateRawMaterialDetails(rawMaterial);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteRawMaterialDetails(int id)
        {
            return await _rawMaterialRepository.DeleteRawMaterialDetails(id);
        }
    }
}
