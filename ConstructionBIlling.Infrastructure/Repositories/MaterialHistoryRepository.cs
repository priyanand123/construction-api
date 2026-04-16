using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for retrieving material histories.
    /// </summary>
    public class MaterialHistoryRepository : IMaterialHistoryRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialHistoryRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing material history data.</param>
        public MaterialHistoryRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MaterialHistory>> GetMaterialHistory(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllMATERIALHISTORY;
            return await Task.Factory.StartNew(() =>
                _db.Connection.Query<MaterialHistory>(spName, new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }
    }
}
