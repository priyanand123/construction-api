using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on labours.
    /// </summary>
    public class LabourService : ILabourService
    {
        private readonly ILabourRepository _labourRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="labourService"/> class.
        /// </summary>
        /// <param name="labourRepository">The repository for accessing labourDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public LabourService(ILabourRepository labourRepository, IMapper mapper)
        {
            _labourRepository = labourRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<LabourDto>> GetLaboursDetails(int? id)
        {
            var labours = await _labourRepository.GetLaboursDetails(id);

            var labourDetails = _mapper.Map<IEnumerable<LabourDto>>(labours);
            
            return labourDetails;
        }
        /// <inheritdoc/>
        public async Task<LabourDto> InsertLabourDetails(LabourDto labourDto)
        {
            
                var labour = _mapper.Map<Labour>(labourDto);

            var enPassword = BCrypt.Net.BCrypt.HashPassword(labour.Password);
            labour.Password = enPassword;
            var insertedData = await _labourRepository.InsertLabourDetails(labour);
                if (insertedData == null)
                {
                    // Handle the case where the insertion was not successful
                    throw new Exception("Labour insertion failed.");
                }
            return _mapper.Map<LabourDto>(insertedData);
            
        }
        /// <inheritdoc/>
        public async Task UpdateLabourDetails(LabourDto labourDto)
        {
            var labour = _mapper.Map<Labour>(labourDto);
           
            await _labourRepository.UpdateLabourDetails(labour);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteLabourDetails(int id)
        {
            return await _labourRepository.DeleteLabourDetails(id);
        }
    }
}
