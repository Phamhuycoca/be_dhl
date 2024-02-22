using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using System.Net;

namespace Shop.Api.Controllers.Department
{
    //[Authorize]
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService service)
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
        [HttpPost]
        public IActionResult Create(DepartmentDto dto)
        {
            try
            {
                if (_service.Create(dto))
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
        public IActionResult Update(int id, DepartmentDto dto)
        {
            try
            {
                if (_service.GetById(id) != null)
                {
                    dto.DepartmentId = id;
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
