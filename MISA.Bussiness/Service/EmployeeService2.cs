using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService2 : IEmployeeBussiness
    {
        IEmployeeRepository _databaseAccess;
        public EmployeeService2(IEmployeeRepository databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            var employees = _databaseAccess.Get();
            var emploueeToxics = employees.Where(e => e.Gender == 1).ToList();
            return emploueeToxics;
        }

        public int Insert(Employee employee)
        {
            // Check trùng mã:
            var isExits = _databaseAccess.CheckEmployeeByCode(employee.EmployeeCode);
            if (!isExits)
                return _databaseAccess.Insert(employee);
            else
                return 0;
        }

        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
