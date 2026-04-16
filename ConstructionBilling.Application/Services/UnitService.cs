using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on units.
    /// </summary>
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="unitService"/> class.
        /// </summary>
        /// <param name="unitRepository">The repository for accessing unitDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public UnitService(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<UnitDto>> GetUnitsDetails(int? id)
        {
            var units = await _unitRepository.GetUnitsDetails(id);

            var unitDetails = _mapper.Map<IEnumerable<UnitDto>>(units);
            return unitDetails;
        }
        /// <inheritdoc/>
        public async Task<UnitDto> InsertUnitDetails(UnitDto unitDto)
        {

            var unit = _mapper.Map<Units>(unitDto);
            var insertedData = await _unitRepository.InsertUnitDetails(unit);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Unit insertion failed.");
            }
            return _mapper.Map<UnitDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateUnitDetails(UnitDto unitDto)
        {
            var unit = _mapper.Map<Units>(unitDto);
            await _unitRepository.UpdateUnitDetails(unit);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteUnitDetails(int id)
        {
            return await _unitRepository.DeleteUnitDetails(id);
        }
    }
}
