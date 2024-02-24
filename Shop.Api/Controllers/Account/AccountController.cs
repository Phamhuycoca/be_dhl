using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Api.Helper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Api.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IUserServcie _servcie;
        private readonly IConfiguration _configuration;
        public AccountController(IUserServcie servcie, IConfiguration configuration)
        {
            _servcie = servcie;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Account account)
        {
            try
            {
                var checkEmpty = _servcie.getAll().Where(x => x.Email == account.Email).SingleOrDefault();
                if (checkEmpty == null)
                {
                    HashMD5 _md5 = new HashMD5();
                    UserDto dto = new UserDto()
                    {
                        Email = account.Email,
                        FullName = account.FullName,
                        Password = _md5.GetMD5(account.Password),
                        IsAdmin = false,
                        Avatar=""
                    };
                    if (_servcie.Create(dto))
                    {
                        return StatusCode(StatusCodes.Status200OK, new { message = "Tạo tài khoản thành công, vui lòng đăng nhập." });
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Tạo tài khoản không thành công." });
                }
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "Tài khoản đã tồn tại. Vui lòng kiểm tra lại thông tin." });

            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login model)
        {
            try
            {
                HashMD5 _md5 = new HashMD5();
                var check = _servcie.getAll().Find(x => x.Email.Equals(model.Email) && x.Password.Equals(_md5.GetMD5(model.Password)));
                if (check != null)
                {
                    //lấy khóa bí mật trong file appsetting.json
                    //mã hóa khóa bí mật
                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    //ký vào khóa bí mật đã mã hóa
                    var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                    //tạo ra claims để chứ thông tin bổ sung
                    /*       var claims = new List<Claim>
                       {
                           new Claim(ClaimTypes.Role,check.IsAdmin.ToString()),
                           new Claim(ClaimTypes.Name,check.Email),
                           new Claim(ClaimTypes.NameIdentifier,check.UserId.ToString())
                       };*/
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, check.Email),
                        new Claim(ClaimTypes.NameIdentifier, check.UserId.ToString())
                    };

                    if (check.IsAdmin)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "User"));
                    };

                    //tạo token vs các thông số khớp với cấu hình trong file programs để validate
                    var token = new JwtSecurityToken
                    (
                          issuer: _configuration["Jwt:Issuer"],
                          audience: _configuration["Jwt:Audience"],
                          expires: DateTime.Now.AddHours(1),
                          signingCredentials: signingCredential,
                          claims: claims
                    );
                    // sinh ra chuỗi token
                    /* return Ok(new
                     {
                         token = new JwtSecurityTokenHandler().WriteToken(token)
                     });*/
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        role = check.IsAdmin,
                        userId=check.UserId,
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        message = "Đăng nhập thành công"
                    }) ;
                }
                return StatusCode(StatusCodes.Status404NotFound, new { message = "Thông tin tài khoản hoặc mật khẩu không chính xác" });
            }
            catch (Exception ex)
            {
                ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPost("DecodeToken")]
        public IActionResult DecodeToken(string? token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var decodedToken = (JwtSecurityToken)validatedToken;

                var user = decodedToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var role = decodedToken.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                var response = new
                {
                    user = user,
                    role = role,
                };

                return Ok(response);
            }
            catch (SecurityTokenExpiredException)
            {
                // Token has expired
                return Unauthorized("Vui lòng đăng nhập lại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Token validation failed: {ex.Message}");
            }
        }

    }

}
