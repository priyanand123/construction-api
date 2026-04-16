
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on rawMaterial.
    /// </summary>
    public class RawMaterialRepository : IRawMaterialRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RawMaterialRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing rawMaterial data.</param>
        public RawMaterialRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RawMaterial>> GetRawMaterialsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllMATERIALS; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<RawMaterial>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<IEnumerable<RawMaterial>> InsertRawMaterialDetails(RawMaterial material)
        {
            var spName = ConstantSPnames.SP_INSERTMATERIAL; // Update the stored procedure name if necessary

            var parameters = new
            {
                
                MaterialName = material.MaterialName,
                IsManufacturingMaterial = material.IsManufacturingMaterial,
                UnitId = material.UnitId,
                CreatedBy = material.CreatedBy,


            };
            return await Task.Factory.StartNew(() => _db.Connection.Query<RawMaterial>(spName, parameters, commandType: CommandType.StoredProcedure).ToList());
        }
        /// <inheritdoc/>
        public async Task UpdateRawMaterialDetails(RawMaterial material)
        {
            var spName = ConstantSPnames.SP_UPDATEMATERIAL; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = material.Id,
                MaterialName = material.MaterialName,
                IsManufacturingMaterial = material.IsManufacturingMaterial,
                UnitId = material.UnitId,
                ModifiedBy = material.ModifiedBy,




            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteRawMaterialDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEMATERIAL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
