using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess
{
    public class DatabaseMariaDbAccess<T>:IDisposable, IDatabaseAccess<T>
    {
        readonly string _connectionString = "User Id=nvmanh;Password=12345678@Abc;Host=35.194.166.58;Port=3306;Database=MISACukCuk_F09_NVMANH;Character Set=utf8";
        MySqlConnection _sqlConnection;
        MySqlCommand _sqlCommand;
        public DatabaseMariaDbAccess()
        {
            // Khởi tạo kết nối:
            _sqlConnection = new MySqlConnection(_connectionString);
            _sqlConnection.Open();
            // Đối tượng xử lý command:
            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NVMANH (14/10/2020)
        public IEnumerable<T> Get()
        {
            var employees = new List<T>();
            _sqlCommand.CommandText = "Proc_GetEmployees";
            // Thực hiện đọc dữ liệu:
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var employee = Activator.CreateInstance<T>();
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
                employees.Add(employee);
            }
            // 1. Kết nối với Database:
            // 2. Thực thi command lấy dữ liệu:
            // Trả về:
            return employees;
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy: NVMANH (14/10/2020)
        public T GetById(Guid entityId)
        {
            _sqlCommand.CommandText = "Proc_GetEmployeeById";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", entityId);
            MySqlDataReader mySqlDataReader = _sqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var entity = Activator.CreateInstance<T>();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(entity, value);
                }
                return entity;
            }
            return default;
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: NVMANH (14/10/2020)
        public int Insert(T employeeParam)
        { 
            var employee = employeeParam as Employee;
            _sqlCommand.Parameters.Clear();
            _sqlCommand.CommandText = "Proc_InsertEmployee";
            _sqlCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _sqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            _sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityDate", employee.IdentityDate);
            _sqlCommand.Parameters.AddWithValue("@IdentityNumber", employee.IdentityNumber);
            _sqlCommand.Parameters.AddWithValue("@IdentityPlace", employee.IdentityPlace);
            _sqlCommand.Parameters.AddWithValue("@PossitionId", employee.PossitionId);
            _sqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _sqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            _sqlCommand.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
            _sqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);
            var affectRows = _sqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        public int Update(T employee)
        {
            return 0;
        }

        public int Delete(Guid employeeId)
        {
            return 0;
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            _sqlCommand.CommandText = "Proc_GetEmployeeByCode";
            _sqlCommand.Parameters.AddWithValue("@EmployeeCode", employeeCode);
            var mySqlDataValue = _sqlCommand.ExecuteScalar();
            if (mySqlDataValue == null)
                return false;
            return true;
        }
    }
}
