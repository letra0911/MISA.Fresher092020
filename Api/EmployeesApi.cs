using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel.Resolution;
using MySql.Data.MySqlClient;
using ThucTapWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesApi : ControllerBase
    {
        // GET: api/<EmployeesApi>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            // Lấy dữ liệu từ Database:
            // Khởi tạo thông tin kết nối
            string connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=35.194.166.58;Port=3306;Database=MISACukCuk_F09_NVMANH;Character Set=utf8";
            // Khởi tạo kết nối:
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            // Đối tượng xử lý command:
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = System.Data.CommandType.Text;
            mySqlCommand.CommandText = "SELECT * FROM Employee";
            // Thực hiện đọc dữ liệu:
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                //employee.EmployeeId = mySqlDataReader.GetGuid(0);
                //employee.EmployeeCode = mySqlDataReader.GetString(1);
                //employee.FullName = mySqlDataReader.GetString(2);

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = employee.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(employee, value);
                }
                //foreach (var item in mySqlDataReader)
                //{

                //    var abc = 1;
                //}
                employees.Add(employee);
            }
            // 1. Kết nối với Database:
            // 2. Thực thi command lấy dữ liệu:
            // Trả về:
            mySqlConnection.Close();
            return employees;
        }

        // GET api/<EmployeesApi>/5
        [HttpGet("{id}")]
        public string Get([FromRoute]int id, [FromQuery] string name, [FromHeader]string abc)
        {
            return abc;
        }

        // POST api/<EmployeesApi>
        [HttpPost]
        public Customer Post([FromBody] Customer customer)
        {
            return customer;
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
