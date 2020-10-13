using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesApi : ControllerBase
    {
        // GET: api/<ValuesApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
