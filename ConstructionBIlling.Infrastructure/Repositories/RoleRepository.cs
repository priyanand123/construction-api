
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on role.
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing role data.</param>
        public RoleRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Roles>> GetRolesDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllROLEDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Roles>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Roles> InsertRoleDetails(Roles role)
        {
            var spName = ConstantSPnames.SP_INSERTROLEDETAIL; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {
               Role=role.Role,
               CreatedBy = role.CreatedBy
            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Roles>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;
        

        }
        /// <inheritdoc/>
        public async Task UpdateRoleDetails(Roles role)
        {
            var spName = ConstantSPnames.SP_UPDATEROLEDETAIL; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = role.Id,
                Role = role.Role,
                ModifiedBy = role.ModifiedBy,
               
            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteRoleDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEROLEDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
