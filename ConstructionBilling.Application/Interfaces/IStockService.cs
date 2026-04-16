using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Domain.Entities;

namespace ConstructionBilling.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on stocks.
    /// </summary>
    public interface IStockService
    {/// <summary>
     /// Retrieves stocks optionally filtered by their unique identifier.
     /// </summary>
     /// <param name="id">Optional. The unique identifier of the stockDto to retrieve. If not provided, retrieves all stocks.</param>
     /// <returns>
     /// The task result contains a collection of stockDto DTOs. if successful, or null if no stocks match the provided identifier.
     /// </returns>
        Task<IEnumerable<StockDto>> GetStocksDetails(int? id);
       
        /// <summary>
        /// Updates an existing stockDto.
        /// </summary>
        /// <param name="stockDto">The DTO representing the updated stockDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateStockDetails(StockUpdateDto stockDto);
        
    }
}
