using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseContext<T>
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(string storeName);
        T GetById(Guid employeeId);
        int Insert(T employee);
        int Update(T employee);
        int Delete(Guid id);
    }
}
