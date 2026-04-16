using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on unitDto.
 /// </summary>
    [Route("api/unitDto")]
    [ApiController]
    public class UnitController : ConstructionBillingControllerBase
    {
        private readonly IUnitService _unitService;
        /// <summary>
        /// Initializes a new instance of the <see cref="unitController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="unitService">The unitDto service instance used for CRUD operations on unitDto.</param>
        public UnitController(ILogger<UnitController> logger, IUnitService unitService) : base(logger)
        {
            _unitService = unitService;
        }

        /// <summary>
        /// Retrieves all unitDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of unitDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UnitDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllUnits()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllUnits));
            try
            {
                var result = await _unitService.GetUnitsDetails(null);
                return Ok(result);
            }
            
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a unitDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the unitDto.</param>
        /// <returns>
        /// The response with the unitDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UnitDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetUnit(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetUnit), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var unitDto = await _unitService.GetUnitsDetails(id);
                return unitDto.Count() == 1 ? Ok(unitDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new unitDto.
        /// </summary>
        /// <param name="unitDto">The DTO representing the unitDto to insert.</param>
        /// <returns>
        /// The response with the created unitDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertUnit([FromBody] UnitDto unitDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertUnit));
            try
            {
                // Insert the unitDto and retrieve the data
                var UnitDetail = await _unitService.InsertUnitDetails(unitDto);


                return CreatedAtAction(nameof(GetAllUnits), new { id = unitDto.Id }, UnitDetail);
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
        /// Updates an existing unitDto.
        /// </summary>
        /// <param name="unitDto">The DTO representing the updated unitDto.</param>
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
        public async Task<IActionResult> UpdateUnit([FromBody] UnitDto unitDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateUnit));
            var unitDetails = await _unitService.GetUnitsDetails(unitDto.Id);
            if (unitDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _unitService.UpdateUnitDetails(unitDto);
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
        /// Deletes a unitDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the unitDto to delete.</param>
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
        public async Task<IActionResult> DeleteUnit(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteUnit), id);
            var unitDto = await _unitService.GetUnitsDetails(id);
            if (unitDto == null)
            {
                return NotFound();
            }

            try
            {
                await _unitService.DeleteUnitDetails(id);
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
