using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("TIPO")]
    public class Tipo
    {
        [Key]
        [Column("TIPO_ID")]
        public int Id { get; set; }

        [Required]
        [Column("TIPO_DESCRICAO")]
        public string Descricao { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
    }
}