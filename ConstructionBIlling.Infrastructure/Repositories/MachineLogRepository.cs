using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on MachineLogDetail.
    /// </summary>
    public class MachineLogDetailRepository : IMachineLogDetailRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineLogDetailRepository"/> class.
        /// </summary>
        /// <param name="db">The database connection for accessing machineLogDetail data.</param>
        public MachineLogDetailRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MachineLogDetail>> GetMachineLogDetailDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllMACHINELOGDETAIL; // Name of your stored procedure for fetching machine log details
            return await Task.Factory.StartNew(() =>
                _db.Connection.Query<MachineLogDetail>(spName, new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        /// <inheritdoc/>
        public async Task<MachineLogDetail> InsertMachineLogDetailDetails(MachineLogDetail machineLogDetail)
        {
            var spName = ConstantSPnames.SP_INSERTMACHINELOGDETAIL; // Name of your stored procedure for inserting machine log details

            // Define parameters for the stored procedure
            var parameters = new
            {
                LogDate = machineLogDetail.LogDate,
                StartTime = machineLogDetail.StartTime,
                StopTime = machineLogDetail.StopTime,
                TotalWorkingTime = machineLogDetail.TotalWorkingTime,
                EBMeterStartReading = machineLogDetail.EBMeterStartReading,
                EBMeterEndReading =machineLogDetail.EBMeterEndReading,
                TotalEBUnitsUsedToday = machineLogDetail.TotalEBUnitsUsedToday,
                MaterialData = machineLogDetail.MaterialData,
                AverageWeightOfBricks = machineLogDetail.AverageWeightOfBricks,
                PressingCount = machineLogDetail.PressingCount,
                NoOfMixtures = machineLogDetail.NoOfMixtures,
                TotalBricksCount = machineLogDetail.TotalBricksCount,
                DamagedBricksCount = machineLogDetail.DamagedBricksCount,
                ActualBricksCount = machineLogDetail.ActualBricksCount,
                ReasonForShutdown = machineLogDetail.ReasonForShutdown,
                CreatedBy = machineLogDetail.CreatedBy // Ensure CreatedBy is passed correctly
            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<MachineLogDetail>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;
        }

        /// <inheritdoc/>
        public async Task UpdateMachineLogDetailDetails(MachineLogDetail machineLogDetail)
        {
            var spName = ConstantSPnames.SP_UPDATEMACHINELOGDETAIL; // Name of your stored procedure for updating machine log details

            // Define parameters for the stored procedure
            var parameters = new
            {
                Id = machineLogDetail.Id,
                LogDate = machineLogDetail.LogDate,
                StartTime = machineLogDetail.StartTime,
                StopTime = machineLogDetail.StopTime,
                TotalWorkingTime = machineLogDetail.TotalWorkingTime,
                EBMeterStartReading = machineLogDetail.EBMeterStartReading,
                EBMeterEndReading = machineLogDetail.EBMeterEndReading,
                TotalEBUnitsUsedToday = machineLogDetail.TotalEBUnitsUsedToday,
                MaterialData = machineLogDetail.MaterialData,
                AverageWeightOfBricks = machineLogDetail.AverageWeightOfBricks,
                PressingCount = machineLogDetail.PressingCount,
                NoOfMixtures = machineLogDetail.NoOfMixtures,
                TotalBricksCount = machineLogDetail.TotalBricksCount,
                DamagedBricksCount = machineLogDetail.DamagedBricksCount,
                ActualBricksCount = machineLogDetail.ActualBricksCount,
                ReasonForShutdown = machineLogDetail.ReasonForShutdown,
                ModifiedBy = machineLogDetail.ModifiedBy // Ensure ModifiedBy is passed for updates
            };

            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteMachineLogDetailDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEMACHINELOGDETAIL; // Name of your stored procedure for deleting machine log details

            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));

            return true;
        }
    }
}
