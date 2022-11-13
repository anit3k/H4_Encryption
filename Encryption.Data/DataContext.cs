using Encryption.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Encryption.Data
{
    /// <summary>
    /// Context class, part of the EF Core data library
    /// This class gets instantiated in project that needs to use SQL database.
    /// It would be nice to implement the repository pattern in this project to make it nice and easy to use database
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginFailure> LoginFailures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.,1433;Database=H4Encryption;User Id=sa;Password=Kode1234!;TrustServerCertificate=True;");
        }
    }
}
