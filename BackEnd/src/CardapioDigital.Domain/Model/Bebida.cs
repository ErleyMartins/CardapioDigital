using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("BEBIDAS")]
    public class Bebida
    {
        [Key]
        [Column("BEB_ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("BEB_NOME")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("BEB_DESCRICAO")]
        public string Descricao { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("FK_CATEGORIA_BEBIDA_BEBIDA")]
        [Column("CAT_BEB_ID")]
        public int CategoriaBebidaId { get; set; }

        public CategoriaBebida CategoriaBebida { get; set; }
    }
}