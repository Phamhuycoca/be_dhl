using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.NewsContent
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsContentController : ControllerBase
    {
        private readonly INewsContentService _service;
        public NewsContentController(INewsContentService service)
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
        [HttpPost]
        public IActionResult Create([FromForm] NewsContentDto dto,IList<IFormFile> listFile)
        {
            try
            {
                var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                if(_service.Create(dto,listFile,url)) 
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
        public IActionResult Update(int id, [FromForm] NewsContentDto dto, [FromForm] List<ImageNewsDto> ImageContentList, IList<IFormFile> listFile)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    if (_service.Update(dto, ImageContentList, listFile, url))
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

    }
}
