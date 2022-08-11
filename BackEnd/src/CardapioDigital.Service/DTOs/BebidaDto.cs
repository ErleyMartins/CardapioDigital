using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class BebidaDto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int CategoriaBebidaId { get; set; }

        public CategoriaBebidaDto CategoriaBebida { get; set; }
    }
}