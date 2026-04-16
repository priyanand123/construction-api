using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on stocks.
    /// </summary>
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="stockService"/> class.
        /// </summary>
        /// <param name="stockRepository">The repository for accessing stockDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<StockDto>> GetStocksDetails(int? id)
        {
            var stocks = await _stockRepository.GetStocksDetails(id);

            var stockDetails = _mapper.Map<IEnumerable<StockDto>>(stocks);
            return stockDetails;
        }
   
        /// <inheritdoc/>
        public async Task UpdateStockDetails(StockUpdateDto stockDto)
        {
            var stock = _mapper.Map<StockUpdate>(stockDto);
            await _stockRepository.UpdateStockDetails(stock);
        }
       
    }
}
