using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("CATEGORIA_BEBIDA")]
    public class CategoriaBebida
    {
        [Key]
        [Column("CAT_BEB_ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("CAT_BEB_DESCRICAO")]
        public string Descricao { get; set; }

        public ICollection<Bebida> Bebidas { get; set; }
    }
}