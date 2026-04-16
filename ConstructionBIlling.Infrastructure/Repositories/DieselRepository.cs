
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on diesel.
    /// </summary>
    public class DieselRepository : IDieselRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DieselRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing diesel data.</param>
        public DieselRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Diesel>> GetDieselsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllDIESEL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Diesel>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Diesel> InsertDieselDetails(Diesel diesel)
        {
            var spName = ConstantSPnames.SP_INSERTDIESEL; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {

                Date = diesel.Date,
                Day = diesel.Day,
                DieselAmount = diesel.DieselAmount,
                Liters = diesel.Liters,
                PersonName = diesel.PersonName,
                MaintenanceCost = diesel.MaintenanceCost, 
                CreatedBy = diesel.CreatedBy

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Diesel>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateDieselDetails(Diesel diesel)
        {
            var spName = ConstantSPnames.SP_UPDATEDIESEL; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = diesel.Id,
                Date = diesel.Date,
                Day = diesel.Day,
                DieselAmount = diesel.DieselAmount,
                Liters = diesel.Liters,
                PersonName = diesel.PersonName,
                MaintenanceCost = diesel.MaintenanceCost,
                ModifiedBy = diesel.ModifiedBy

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteDieselDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEDIESEL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
