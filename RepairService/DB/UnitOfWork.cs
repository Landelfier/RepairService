using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairService.Models
{
    public class UnitOfWork:IDisposable
    {
        Context db;
        public UnitOfWork(Context context)
        {
            db = context;
            Users = new Repository<User>(db.Users);
            Additionals = new Repository<AdditionalOptions>(db.Additionals);
            BaseSettings = new Repository<BaseSettings>(db.BaseSettings);
            Flats = new FlatRepository(db);
            Materials = new Repository<Material>(db.Materials);
            AdditionalsFlat = new Repository<AdditionalsFlat>(db.AdditionalsFlat);
        }
        public IRepository<User> Users { get; set; }
        public IRepository<AdditionalOptions> Additionals { get; set; }
        public IRepository<BaseSettings> BaseSettings { get; set; }
        public IRepository<Flat> Flats { get; set; }
        public IRepository<Material> Materials { get; set; }
        public IRepository<RoomSettings> RoomSettings { get; set; }
        public IRepository<AdditionalsFlat> AdditionalsFlat { get; set; }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
