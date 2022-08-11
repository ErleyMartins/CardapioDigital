using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class CategoriaPizzaDto
    {
        public int Id { get; set; }

        [Required]
        public string Categoria { get; set; }

        public ICollection<PizzaDto> Pizzas { get; set; }
    }
}