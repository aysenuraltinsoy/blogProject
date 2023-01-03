using Microsoft.EntityFrameworkCore;
using NRM1_mysiteproject.Models.Entities;

namespace NRM1_mysiteproject.Models.Context
{
    public class MySiteContext :DbContext
    {
        public MySiteContext()
        {

        }
        public MySiteContext(DbContextOptions<MySiteContext> options) :base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ORUQO20;Database=nrm1MySite;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Hakkimda> Hakkimdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Projeler> Projelers { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
