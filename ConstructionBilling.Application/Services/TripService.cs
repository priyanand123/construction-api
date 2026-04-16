using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on trips.
    /// </summary>
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="tripService"/> class.
        /// </summary>
        /// <param name="tripRepository">The repository for accessing tripDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TripDto>> GetTripsDetails(int? id)
        {
            var trips = await _tripRepository.GetTripsDetails(id);

            var tripDetails = _mapper.Map<IEnumerable<TripDto>>(trips);
            return tripDetails;
        }
        /// <inheritdoc/>
        public async Task<TripDto> InsertTripDetails(TripDto tripDto)
        {

            var trip = _mapper.Map<Trip>(tripDto);
            var insertedData = await _tripRepository.InsertTripDetails(trip);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Trip insertion failed.");
            }
            return _mapper.Map<TripDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateTripDetails(TripDto tripDto)
        {
            var trip = _mapper.Map<Trip>(tripDto);
            await _tripRepository.UpdateTripDetails(trip);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteTripDetails(int id)
        {
            return await _tripRepository.DeleteTripDetails(id);
        }
    }
}
