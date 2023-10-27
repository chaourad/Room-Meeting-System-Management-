

using GestiondesSalles.modals;
using Microsoft.EntityFrameworkCore;

namespace GestiondesSalles.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
            .HasOne(f => f.Floor)
            .WithMany(r => r.Rooms);
            modelBuilder.Entity<Room>()
            .HasMany(e => e.Equipements)
            .WithOne(r => r.Room);
            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany(rs => rs.Reservations);
            modelBuilder.Entity<User>()
            .HasMany(r => r.Reservations)
            .WithMany(u => u.Users);

        }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}