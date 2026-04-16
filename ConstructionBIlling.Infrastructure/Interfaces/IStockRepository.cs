using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Infrastructure.Interfaces
{
    /// <summary>
    /// Repository interface for performing CRUD operations on stocks.
    /// </summary>
    public interface IStockRepository
    { /// <summary>
      /// Retrieves stocks optionally filtered by their unique identifier.
      /// </summary>
      /// <param name="id">Optional. The unique identifier of the stock to retrieve. If not provided, retrieves all stocks.</param>
      /// <returns>
      /// The task result contains a collection of stocks if successful, or null if no stocks match the provided identifier.
      /// </returns>
        Task<IEnumerable<Stocks>> GetStocksDetails(int? id);
 
        /// <summary>
        /// Updates an existing stock.
        /// </summary>
        /// <param name="stock">The stock to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateStockDetails(StockUpdate stock);
       
    }
}
