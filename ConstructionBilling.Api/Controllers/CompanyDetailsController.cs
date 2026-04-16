using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;

namespace ConstructionBilling.Api.Controllers
{
    [Route("api/companyDetailsDto")]
    [ApiController]
    public class CompanyDetailsController : ConstructionBillingControllerBase
    {
        private readonly ICompanyDetailsService _companyDetailsService;

        public CompanyDetailsController(ILogger<CompanyDetailsController> logger, ICompanyDetailsService companyDetailsService) : base(logger)
        {
            _companyDetailsService = companyDetailsService;
        }

        /// <summary>
        /// Retrieves all companyDetailsDto.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CompanyDetailsDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllCompanyDetails()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllCompanyDetails));
            try
            {
                var result = await _companyDetailsService.GetCompanyDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves a companyDetailsDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the companyDetailsDto.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CompanyDetailsDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetCompanyDetails(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetCompanyDetails), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var companyDetailsDto = await _companyDetailsService.GetCompanyDetails(id);
                return companyDetailsDto.Count() == 1 ? Ok(companyDetailsDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Updates an existing companyDetailsDto.
        /// </summary>
        /// <param name="companyDetailsDto">The DTO representing the updated companyDetailsDto.</param>
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
        public async Task<IActionResult> UpdateCompanyDetails([FromBody] CompanyDetailsDto companyDetailsDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateCompanyDetails));
            var companyDetailsDetails = await _companyDetailsService.GetCompanyDetails(companyDetailsDto.Id);
            if (companyDetailsDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _companyDetailsService.UpdateCompanyDetails(companyDetailsDto);
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
