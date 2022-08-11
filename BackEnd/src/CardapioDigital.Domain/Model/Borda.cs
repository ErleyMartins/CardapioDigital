using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardapioDigital.Domain.Model
{
    [Table("BORDA")]
    public class Borda
    {
        [Key]
        [Column("BORDA_ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("BORDA_NOME")]
        public string Descricao { get; set; }
    }
}