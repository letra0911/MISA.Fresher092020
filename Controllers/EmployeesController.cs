using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThucTapWeb.Models;

namespace ThucTapWeb.Controllers
{
    [Route("api/abc")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeedbContext _context;

        public EmployeesController(EmployeedbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {

            return await _context.Employee.ToListAsync();
        }
        [HttpGet("check")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByCode( string code)
        {
            return await _context.Employee.Where(x=>x.EmployeeCode.Equals(code)).ToListAsync();
        }
        [HttpGet("paging")]
        public async Task<ActionResult<PagingObject>> GetEmployee1([FromQuery]int page, [FromQuery] int size)
        {
            var pagingObject = new PagingObject();
            var allEm = await _context.Employee.ToListAsync();
            
            pagingObject.AllData = allEm;
            pagingObject.TotalRecord = allEm.Count();
            int totalP = 0;
            var du = pagingObject.TotalRecord % size;
            if (du > 0)
            {
                totalP = (pagingObject.TotalRecord / size) + 1;
            }
            else
            {
                totalP = (pagingObject.TotalRecord / size) ;
            }
            pagingObject.TotalPage = totalP;
            pagingObject.Data=await _context.Employee.Skip((page-1)*size).Take(size).ToListAsync();
            return pagingObject;
        }
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = "NV0001",
                EmployeeName = "Nguyễn Văn Mạnh",
                Gender = 1
            };
            //var employee = await _context.Employee.FindAsync(id);

            //if (employee == null)
            //{
            //    return NotFound();
            //}

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            //if (id != null)
            //{
            //    return BadRequest();
            //}

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(string id)
        {
            string[] str = id.Split(',');
            foreach (var item in str)
            {
                int i = Convert.ToInt32(item);
                var employee = await _context.Employee.FindAsync(i);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }
        

            return "ok";
        }

        private bool EmployeeExists(int id)
        {
            return true;
            //return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
