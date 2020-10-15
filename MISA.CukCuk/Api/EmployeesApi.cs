using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Net.WebSockets;
using MISA.DataAccess.Interfaces;
using MISA.Common.Models;
using MISA.Bussiness.Interfaces;
using MISA.Bussiness.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApi : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeesApi(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeesApi>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeService.Get();
            if (employees.Count() > 0)
                return Ok(employees);
            else
                return NoContent();
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id">Id của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NVMANH (13/10/2020)
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var employee = _employeeService.GetById(id);
            if (employee!=null)
                return Ok(employee);
            else
                return NoContent();
        }

        // POST api/<EmployeesApi>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var affectRows = _employeeService.Insert(employee);
            if (affectRows > 0)
                return CreatedAtAction("POST",affectRows);
            else
                return BadRequest();
        }

        // PUT api/<EmployeesApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
