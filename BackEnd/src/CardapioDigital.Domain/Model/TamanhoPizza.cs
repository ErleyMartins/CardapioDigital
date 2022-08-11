using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("TAMANHO_PIZZA")]
    public class TamanhoPizza
    {
        [Column("PIZ_ID")]
        [ForeignKey("FK_TAMANHO_PIZZA_PIZZA")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        [Column("TAM_ID")]
        [ForeignKey("FK_TAMANHO_PIZZA_TAMANHO")]
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }
    }
}