using ConstructionBilling.Application.Common;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Spire.Doc;
using System.Data.SqlClient;
using System.Net;



namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on billingDto.
 /// </summary>
    [Route("api/billingDto")]
    [ApiController]
    public class BillingController : ConstructionBillingControllerBase
    {
        private readonly IBillingService _billingService;
        /// <summary>
        /// Initializes a new instance of the <see cref="billingController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="billingService">The billingDto service instance used for CRUD operations on billingDto.</param>
        public BillingController(ILogger<BillingController> logger, IBillingService billingService) : base(logger)
        {
            _billingService = billingService;
        }

        /// <summary>
        /// Retrieves all billingDto.
        /// </summary>
        /// <returns>
        /// The response with a collection of billingDto DTOs if successful, or a problem 
        /// details object indicating the error if the operation fails.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BillingDto>))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> GetAllBillings()
        {
            _logger.LogInformation("{MethodName} method is called", nameof(GetAllBillings));
            try
            {
                var result = await _billingService.GetBillingsDetails(null);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        /// <summary>
        /// Retrieves a billingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDto.</param>
        /// <returns>
        /// The response with the billingDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BillingDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetBilling(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(GetBilling), id);
            if (id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                var billingDto = await _billingService.GetBillingsDetails(id);
                return billingDto.Count() == 1 ? Ok(billingDto) : StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Inserts a new billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the billingDto to insert.</param>
        /// <returns>
        /// The response with the created billingDto DTO if successful, or a problem details 
        /// object indicating the error if the operation fails.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> InsertBilling([FromBody] BillingDto billingDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(InsertBilling));
            try
            {
                // Insert the billingDto and retrieve the data
                var BillingDetail = await _billingService.InsertBillingDetails(billingDto);


                return CreatedAtAction(nameof(GetAllBillings), new { id = billingDto.Id }, BillingDetail);
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
        /// Updates an existing billingDto.
        /// </summary>
        /// <param name="billingDto">The DTO representing the updated billingDto.</param>
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
        public async Task<IActionResult> UpdateBilling([FromBody] BillingDto billingDto)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(UpdateBilling));
            var billingDetails = await _billingService.GetBillingsDetails((int?)billingDto.Id);
            if (billingDetails == null)
            {
                return NotFound();
            }

            try
            {
                await _billingService.UpdateBillingDetails(billingDto);
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
        /// Deletes a billingDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the billingDto to delete.</param>
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
        public async Task<IActionResult> DeleteBilling(int id)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {id}", nameof(DeleteBilling), id);
            var billingDto = await _billingService.GetBillingsDetails(id);
            if (billingDto == null)
            {
                return NotFound();
            }

            try
            {
                await _billingService.DeleteBillingDetails(id);
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
        [Route("downloadinvoice/{id}")]
        public async Task<IActionResult> DownloadInvoice(int id)
        {
            try
            {
                _logger.LogInformation("Invoice ID received in controller: {Id}", id);

                // Fetch the file path of the .docx file
                var result = _billingService.DownloadInvoice(id);
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
        [HttpGet]
        [Route("downloadVoucher/{id}")]
        public async Task<IActionResult> DownloadPaymentVoucher(int id)
        {
            try
            {
                // Fetch the file path of the .docx file
                var result = _billingService.DownloadPaymentVoucher(id);
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
        [HttpGet]
        [Route("downloadDeliveryChallen/{id}")]
        public async Task<IActionResult> DownloadDeliveryChallen(int id)
        {
            try
            {
                var fileName = _billingService.DownloadDeliveryChallen(id);

                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Template",
                    fileName
                );

                _logger.LogInformation("File path: {FilePath}", filePath);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found.");
                }

                Document doc = new Document();
                doc.LoadFromFile(filePath);

                string pdfPath = Path.ChangeExtension(filePath, ".pdf");

                doc.SaveToFile(pdfPath, FileFormat.PDF);

                MemoryStream memory = new MemoryStream();

                using (var stream = new FileStream(pdfPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;

                System.IO.File.Delete(pdfPath);

                return File(memory, "application/pdf", Path.GetFileName(pdfPath));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("getconsigneelist/{consigneeList}")]
        [ProducesResponseType(200, Type = typeof(BillingDto))]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]

        public async Task<IActionResult> GetConsigneeList(string consigneeList)
        {
            _logger.LogInformation("{MethodName} method is called for the id: {consigneeList}", nameof(GetBilling), consigneeList);
           
            try
            {
                var billingDto = await _billingService.GetConsigneeList(consigneeList);
                return Ok(billingDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
    

}
