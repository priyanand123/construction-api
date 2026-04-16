using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on tripDto.
 /// </summary>
    [Route("api/tripDto")]
    [ApiController]
    public class TripController : ConstructionBillingControllerBase
    {
        private readonly ITripService _tripService;
        /// <summary>
        /// Initializes a new instance of the <see cref="tripController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="tripService">The tripDto service instance used for CRUD operations on tripDto.</param>
        public TripController(ILogger<TripController> logger, ITripService tripService) : base(logger)
        {
            _tripService = tripService;
        }

        /// <summary>
        /// Retrieves all tripDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of tripDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TripDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllTrips()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllTrips));
            try
            {
                var result = await _tripService.GetTripsDetails(null);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a tripDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tripDto.</param>
        /// <returns>
        /// The response with the tripDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TripDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetTrip(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetTrip), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var tripDto = await _tripService.GetTripsDetails(id);
                return tripDto.Count() == 1 ? Ok(tripDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new tripDto.
        /// </summary>
        /// <param name="tripDto">The DTO representing the tripDto to insert.</param>
        /// <returns>
        /// The response with the created tripDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertTrip([FromBody] TripDto tripDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertTrip));
            try
            {
                // Insert the tripDto and retrieve the data
                var TripDetail = await _tripService.InsertTripDetails(tripDto);


                return CreatedAtAction(nameof(GetAllTrips), new { id = tripDto.Id }, TripDetail);
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
        /// Updates an existing tripDto.
        /// </summary>
        /// <param name="tripDto">The DTO representing the updated tripDto.</param>
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
        public async Task<IActionResult> UpdateTrip([FromBody] TripDto tripDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateTrip));
            var tripDetails = await _tripService.GetTripsDetails(tripDto.Id);
            if (tripDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _tripService.UpdateTripDetails(tripDto);
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
        /// Deletes a tripDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the tripDto to delete.</param>
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
        public async Task<IActionResult> DeleteTrip(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteTrip), id);
            var tripDto = await _tripService.GetTripsDetails(id);
            if (tripDto == null)
            {
                return NotFound();
            }

            try
            {
                await _tripService.DeleteTripDetails(id);
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
