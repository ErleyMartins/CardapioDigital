using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class CategoriaBebidaDto
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<BebidaDto> Bebidas { get; set; }
    }
}