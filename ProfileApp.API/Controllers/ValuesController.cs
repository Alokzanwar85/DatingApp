using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileApp.API.Data;

namespace ProfileApp.API.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        public DataContext DataContext { get; set;}

        public ValuesController(DataContext dataContext)
        {
            DataContext = dataContext;
        }
        // GET api/values
        
        [HttpGet]
        public async Task<IActionResult> GetValuesAsync()
        {
            var values=await DataContext.Values.ToListAsync();
            return Ok(values);
        }

        
        [HttpGet("{id}")]
        [AllowAnonymous()]
        public async Task<IActionResult> GetValueAsync(int id)
        {
            try{

             var value=await DataContext.Values.FirstOrDefaultAsync(i=>i.Id==id);

             return Ok(value);
            }
            catch(Exception ex)
            {
                return BadRequest();

            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
