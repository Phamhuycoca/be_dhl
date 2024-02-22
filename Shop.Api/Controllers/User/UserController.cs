using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Helper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;

namespace Shop.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServcie _service;
        public UserController(IUserServcie service)
        {
            _service = service;
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
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] UserDto dto, IFormFile? file)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                    if (_service. Update(dto,file, url))
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
        [HttpPut("ChangePassword/{id}")]
        public IActionResult ChangePassword(int id,UserDto dto)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    HashMD5 md5 = new HashMD5();
                    dto.Password=md5.GetMD5(dto.Password);
                    if (_service.ChangePassword(dto))
                    {
                        return StatusCode(StatusCodes.Status200OK, "Thay đổi mật khẩu thành công");
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

    }
}
