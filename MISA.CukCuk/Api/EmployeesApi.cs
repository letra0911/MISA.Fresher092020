using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MISA.CukCuk.Models;

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
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            mySqlCommand.CommandText = "Proc_GetEmployees";
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

        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id">Id của nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: NVMANH (13/10/2020)
        [HttpGet("{id}")]
        public Employee Get([FromRoute]Guid id)
        {
            var connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=35.194.166.58;Port=3306;Database=MISACukCuk_F09_NVMANH;Character Set=utf8";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "Proc_GetEmployeeById";
            sqlCommand.Parameters.AddWithValue("@EmployeeId", id);
            sqlConnection.Open();
            MySqlDataReader mySqlDataReader =  sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = employee.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(employee, value);
                }
                return employee;
            }
            sqlConnection.Close();
            return null;
        }

        // POST api/<EmployeesApi>
        [HttpPost]
        public int Post([FromBody] Employee employee)
        {
            var connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=35.194.166.58;Port=3306;Database=MISACukCuk_F09_NVMANH;Character Set=utf8";
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "Proc_InsertEmployee";
            sqlCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@IdentityDate", employee.IdentityDate);
            sqlCommand.Parameters.AddWithValue("@IdentityNumber", employee.IdentityNumber);
            sqlCommand.Parameters.AddWithValue("@IdentityPlace", employee.IdentityPlace);
            sqlCommand.Parameters.AddWithValue("@PossitionId", employee.PossitionId);
            sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            sqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            sqlCommand.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
            sqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);
            sqlConnection.Open();
            var affectRows= sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return affectRows;
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
