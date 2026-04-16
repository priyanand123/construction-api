
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on stock.
    /// </summary>
    public class StockRepository : IStockRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing stock data.</param>
        public StockRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Stocks>> GetStocksDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllSTOCK; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Stocks>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        /// <inheritdoc/>
        public async Task UpdateStockDetails(StockUpdate stock)
        {
            var spName = ConstantSPnames.SP_UPDATESTOCK; // Update the stored procedure name if necessary

            var parameters = new
            {
                BricksIdFrom = stock.BricksIdFrom,
                BricksIdTo=stock.BricksIdTo,
                UnitId =stock.UnitId,
                Quantity = stock.Quantity,
                ModifiedBy = stock.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

       
    }
}
