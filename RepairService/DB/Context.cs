using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairService.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<AdditionalOptions> Additionals { get; set; }
        public DbSet<BaseSettings> BaseSettings { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<RoomSettings> RoomSettings { get; set; }
        public DbSet<AdditionalsFlat> AdditionalsFlat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomSettings>()
                   .HasOne(m => m.Floor)
                   .WithMany(t => t.Floors)
                   .HasForeignKey(m => m.FloorID)
                   .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<RoomSettings>()
                 .HasOne(m => m.Doors)
                 .WithMany(t => t.Doors)
                 .HasForeignKey(m => m.DoorsID)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomSettings>()
                   .HasOne(m => m.Baseboard)
                   .WithMany(t => t.Baseboards)
                   .HasForeignKey(m => m.BaseboardID)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomSettings>()
                   .HasOne(m => m.Walls)
                   .WithMany(t => t.Walls)
                   .HasForeignKey(m => m.WallsID)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoomSettings>()
                    .HasOne(m => m.PowerSockets)
                    .WithMany(t => t.PowerSockets)
                    .HasForeignKey(m => m.PowerSocketsID)
                    .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
