
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on labour.
    /// </summary>
    public class LabourRepository : ILabourRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabourRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing labour data.</param>
        public LabourRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Labour>> GetLaboursDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllLABOUR; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Labour>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Labour> InsertLabourDetails(Labour labour)
        {
            var spName = ConstantSPnames.SP_INSERTLABOUR; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {
                Name = labour.Name,
                RoleId = labour.RoleId,
                Qualification = labour.Qualification,
                AadharNo = labour.AadharNo,
                LabourType = labour.LabourType,
                MobileNo = labour.MobileNo,
                PanNo = labour.PanNo,
                EmergencyNo = labour.EmergencyNo,
                Address = labour.Address,
                UserName = labour.UserName,
                Password = labour.Password,
                CreatedBy = labour.CreatedBy
            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Labour>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;
        

        }
        /// <inheritdoc/>
        public async Task UpdateLabourDetails(Labour labour)
        {
            var spName = ConstantSPnames.SP_UPDATELABOUR; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = labour.Id,
                Name = labour.Name,
                RoleId = labour.RoleId,
                Qualification = labour.Qualification,
                AadharNo = labour.AadharNo,
                LabourType = labour.LabourType,
                MobileNo = labour.MobileNo,
                PanNo = labour.PanNo,
                EmergencyNo = labour.EmergencyNo,
                Address = labour.Address,
                UserName = labour.UserName,
                ModifiedBy = labour.ModifiedBy,
               
            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteLabourDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETELABOUR; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public async Task ResetPasswordAsync(int id, string username, string newPassword, string modifiedBy)
        {
            var spName = ConstantSPnames.SP_UPDATEPASSWORD; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = id,                
                UserName = username,
                Password = newPassword,
                ModifiedBy =modifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));

        }
    }
}
