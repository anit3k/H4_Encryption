using Encryption.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Encryption.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.,1433;Database=H4Encryption;User Id=sa;Password=Kode1234!;TrustServerCertificate=True;");
        }
    }
}
