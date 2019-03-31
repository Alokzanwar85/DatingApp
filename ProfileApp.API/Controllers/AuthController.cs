using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileApp.API.Data;
using ProfileApp.API.Dtos;
using ProfileApp.API.Models;

namespace ProfileApp.API.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AuthController :ControllerBase
    {
        public IAuthRepository _repo { get; set; }
        public AuthController(IAuthRepository repo)
        {
            this._repo=repo;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserforRegisterDto userforregisterdto)
        {
            userforregisterdto.UserName=userforregisterdto.UserName.ToLower();
            
            if(await _repo.UserExist(userforregisterdto.UserName))
               return BadRequest("User Already Exist");
            
            User user=new User();
            user.UserName=userforregisterdto.UserName;

           user=await _repo.Register(user,userforregisterdto.Password);

           return StatusCode(201);            
            
        }
        
    }
}