using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class TipoDto
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<PizzaDto> Pizzas { get; set; }
    }
}