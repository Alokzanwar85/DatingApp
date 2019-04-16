using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileApp.API.Data;
using ProfileApp.API.Models;
using AutoMapper;
using ProfileApp.API.Dtos;

namespace ProfileApp.API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private IUserrepository _repository;
        private IMapper _mapper;

        public UserController(IUserrepository repo,IMapper mapper)
        {
            _repository=repo;
            _mapper=mapper;


        }
        public async Task<IActionResult> GetUsers()
        {
             var users= await _repository.GetUsers();
             if(users!=null && users.Count()==0)
             {
                    return BadRequest("No User exists");
             }

             var usertoreturn=_mapper.Map<IEnumerable<UserDetailsDto>>(users);

             return Ok(usertoreturn);
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
                var user =await _repository.GetUser(id);

                if(user==null)
                {
                    return  BadRequest("User not exists");
                }

                return Ok(user);
        }

        

        
        
    }
}