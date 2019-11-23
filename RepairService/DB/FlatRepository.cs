using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class FlatRepository : IRepository<Flat>
    {
        Context db;
        public FlatRepository(Context data) => db = data;
        public void Create(Flat item)
        {
            var proxyRoom = db.RoomSettings.CreateProxy();
            db.Entry(proxyRoom).CurrentValues.SetValues(item.Rooms);
            item.Rooms = proxyRoom;
            db.Flats.Add(item);
            item.Additionals = item.Additionals.Select(x =>
            {
                var proxy = db.AdditionalsFlat.CreateProxy();
                proxy.Flat = item;
                proxy.AdditionalOptionsID = x.AdditionalOptionsID;
                return proxy;
            }).ToList();
        }

        public void Delete(Flat elem) => db.Flats.Remove(elem);

        public IEnumerable<Flat> Find(Func<Flat, bool> predicate) => db.Flats.Where(predicate);

        public IEnumerable<Flat> GetAll() => db.Flats.AsQueryable();

        public Flat GetById(int id) => db.Flats.Find(id);
    }
}
