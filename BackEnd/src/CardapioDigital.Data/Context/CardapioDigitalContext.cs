using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Context
{
    public class CardapioDigitalContext : DbContext
    {
        public CardapioDigitalContext(DbContextOptions<CardapioDigitalContext> options) : base(options) { }

        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Borda> Bordas { get; set; }
        public DbSet<CategoriaBebida> CategoriasBebidas { get; set; }
        public DbSet<CategoriaPizza> CategoriasPizzas { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<TamanhoPizza> TamanhosPizzas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TamanhoPizza>()
                        .HasKey(tamPizza => new { tamPizza.PizzaId, tamPizza.TamanhoId });

            modelBuilder.Entity<Pizza>()
                        .HasMany(pizza => pizza.TamanhosPizzas)
                        .WithOne(tamPizza => tamPizza.Pizza)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pizza>()
                        .HasOne(pizza => pizza.CategoriaPizza)
                        .WithMany(categoria => categoria.Pizzas)
                        .HasForeignKey(pizza => pizza.CategoriaId)
                        .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}