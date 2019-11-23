using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> db;
        public Repository(DbSet<T> data) => db = data;

        public void Create(T item) => db.Add(item);

        public void Delete(T elem) => db.Remove(elem);

        public IEnumerable<T> Find(Func<T, bool> predicate) => db.Where(predicate);

        public IEnumerable<T> GetAll() => db.AsQueryable();

        public T GetById(int id) => db.Find(id);
    }
}
