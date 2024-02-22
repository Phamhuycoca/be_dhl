using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.ImagePost
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagePostController : ControllerBase
    {
        private readonly IImagePostService _service;
        public ImagePostController(IImagePostService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_service.getAll());
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }
}
