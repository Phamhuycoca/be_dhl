using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.CommentPost
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentPostController : ControllerBase
    {
        private readonly ICommentPostService _service;
        private readonly INotiService _otiService;
        private readonly IPostService _postService;
        public CommentPostController(ICommentPostService service, INotiService otiService, IPostService postService)
        {
            _service = service;
            _otiService = otiService;
            _postService = postService;
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
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CommentPostDto dto)
        {
            try
            {
                DateTime now = DateTime.Now;
                dto.CreateComment = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                if (_service.Create(dto))
                {
                    NotificationDto noti = new NotificationDto()
                    {
                        PostId=dto.PostId,
                        NewsId=null,
                        UserId= _postService.GetById(dto.PostId).UserId,
                        Status=0,
                        UserIdComment=dto.UserId
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
        [HttpGet("GetCommentsByPostId/{id}")]
        public IActionResult GetCommentsByPostId(int id)
        {
            try
            {
                return Ok(_service.getListById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CommentPostDto dto)
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
