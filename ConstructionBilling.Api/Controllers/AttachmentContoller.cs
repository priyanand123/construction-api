using ConstructionBilling.Application.Common;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Net;
using static System.Collections.Specialized.BitVector32;


namespace ConstructionBilling.Api.Controllers
{/// <summary>
 /// Controller for handling CRUD operations on attachmentDto.
 /// </summary>
    [Route("api/attachmentDto")]
    [ApiController]
    public class AttachmentController : ConstructionBillingControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        /// <summary>
        /// Initializes a new instance of the <see cref="attachmentController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for logging.</param>
        /// <param name="attachmentService">The attachmentDto service instance used for CRUD operations on attachmentDto.</param>
        public AttachmentController(ILogger<AttachmentController> logger, IAttachmentService attachmentService) : base(logger)
        {
            _attachmentService = attachmentService;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(FileUploadDto))]
        [ProducesResponseType(404)]

        public async Task<IActionResult> UploadFile([FromForm] FileUploadDto fileUploadModel)
        {
            if (fileUploadModel.FormFiles != null)
            {
                var target = Path.Combine(Directory.GetCurrentDirectory(), fileUploadModel.TypeofUser, fileUploadModel.TypeofUser + "-" + fileUploadModel.Id);

                if (Directory.Exists(target))
                {
                    // Delete the directory and its contents recursively
                    Directory.Delete(target, true);
                }

                // Recreate the directory
                Directory.CreateDirectory(target);

                for (int i = 0; i < fileUploadModel.FormFiles.Count; i++)
                {
                    string path = Path.Combine(target, fileUploadModel.FormFiles[i].FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await fileUploadModel.FormFiles[i].CopyToAsync(stream);
                    }
                }
                string filenames = "";
                if (target != "")
                {
                    string[] filePaths = Directory.GetFiles(target);
                    foreach (var file in filePaths)
                    {
                        filenames = filenames + Path.GetFileName(file) + "|";

                    }

                }
                await _attachmentService.UpdateFilepathdata(target, fileUploadModel.Id, filenames, fileUploadModel.TypeofUser);
            }
            return Ok();
        }
        [HttpGet("downloadAttachmentFile/{id}/{type}/{filename}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> DownloadAttachmentFile(int id, string type, string filename)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(DownloadAttachmentFile));
            try
            {
                // Construct file path

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), type, $"{type}-{id}", filename);
                _logger.LogInformation("File path: {FilePath}", filePath);

                // Check if the file exists
                if (!System.IO.File.Exists(filePath))
                {
                    _logger.LogWarning("File not found: {FilePath}", filePath);
                    return NotFound("File not found.");
                }

                // Prepare memory stream
                MemoryStream memory = new MemoryStream();

                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                // Get content type
                string contentType;
                try
                {
                    contentType = FindContentType.GetContentType(filePath);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to determine content type");
                    return StatusCode(500, "Failed to determine content type.");
                }

                // Reset memory stream position
                memory.Position = 0;

                return File(memory, contentType, Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while downloading the attachment");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("downloadAttachmentZip/{id}/{type}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> DownloadAttachmentZip(int id,string type)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(DownloadAttachmentZip));
            var zipName = $"{type}-{id}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), type, $"{type}-{id}");
            var files = Directory.GetFiles(Path.Combine(filePath)).ToList();

            MemoryStream compressedFileStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, true))
            {

                files.ForEach(file =>
                {
                    //Create a zip entry for each attachment
                    var zipEntry = zipArchive.CreateEntry(Path.GetFileName(file));
                    byte[] bytes = System.IO.File.ReadAllBytes(file);
                    //Get the stream of the attachment
                    using (var originalFileStream = new MemoryStream(bytes))
                    using (var zipEntryStream = zipEntry.Open())
                    {
                        //Copy the attachment stream to the zip entry stream
                        originalFileStream.CopyTo(zipEntryStream);
                    }
                });


            }
            const string contentType = "application/zip";
            HttpContext.Response.ContentType = contentType;
            var result = new FileContentResult(compressedFileStream.ToArray(), contentType)
            {
                FileDownloadName = $"{zipName}.zip"
            };
            return result;

        }
        [HttpGet("deleteAttachment/{id}/{type}/{filename}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.ServiceUnavailable)]
        public async Task<IActionResult> DeleteAttachment(int id, string type, string filename)
        {
            _logger.LogInformation("{MethodName} method is called", nameof(DeleteAttachment));
            try
            {
                // Construct file path
                string target = Path.Combine(Directory.GetCurrentDirectory(), type, $"{type}-{id}");
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), type, $"{type}-{id}", filename);
                var filenames = string.Empty;
                _logger.LogInformation("File path: {FilePath}", filePath);

                // Check if the file exists delete that perticular file
                if (!System.IO.File.Exists(filePath))
                {
                    _logger.LogWarning("File not found: {FilePath}", filePath);
                    return NotFound("File not found.");
                }
                else
                {
                    System.IO.File.Delete(filePath);                    
                }
                if (target != "")
                {
                    // Check if the folder is empty
                    if (Directory.GetFiles(target).Length == 0 && Directory.GetDirectories(target).Length == 0)
                    {
                        // Delete the empty folder
                        Directory.Delete(target);
                        target = string.Empty;
                    }
                    else
                    {
                        string[] filePaths = Directory.GetFiles(target);
                        foreach (var file in filePaths)
                        {
                            filenames = $"{filenames}{Path.GetFileName(file)}|";

                        }
                    }
                }
                await _attachmentService.UpdateFilepathdata(target, id, filenames, type);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while downloading the attachment");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}
