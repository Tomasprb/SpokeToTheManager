using Microsoft.EntityFrameworkCore;

namespace SpokeToTheManager.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SpokeToTheManagerDBCF
;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
