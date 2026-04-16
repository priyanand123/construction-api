using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on diesels.
    /// </summary>
    public class DieselService : IDieselService
    {
        private readonly IDieselRepository _dieselRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="dieselService"/> class.
        /// </summary>
        /// <param name="dieselRepository">The repository for accessing dieselDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public DieselService(IDieselRepository dieselRepository, IMapper mapper)
        {
            _dieselRepository = dieselRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<DieselDto>> GetDieselsDetails(int? id)
        {
            var diesels = await _dieselRepository.GetDieselsDetails(id);

            var dieselDetails = _mapper.Map<IEnumerable<DieselDto>>(diesels);
            return dieselDetails;
        }
        /// <inheritdoc/>
        public async Task<DieselDto> InsertDieselDetails(DieselDto dieselDto)
        {

            var diesel = _mapper.Map<Diesel>(dieselDto);
            var insertedData = await _dieselRepository.InsertDieselDetails(diesel);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Diesel insertion failed.");
            }
            return _mapper.Map<DieselDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateDieselDetails(DieselDto dieselDto)
        {
            var diesel = _mapper.Map<Diesel>(dieselDto);
            await _dieselRepository.UpdateDieselDetails(diesel);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteDieselDetails(int id)
        {
            return await _dieselRepository.DeleteDieselDetails(id);
        }
    }
}
