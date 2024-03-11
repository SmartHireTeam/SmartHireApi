using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SmartHire.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobDescriptionUploadController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string connectionString = "your_connection_string_here";
        private const string containerName = "your_container_name_here";

        [HttpPost("UploadDocument/{category}")]
        public async Task<IActionResult> UploadDocument(IFormFile file, string category)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("File is required.");
            }

            try
            {
                // Connect to Azure Blob Storage
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                // Create category folder if it doesn't exist
                string categoryFolderName = category.ToLower(); // Ensure lowercase folder names
                BlobContainerClient categoryContainerClient = blobServiceClient.GetBlobContainerClient(categoryFolderName);
                await categoryContainerClient.CreateIfNotExistsAsync();

                // Upload file to Azure Blob Storage
                string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
                BlobClient blobClient = categoryContainerClient.GetBlobClient(fileName);
                using (Stream fileStream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(fileStream, true);
                }
                return Ok($"Document uploaded successfully to category: {category}");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }

        }
    }
}
