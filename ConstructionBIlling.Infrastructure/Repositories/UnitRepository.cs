
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on unit.
    /// </summary>
    public class UnitRepository : IUnitRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing unit data.</param>
        public UnitRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Units>> GetUnitsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllUNIT; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Units>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Units> InsertUnitDetails(Units unit)
        {
            var spName = ConstantSPnames.SP_INSERTUNIT; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {
                
                Unit = unit.Unit,
                CreatedBy = unit.CreatedBy,

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Units>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateUnitDetails(Units unit)
        {
            var spName = ConstantSPnames.SP_UPDATEUNIT; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = unit.Id,
                Unit = unit.Unit,
                ModifiedBy = unit.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteUnitDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEUNIT; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
