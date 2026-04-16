using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on rawMaterialDto.
 /// </summary>
    [Route("api/rawMaterialDto")]
    [ApiController]
    public class RawMaterialController : ConstructionBillingControllerBase
    {
        private readonly IRawMaterialService _rawMaterialService;
        /// <summary>
        /// Initializes a new instance of the <see cref="rawMaterialController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="rawMaterialService">The rawMaterialDto service instance used for CRUD operations on rawMaterialDto.</param>
        public RawMaterialController(ILogger<RawMaterialController> logger, IRawMaterialService rawMaterialService) : base(logger)
        {
            _rawMaterialService = rawMaterialService;
        }

        /// <summary>
        /// Retrieves all rawMaterialDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of rawMaterialDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RawMaterialDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllRawMaterials()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllRawMaterials));
            try
            {
                var result = await _rawMaterialService.GetRawMaterialsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a rawMaterialDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rawMaterialDto.</param>
        /// <returns>
        /// The response with the rawMaterialDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(RawMaterialDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetRawMaterial(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetRawMaterial), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var rawMaterialDto = await _rawMaterialService.GetRawMaterialsDetails(id);
                return rawMaterialDto.Count() == 1 ? Ok(rawMaterialDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new rawMaterialDto.
        /// </summary>
        /// <param name="rawMaterialDto">The DTO representing the rawMaterialDto to insert.</param>
        /// <returns>
        /// The response with the created rawMaterialDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertRawMaterial([FromBody] RawMaterialDto rawMaterialDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertRawMaterial));
            try
            {
                // Insert the rawMaterialDto and retrieve the data
                var RawMaterialDetail = await _rawMaterialService.InsertRawMaterialDetails(rawMaterialDto);


                return CreatedAtAction(nameof(GetAllRawMaterials), new { id = rawMaterialDto.Id }, RawMaterialDetail);
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
        /// Updates an existing rawMaterialDto.
        /// </summary>
        /// <param name="rawMaterialDto">The DTO representing the updated rawMaterialDto.</param>
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
        public async Task<IActionResult> UpdateRawMaterial([FromBody] RawMaterialDto rawMaterialDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateRawMaterial));
            var rawMaterialDetails = await _rawMaterialService.GetRawMaterialsDetails((int?)rawMaterialDto.Id);
            if (rawMaterialDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _rawMaterialService.UpdateRawMaterialDetails(rawMaterialDto);
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
        /// Deletes a rawMaterialDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the rawMaterialDto to delete.</param>
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
        public async Task<IActionResult> DeleteRawMaterial(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteRawMaterial), id);
            var rawMaterialDto = await _rawMaterialService.GetRawMaterialsDetails(id);
            if (rawMaterialDto == null)
            {
                return NotFound();
            }

            try
            {
                await _rawMaterialService.DeleteRawMaterialDetails(id);
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
    }
}
