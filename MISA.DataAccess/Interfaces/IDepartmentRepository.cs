using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NVMANH (15/10/2020)
        IEnumerable<Department> Get();
        Department GetById(Guid employeeId);
        int Insert(Department employee);
        int Update(Department employee);
        int Delete(Guid id);
    }
}
