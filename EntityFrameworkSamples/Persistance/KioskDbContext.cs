using EntityFrameworkSamples.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSamples.Persistance
{
    public class KioskDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<User> Users { get; set; }

        public KioskDbContext(DbContextOptions<KioskDbContext> options)
        : base(options)
        {
            // Database.EnsureCreated() sprawdza, czy baza danych istnieje.
            // Jeśli tak - nic nie robi.
            // Jeśli nie - tworzy bazę i tabele zgodnie z modelem.
            // UWAGA: Gdy baza istnieje, nie jest sprawdzane, czy jest zgodna z modelem.
            // Aby zagwarantować zgodność bazy z modelem, można rozważyć sekwencję instrukcji:
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            // Powoduje to jednak zawsze usuwanie bazy przed rozpoczęciem działania programu.
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
