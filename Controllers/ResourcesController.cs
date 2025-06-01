using AcademicResourceApp.Data;
using AcademicResourceApp.DTOs;
using AcademicResourceApp.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademicResourceApp.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CloudinaryDotNet.Cloudinary _cloudinary;

        public ResourcesController(AppDbContext context, CloudinaryDotNet.Cloudinary cloudinary)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        [HttpPost("upload")]
        [Authorize]
        public async Task<IActionResult> Upload([FromForm] UploadResourceDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("No file uploaded.");

            // Upload to Cloudinary
            using var stream = dto.File.OpenReadStream();
            var uploadParams = new RawUploadParams
            {
                File = new FileDescription(dto.File.FileName, stream)
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                return StatusCode(500, "Cloudinary upload failed.");

            // Get uploaderId from claims
            Guid? uploaderId = null;
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userId, out var parsedId))
            {
                uploaderId = parsedId;
            }

            // Save resource metadata to DB
            var resource = new Models.Resource
            {
                Title = dto.Title,
                Description = dto.Description,
                FileUrl = uploadResult.SecureUrl.ToString(),
                Type = dto.Type,
                UploadedAt = DateTime.UtcNow,
                UploadedById = uploaderId
            };
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Resource uploaded successfully!", url = resource.FileUrl });
        }

    }
}