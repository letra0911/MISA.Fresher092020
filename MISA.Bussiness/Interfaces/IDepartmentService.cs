using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: NVMANH (15/10/2020)
        IEnumerable<Department> Get();
    }
}
