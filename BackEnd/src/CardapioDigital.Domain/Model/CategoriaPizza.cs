using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("CATEGORIA_PIZZA")]
    public class CategoriaPizza
    {
        [Key]
        [Column("CAT_PIZ_ID")]
        public int Id { get; set; }

        [Required]
        [Column("CAT_PIZ_DESCRICAO")]
        public string Categoria { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
    }
}