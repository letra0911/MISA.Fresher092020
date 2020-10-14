using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : IEmployeeBussiness
    {
        IDatabaseAccess<Employee> _databaseAccess;
        public EmployeeService(IDatabaseAccess<Employee> databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        public int Delete(Guid id)
        {
            return _databaseAccess.Delete(id);
        }

        public Employee GetById(Guid employeeId)
        {
            return _databaseAccess.GetById(employeeId);
        }

        public IEnumerable<Employee> Get()
        {
            return _databaseAccess.Get();
        }

        public int Insert(Employee employee)
        {
            return _databaseAccess.Insert(employee);
        }

        public int Update(Employee employee)
        {
            return _databaseAccess.Update(employee);
        }
    }
}
