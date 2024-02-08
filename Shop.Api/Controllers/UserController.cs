using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _categoryService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService categoryService, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var user=_categoryService.GetAll().Where(x=>x.Username.Equals(userDto.Username) && x.Password==userDto.Password).FirstOrDefault();
            if(user!=null)
            {
                //lấy khóa bí mật trong file appsetting.json
                //mã hóa khóa bí mật
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                //ký vào khóa bí mật đã mã hóa
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                //tạo ra claims để chứ thông tin bổ sung
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Name,userDto.Username),
                    new Claim(ClaimTypes.Email,userDto.Email)
                };
                //tạo token vs các thông số khớp với cấu hình trong file programs để validate
                var token = new JwtSecurityToken
                (
                      issuer: _configuration["Jwt:Issuer"],
                      audience: _configuration["Jwt:Audience"],
                      expires:DateTime.Now.AddMinutes(5),
                      signingCredentials:signingCredential,
                      claims:claims
                );
                // sinh ra chuỗi token
                return Ok(new
                {
                    token=new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public IActionResult Post(UserDto category)
        {
            if (_categoryService.Add(category))
            {
                return CreatedAtAction("GetCategory", new { id = category.UserId }, category);
            }
            return Ok("Danh mục sản phẩm đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Put(UserDto category)
        {
            if (_categoryService.Update(category))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_categoryService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì loại sản phẩm này không tồn tại");
        }
    }
}
