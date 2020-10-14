using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseAccess<T>
    {
        IEnumerable<T> Get();
        T GetById(Guid employeeId);
        int Insert(T employee);
        int Update(T employee);
        int Delete(Guid id);

    }
}
