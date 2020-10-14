using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class DepartmentRepository:DatabaseMariaDbAccess<Department>, IDepartmentRepository
    {
    }
}
