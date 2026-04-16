using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Spire.Doc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on purchaseDetailDto.
 /// </summary>
    [Route("api/purchaseDetailDto")]
    [ApiController]
    public class PurchaseDetailController : ConstructionBillingControllerBase
    {
        private readonly IPurchaseDetailService _purchaseDetailService;
        /// <summary>
        /// Initializes a new instance of the <see cref="purchaseDetailController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="purchaseDetailService">The purchaseDetailDto service instance used for CRUD operations on purchaseDetailDto.</param>
        public PurchaseDetailController(ILogger<PurchaseDetailController> logger, IPurchaseDetailService purchaseDetailService) : base(logger)
        {
            _purchaseDetailService = purchaseDetailService;
        }

        /// <summary>
        /// Retrieves all purchaseDetailDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of purchaseDetailDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PurchaseDetailDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllPurchaseDetails()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllPurchaseDetails));
            try
            {
                var result = await _purchaseDetailService.GetPurchaseDetailsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a purchaseDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the purchaseDetailDto.</param>
        /// <returns>
        /// The response with the purchaseDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PurchaseDetailDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetPurchaseDetail(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetPurchaseDetail), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var purchaseDetailDto = await _purchaseDetailService.GetPurchaseDetailsDetails(id);
                return purchaseDetailDto.Count() == 1 ? Ok(purchaseDetailDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new purchaseDetailDto.
        /// </summary>
        /// <param name="purchaseDetailDto">The DTO representing the purchaseDetailDto to insert.</param>
        /// <returns>
        /// The response with the created purchaseDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertPurchaseDetail([FromBody] PurchaseDetailDto purchaseDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertPurchaseDetail));
            try
            {
                // Insert the purchaseDetailDto and retrieve the data
                var PurchaseDetailDetail = await _purchaseDetailService.InsertPurchaseDetailDetails(purchaseDetailDto);


                return CreatedAtAction(nameof(GetAllPurchaseDetails), new { id = purchaseDetailDto.Id }, PurchaseDetailDetail);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        /// <summary>
        /// Updates an existing purchaseDetailDto.
        /// </summary>
        /// <param name="purchaseDetailDto">The DTO representing the updated purchaseDetailDto.</param>
        /// <returns>
        /// The response with no content if the update is successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> UpdatePurchaseDetail([FromBody] PurchaseDetailDto purchaseDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdatePurchaseDetail));
            var purchaseDetailDetails = await _purchaseDetailService.GetPurchaseDetailsDetails(purchaseDetailDto.Id);
            if (purchaseDetailDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _purchaseDetailService.UpdatePurchaseDetailDetails(purchaseDetailDto);
                return NoContent();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        /// <summary>
        /// Deletes a purchaseDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the purchaseDetailDto to delete.</param>
        /// <returns>
        /// The response with no content if the deletion is successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> DeletePurchaseDetail(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeletePurchaseDetail), id);
            var purchaseDetailDto = await _purchaseDetailService.GetPurchaseDetailsDetails(id);
            if (purchaseDetailDto == null)
            {
                return NotFound();
            }

            try
            {
                await _purchaseDetailService.DeletePurchaseDetailDetails(id);
                return NoContent();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL Error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Database Error",
                    Detail = "An error occurred while processing your request. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Status = (int)HttpStatusCode.InternalServerError
                });
            }
        }


       
        [HttpGet]
        [Route("getpuchasecompanylist/{purchaseCompany}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PurchaseDetailDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetPurchaseCompanList(string purchaseCompany)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllPurchaseDetails));
            try
            {
                var result = await _purchaseDetailService.GetPurchaseCompanList(purchaseCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
