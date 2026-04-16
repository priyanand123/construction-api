using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ConstructionBilling.Api.Controllers
{
    /// <summary>
    /// Controller for handling retrieval operations on MaterialHistoryDto.
    /// </summary>
    [Route("api/materialHistoryDto")]
    [ApiController]
    public class MaterialHistoryController : ConstructionBillingControllerBase
    {
        private readonly IMaterialHistoryService _materialHistoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialHistoryController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="materialHistoryService">The materialHistory service instance used for retrieval operations on MaterialHistoryDto.</param>
        public MaterialHistoryController(ILogger<MaterialHistoryController> logger, IMaterialHistoryService materialHistoryService) : base(logger)
        {
            _materialHistoryService = materialHistoryService;
        }

        /// <summary>
        /// Retrieves all MaterialHistoryDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of MaterialHistoryDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MaterialHistoryDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllMaterialHistory()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllMaterialHistory));
            try
            {
                var result = await _materialHistoryService.GetMaterialHistory(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves a MaterialHistoryDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the MaterialHistoryDto.</param>
        /// <returns>
        /// The response with the MaterialHistoryDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MaterialHistoryDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetMaterialHistory(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetMaterialHistory), id);
            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                var materialHistoryDto = await _materialHistoryService.GetMaterialHistory(id);
                return materialHistoryDto.Count() == 1 ? Ok(materialHistoryDto) : NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
