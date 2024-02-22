using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        public PostController(IPostService service)
        {
            _service = service;
        }
        [HttpGet("Index/{id}")]
        public IActionResult Index(int id)
        {
            try
            {
                return Ok(_service.getAll(id));
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet("getAlls")]
        public IActionResult getAlls()
        {
            try
            {
                return Ok(_service.getAlls());
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
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
        [HttpPost]
        public IActionResult Create([FromForm] PostDto dto, IList<IFormFile> listFile)
        {
            try
            {
                DateTime now = DateTime.Now;
                dto.PostDate = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                if (_service.Create(dto, listFile, url))
                {
                    return StatusCode(StatusCodes.Status200OK, "Tạo mới thông tin thành công");
                }
                return StatusCode(StatusCodes.Status400BadRequest, "Tạo mới không thành công");
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] PostDto dto, [FromForm] List<ImagePostDto> ImageList, IList<IFormFile> listFile)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    if (_service.Update(dto, ImageList, listFile, url))
                    {
                        return StatusCode(StatusCodes.Status200OK, "Cập nhật thông tin thành công");
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Cập nhập không thành công");
                }
                return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy không tin");

            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    if (_service.Delete(id))
                    {
                        return StatusCode(StatusCodes.Status200OK, "Xóa thông tin thành công");
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Xóa thông tin không thành công");
                }
                return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy không tin");

            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    return Ok(_service.GetById(id));
                }
                return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy không tin");

            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }
}
