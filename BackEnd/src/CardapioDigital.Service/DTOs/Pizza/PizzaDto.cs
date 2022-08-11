using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Service.DTOs
{
    public class PizzaDto
    {
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaPizzaDto CategoriaPizza { get; set; }

        public int TipoId { get; set; }

        public TipoDto Tipo { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<TamanhoDto> Tamanhos { get; set; }
        
        public ICollection<TamanhoPizzaDto> TamanhosPizzas { get; set; }

        public ICollection<PrecoPizzaDto> PrecosPizzas { get; set; }

    }
}