using Microsoft.EntityFrameworkCore;
using CardapioDigitalWebAPI.Models;
using System.Text;
using System.Security.Cryptography;

namespace CardapioDigitalWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<Bebidas> Bebidas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Pizzas>()
                        .HasKey(p => new {p.PIZ_ID1});

            modelBuilder.Entity<Bebidas>()
                        .HasKey(b => new {b.BEB_ID1});

            modelBuilder.Entity<Usuarios>()
                        .HasKey(u => new {u.USR_ID1});


            // Convertendo a Senha para matriz de bytes
            byte[] senha = ASCIIEncoding.ASCII.GetBytes("Admin!@#");
            modelBuilder.Entity<Usuarios>()
                        .HasData(new Usuarios(1, "admin", new MD5CryptoServiceProvider().ComputeHash(senha), "Administrador", 0));
        }
    }
}