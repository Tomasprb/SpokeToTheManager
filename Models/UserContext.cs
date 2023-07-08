using Microsoft.EntityFrameworkCore;
using SpokeToTheManager.Models;

namespace SpokeToTheManager.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<TipoEgreso> tipo_egresos { get; set; }
        public DbSet<TipoIngreso> tipo_ingresos { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Egreso> egresos { get; set; }
        public DbSet<Socio> socios { get; set; }
        public DbSet<Rubro> rubros { get; set; }
        public DbSet<Recurso> recu { get; set; }
        public DbSet<TipoRecurso> tipos_recursos { get; set; }
        

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SpokeToTheManagerDBCF;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Socio>()
                .HasOne(c => c.Rubro)
                .WithMany(j => j.Socios)
                .HasForeignKey(c => c.RubroId);
            modelBuilder.Entity<Recurso>()
            .HasOne(c => c.Socio)
            .WithMany(j => j.Recursos)
            .HasForeignKey(c => c.SocioId);
        }
    }
}
