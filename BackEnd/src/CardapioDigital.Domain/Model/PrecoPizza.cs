using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("PRECO_PIZZA")]
    public class PrecoPizza
    {
        [Key]
        [Column("PRECO_ID")]
        public int Id { get; set; }

        [Column("PRECO_VALOR", TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        [ForeignKey("FK_TAMANHO_PRECO_PIZZA")]
        [Column("TAM_ID")]
        public int TamanhoId { get; set; }

        public Tamanho Tamanho { get; set; }

        [ForeignKey("FK_PIZZA_PRECO_PIZZA")]
        [Column("PIZZA_ID")]
        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

    }
}