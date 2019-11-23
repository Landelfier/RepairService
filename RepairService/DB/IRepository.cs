using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Delete(T elem);
        void Create(T item);
    }
}
