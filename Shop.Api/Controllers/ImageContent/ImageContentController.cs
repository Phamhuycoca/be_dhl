using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.ImageContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageContentController : ControllerBase
    {
        private readonly IImageNewsService _service;
        public ImageContentController(IImageNewsService service)
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
