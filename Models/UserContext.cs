using Microsoft.EntityFrameworkCore;

namespace SpokeToTheManager.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<TipoEgreso> tipo_egresos { get; set; }
        public DbSet<TipoIngreso> tipo_ingresos { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Egreso> egresos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
       optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SpokeToTheManagerDBCF
            ;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
