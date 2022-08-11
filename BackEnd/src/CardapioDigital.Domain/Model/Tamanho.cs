using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("TAMANHO")]
    public class Tamanho
    {
        [Key]
        [Column("TAM_ID")]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        [Column("TAM_DESCRICAO")]
        public string Descricao { get; set; }

        public ICollection<TamanhoPizza> TamanhosPizzas { get; set; }

        public ICollection<PrecoPizza> PrecosPizzas { get; set; }

    }
}