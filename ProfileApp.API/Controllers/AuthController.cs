using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileApp.API.Data;
using ProfileApp.API.Dtos;
using ProfileApp.API.Models;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace ProfileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthRepository _repo { get; set; }
        
        public IConfiguration _Config { get;set;}
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            this._Config = config;
            this._repo = repo;
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserforRegisterDto userforregisterdto)
        {
            userforregisterdto.UserName = userforregisterdto.UserName.ToLower();
            
            if (await _repo.UserExist(userforregisterdto.UserName))
                return BadRequest("User Already Exist");

            User user = new User();
            user.UserName = userforregisterdto.UserName;

            user = await _repo.Register(user, userforregisterdto.Password);

            return StatusCode(201);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserforLoginDto userforLoginDto)
        {
            var user = await _repo.Login(userforLoginDto.UserName.ToLower(), userforLoginDto.Password);
            if (user == null)
                return Unauthorized();

            var claim = new[]
            {
                 new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                 new Claim(ClaimTypes.Name,user.UserName)
             };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_Config.GetSection("AppSettings:Token").Value));
            
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokendescriptor=new SecurityTokenDescriptor()
            {
                Subject=new ClaimsIdentity(claim),
                SigningCredentials=creds,
                Expires= System.DateTime.Now.AddDays(1)

            };

            var tokenHandler=new JwtSecurityTokenHandler();

            var token=tokenHandler.CreateToken(tokendescriptor);

                    return Ok(new {
                        token=tokenHandler.WriteToken(token)
                    });
        }

    }
}