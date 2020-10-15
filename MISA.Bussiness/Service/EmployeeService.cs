using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {

        }
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool CheckEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        public Employee GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
