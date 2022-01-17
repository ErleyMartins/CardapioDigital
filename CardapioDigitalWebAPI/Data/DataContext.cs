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

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Pizzas>()
                        .HasKey(p => new {p.PIZ_ID1});

            modelBuilder.Entity<Bebidas>()
                        .HasKey(b => new {b.BEB_ID1});

            modelBuilder.Entity<Usuarios>()
                        .HasKey(u => new {u.USR_ID1});

            modelBuilder.Entity<Usuarios>()
                        .HasData(new Usuarios(1, "admin", GerarHashMd5("Admin!@#"), "Administrador", 0));
        }
    }
}