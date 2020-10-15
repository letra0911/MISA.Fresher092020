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
        private IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> Get()
        {
            return _departmentRepository.Get();
        }
    }
}
