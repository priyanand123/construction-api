
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on trip.
    /// </summary>
    public class TripRepository : ITripRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing trip data.</param>
        public TripRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Trip>> GetTripsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllTRIP; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Trip>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Trip> InsertTripDetails(Trip trip)
        {
            var spName = ConstantSPnames.SP_INSERTTRIP; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {

                StartMeterReading = trip.StartMeterReading,
                EndMeterReading = trip.EndMeterReading,
                TotalUsedMeterReading = trip.TotalUsedMeterReading,
                Date = trip.Date,
                PersonName = trip.PersonName,
                CreatedBy = trip.CreatedBy,
                CreatedDate = trip.CreatedDate,
            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Trip>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateTripDetails(Trip trip)
        {
            var spName = ConstantSPnames.SP_UPDATETRIP; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = trip.Id,
                StartMeterReading = trip.StartMeterReading,
                EndMeterReading = trip.EndMeterReading,
                TotalUsedMeterReading = trip.TotalUsedMeterReading,
                Date = trip.Date,
                PersonName = trip.PersonName,
                ModifiedBy = trip.ModifiedBy,
                

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteTripDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETETRIP; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
