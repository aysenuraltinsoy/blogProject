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
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
