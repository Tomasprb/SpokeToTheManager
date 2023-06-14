﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Recurso> recursos { get; set; }
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
        public DbSet<SpokeToTheManager.Models.Recurso>? Recurso { get; set; }
    }
}
