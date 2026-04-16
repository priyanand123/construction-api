using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on machineLogDetailDto.
 /// </summary>
    [Route("api/machineLogDetailDto")]
    [ApiController]
    public class MachineLogDetailController : ConstructionBillingControllerBase
    {
        private readonly IMachineLogDetailService _machineLogDetailService;
        /// <summary>
        /// Initializes a new instance of the <see cref="machineLogDetailController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="machineLogDetailService">The machineLogDetailDto service instance used for CRUD operations on machineLogDetailDto.</param>
        public MachineLogDetailController(ILogger<MachineLogDetailController> logger, IMachineLogDetailService machineLogDetailService) : base(logger)
        {
            _machineLogDetailService = machineLogDetailService;
        }

        /// <summary>
        /// Retrieves all machineLogDetailDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of machineLogDetailDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MachineLogDetailDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllMachineLogDetailDetails()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllMachineLogDetailDetails));
            try
            {
                var result = await _machineLogDetailService.GetMachineLogDetailDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a machineLogDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the machineLogDetailDto.</param>
        /// <returns>
        /// The response with the machineLogDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(MachineLogDetailDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetMachineLogDetail(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetMachineLogDetail), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var machineLogDetailDto = await _machineLogDetailService.GetMachineLogDetailDetails(id);
                return machineLogDetailDto.Count() == 1 ? Ok(machineLogDetailDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new machineLogDetailDto.
        /// </summary>
        /// <param name="machineLogDetailDto">The DTO representing the machineLogDetailDto to insert.</param>
        /// <returns>
        /// The response with the created machineLogDetailDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertMachineLogDetail([FromBody] MachineLogDetailDto machineLogDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertMachineLogDetail));
            try
            {
                // Insert the machineLogDetailDto and retrieve the data
                var MachineLogDetailDetail = await _machineLogDetailService.InsertMachineLogDetailDetails(machineLogDetailDto);


                return CreatedAtAction(nameof(GetAllMachineLogDetailDetails), new { id = machineLogDetailDto.Id }, MachineLogDetailDetail);
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
        /// Updates an existing machineLogDetailDto.
        /// </summary>
        /// <param name="machineLogDetailDto">The DTO representing the updated machineLogDetailDto.</param>
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
        public async Task<IActionResult> UpdateMachineLogDetail([FromBody] MachineLogDetailDto machineLogDetailDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateMachineLogDetail));
            var machineLogDetailDetails = await _machineLogDetailService.GetMachineLogDetailDetails(machineLogDetailDto.Id);
            if (machineLogDetailDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _machineLogDetailService.UpdateMachineLogDetailDetails(machineLogDetailDto);
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
        /// Deletes a machineLogDetailDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the machineLogDetailDto to delete.</param>
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
        public async Task<IActionResult> DeleteMachineLogDetail(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteMachineLogDetail), id);
            var machineLogDetailDto = await _machineLogDetailService.GetMachineLogDetailDetails(id);
            if (machineLogDetailDto == null)
            {
                return NotFound();
            }

            try
            {
                await _machineLogDetailService.DeleteMachineLogDetailDetails(id);
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
