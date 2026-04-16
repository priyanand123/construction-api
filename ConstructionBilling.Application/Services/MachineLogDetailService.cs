using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on machineLogDetails.
    /// </summary>
    public class MachineLogDetailService : IMachineLogDetailService
    {
        private readonly IMachineLogDetailRepository _machineLogDetailRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="machineLogDetailService"/> class.
        /// </summary>
        /// <param name="machineLogDetailRepository">The repository for accessing machineLogDetailDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public MachineLogDetailService(IMachineLogDetailRepository machineLogDetailRepository, IMapper mapper)
        {
            _machineLogDetailRepository = machineLogDetailRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<MachineLogDetailDto>> GetMachineLogDetailDetails(int? id)
        {
            var machineLogDetails = await _machineLogDetailRepository.GetMachineLogDetailDetails(id);

            var machineLogDetailDetails = _mapper.Map<IEnumerable<MachineLogDetailDto>>(machineLogDetails);
            return machineLogDetailDetails;
        }
        /// <inheritdoc/>
        public async Task<MachineLogDetailDto> InsertMachineLogDetailDetails(MachineLogDetailDto machineLogDetailDto)
        {

            var machineLogDetail = _mapper.Map<MachineLogDetail>(machineLogDetailDto);
            var insertedData = await _machineLogDetailRepository.InsertMachineLogDetailDetails(machineLogDetail);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("MachineLogDetail insertion failed.");
            }
            return _mapper.Map<MachineLogDetailDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateMachineLogDetailDetails(MachineLogDetailDto machineLogDetailDto)
        {
            var machineLogDetail = _mapper.Map<MachineLogDetail>(machineLogDetailDto);
            await _machineLogDetailRepository.UpdateMachineLogDetailDetails(machineLogDetail);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteMachineLogDetailDetails(int id)
        {
            return await _machineLogDetailRepository.DeleteMachineLogDetailDetails(id);
        }
    }
}
