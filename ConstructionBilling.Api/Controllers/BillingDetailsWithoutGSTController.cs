using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Spire.Doc;
using System.Net;

namespace ConstructionBilling.Api.Controllers
{
    [Route("api/billingDetailsWithoutGSTDto")]
    [ApiController]
    public class BillingDetailsWithoutGSTController : ConstructionBillingControllerBase
    {
        private readonly IBillingDetailsWithoutGSTService _billingDetailsWithoutGSTService;

        public BillingDetailsWithoutGSTController(ILogger<BillingDetailsWithoutGSTController> logger, IBillingDetailsWithoutGSTService billingDetailsWithoutGSTService) : base(logger)
        {
            _billingDetailsWithoutGSTService = billingDetailsWithoutGSTService;
        }

        /// <summary>
        /// Retrieves all billingDetailsWithoutGSTDto.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BillingDetailsWithoutGSTDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllBillingDetailsWithoutGST()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllBillingDetailsWithoutGST));
            try
            {
                var result = await _billingDetailsWithoutGSTService.GetBillingDetailsWithoutGSTDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retrieves a billingDetailsWithoutGSTDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDetailsWithoutGSTDto.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BillingDetailsWithoutGSTDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetBillingDetailsWithoutGST(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetBillingDetailsWithoutGST), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var billingDetailsWithoutGSTDto = await _billingDetailsWithoutGSTService.GetBillingDetailsWithoutGSTDetails(id);
                return billingDetailsWithoutGSTDto.Any() ? Ok(billingDetailsWithoutGSTDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("downloadinvoice/{id}")]
        public async Task<IActionResult> DownloadInvoice(int id)
        {
            try
            {
                // Fetch the file path of the .docx file
                var result = _billingDetailsWithoutGSTService.DownloadInvoice(id);
                _logger.LogInformation("File path: {FilePath}", result);

                // Check if the file exists
                if (!System.IO.File.Exists(result))
                {
                    _logger.LogWarning("File not found: {FilePath}", result);
                    return NotFound("File not found.");
                }

                // Load the .docx file using FreeSpire.Doc
                Document doc = new Document();
                doc.LoadFromFile(result);

                // Temporary path for the PDF file
                string pdfPath = Path.ChangeExtension(result, ".pdf");

                // Save as PDF
                doc.SaveToFile(pdfPath, FileFormat.PDF);

                // Prepare memory stream for the PDF file
                MemoryStream memory = new MemoryStream();

                using (var stream = new FileStream(pdfPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                // Reset memory stream position
                memory.Position = 0;

                // Clean up temporary PDF file
                System.IO.File.Delete(pdfPath);

                // Return the PDF file
                string contentType = "application/pdf";
                return File(memory, contentType, Path.GetFileName(pdfPath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while downloading the invoice.");
                return NotFound(ex.Message);
            }
        }
    }
}
