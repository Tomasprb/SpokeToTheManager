using Microsoft.EntityFrameworkCore;

namespace SpokeToTheManager.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UsuarioModelo> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SpokeToTheManager
;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}

