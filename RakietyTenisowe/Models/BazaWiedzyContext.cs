using System.Data.Entity;

namespace RakietyTenisowe.Models
{
    public class BazaWiedzyContext : DbContext
    {
        public BazaWiedzyContext() : base("BazaWiedzy")
        {
        }
        public DbSet<Naciag> Naciagi { get; set; }
        public DbSet<Owijka> Owijki { get; set; }
        public DbSet<RakietaJuniorska> RakietyJuniorskie { get; set; }
        public DbSet<RakietaSeniorska> RakietySeniorskie { get; set; }
    }
}