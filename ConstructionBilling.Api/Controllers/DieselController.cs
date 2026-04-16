using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on dieselDto.
 /// </summary>
    [Route("api/dieselDto")]
    [ApiController]
    public class DieselController : ConstructionBillingControllerBase
    {
        private readonly IDieselService _dieselService;
        /// <summary>
        /// Initializes a new instance of the <see cref="dieselController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="dieselService">The dieselDto service instance used for CRUD operations on dieselDto.</param>
        public DieselController(ILogger<DieselController> logger, IDieselService dieselService) : base(logger)
        {
            _dieselService = dieselService;
        }

        /// <summary>
        /// Retrieves all dieselDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of dieselDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DieselDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllDiesels()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllDiesels));
            try
            {
                var result = await _dieselService.GetDieselsDetails(null);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a dieselDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the dieselDto.</param>
        /// <returns>
        /// The response with the dieselDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DieselDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetDiesel(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetDiesel), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var dieselDto = await _dieselService.GetDieselsDetails(id);
                return dieselDto.Count() == 1 ? Ok(dieselDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new dieselDto.
        /// </summary>
        /// <param name="dieselDto">The DTO representing the dieselDto to insert.</param>
        /// <returns>
        /// The response with the created dieselDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertDiesel([FromBody] DieselDto dieselDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertDiesel));
            try
            {
                // Insert the dieselDto and retrieve the data
                var DieselDetail = await _dieselService.InsertDieselDetails(dieselDto);


                return CreatedAtAction(nameof(GetAllDiesels), new { id = dieselDto.Id }, DieselDetail);
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
        /// Updates an existing dieselDto.
        /// </summary>
        /// <param name="dieselDto">The DTO representing the updated dieselDto.</param>
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
        public async Task<IActionResult> UpdateDiesel([FromBody] DieselDto dieselDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateDiesel));
            var dieselDetails = await _dieselService.GetDieselsDetails(dieselDto.Id);
            if (dieselDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _dieselService.UpdateDieselDetails(dieselDto);
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
        /// Deletes a dieselDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the dieselDto to delete.</param>
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
        public async Task<IActionResult> DeleteDiesel(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteDiesel), id);
            var dieselDto = await _dieselService.GetDieselsDetails(id);
            if (dieselDto == null)
            {
                return NotFound();
            }

            try
            {
                await _dieselService.DeleteDieselDetails(id);
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
