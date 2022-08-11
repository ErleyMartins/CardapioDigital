using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("PIZZA")]
    public class Pizza
    {
        [Key]
        [Column("PIZ_ID")]
        public int Id { get; set; }

        [ForeignKey("FK_CATEGORIA_PIZZA_PIZZA")]
        [Column("CAT_PIZ_ID")]
        public int CategoriaId { get; set; }

        public CategoriaPizza CategoriaPizza { get; set; }

        [ForeignKey("FK_TIPO_PIZZA")]
        [Column("TIPO_ID")]
        public int TipoId { get; set; }

        public Tipo Tipo { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("PIZ_NOME")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(256)]
        [Column("PIZ_DESCRICAO")]
        public string Descricao { get; set; }

        public ICollection<TamanhoPizza> TamanhosPizzas { get; set; }

        public ICollection<PrecoPizza> PrecosPizzas { get; set; }
    }
}