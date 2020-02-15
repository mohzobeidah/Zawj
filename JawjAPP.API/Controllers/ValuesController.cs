using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JawjAPP.API.Data;
using JawjAPP.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JawjAPP.API.Controllers
{[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext=dataContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var getValue = await _dataContext.values.ToListAsync();
            return Ok (getValue);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Value> Get(int id)
        {
            var getOne = _dataContext.values.FirstOrDefault(x=>x.id==id);
            return (getOne);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Value> Post([FromBody] Value value)
        {
              if(ModelState.IsValid){
              _dataContext.values.Add(value);
              _dataContext.SaveChanges();

                return Ok(value);
                }
                return BadRequest(ModelState);

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
