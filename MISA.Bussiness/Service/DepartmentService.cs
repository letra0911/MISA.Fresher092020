using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class DepartmentService : IDepartmentService
    {
        IDatabaseAccess<Department> _databaseAccess;
        public DepartmentService(IDatabaseAccess<Department> databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Department GetById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            return _databaseAccess.Get();
        }

        public int Insert(Department employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Department employee)
        {
            throw new NotImplementedException();
        }
    }
}
