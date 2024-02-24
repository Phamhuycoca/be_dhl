using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Applicationn.Services;

namespace Shop.Api.Controllers.CommentNews
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentNewsController : ControllerBase
    {
        private readonly ICommentNewsService _service;
        private readonly INotiService _otiService;
        private readonly INewsService _newsService;
        public CommentNewsController(ICommentNewsService service, INotiService otiService, INewsService newsService)
        {
            _service = service;
            _otiService = otiService;
            _newsService = newsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(_service.getAll());
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CommentNewsDto dto)
        {
            try
            {
                DateTime now = DateTime.Now;
                dto.CreateComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                if (_service.Create(dto))
                {
                    NotificationDto noti = new NotificationDto()
                    {
                        NewsId = dto.NewsId,
                        PostId = null,
                        UserId = _newsService.GetById(dto.NewsId).UserId,
                        Status = 0,
                        UserIdComment = dto.UserId
                    };
                    _otiService.Create(noti);
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

        [HttpGet("GetCommentsByUserId/{id}")]
        public IActionResult GetCommentsByUserId(int id)
        {
            try
            {
                return Ok(_service.getByIdUser(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,CommentNewsDto dto)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    DateTime now = DateTime.Now;
                    dto.CreateComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                    if (_service.Update(dto))
                    {
                        return StatusCode(StatusCodes.Status200OK, "Cập nhật thông tin thành công");
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Cập nhập không thành công");
                }
                return StatusCode(StatusCodes.Status404NotFound, "Không tìm thấy không tin");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
