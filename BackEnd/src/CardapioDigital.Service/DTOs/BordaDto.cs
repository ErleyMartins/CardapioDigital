using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class BordaDto
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}