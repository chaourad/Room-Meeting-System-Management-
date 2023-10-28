

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
         
            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany(rs => rs.Reservations);
            modelBuilder.Entity<User>()
            .HasMany(r => r.Reservations)
            .WithMany(u => u.Users);
            
            modelBuilder.Entity<Equipement>()
            .HasOne(r => r.Room)
            .WithMany(e => e.Equipements);

        }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}