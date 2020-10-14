using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentApi : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentApi(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: api/<DepartmentApi>
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _departmentService.Get();
            if (departments.Count() > 0)
                return Ok(departments);
            else
                return NoContent();
        }

        // GET api/<DepartmentApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
