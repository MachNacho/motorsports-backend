using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        //private readonly IBlobService _blobService;
        //public BlobController(IBlobService blobService)
        //{
        //    _blobService = blobService;
        //}

        //[HttpGet("{fileName}")]
        //public async Task<IActionResult> Download(string fileName)
        //{
        //    var (content, contentType) = await _blobService.GetFileAsync(fileName);
        //    return File(content, contentType!, fileName);
        //}

        [Authorize]
        [HttpGet("Test/{message}")]
        public async Task<IActionResult> TestAuth(string message)
        {
            return Ok(message);
        }

    }
}
